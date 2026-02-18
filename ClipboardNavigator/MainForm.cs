using ClipboardNavigator.Code;
using ClipboardNavigator.Lib;
using ClipboardNavigator.Lib.Commands;
using ClipboardNavigator.Lib.Plugins;
using ClipboardNavigator.Lib.Plugins.Interfaces;
using ClipboardNavigator.Lib.Windows;
using ClipboardNavigator.LibWin;
using ClipboardNavigator.LibWin.Win32;

namespace ClipboardNavigator;

public partial class MainForm : Form, IMainForm
{
    private readonly IPluginFactory _pluginFactory;
    private readonly IHotkeyManager _hotkeyManager;
    private readonly IClipboardCommandFactory _commandFactory;
    private readonly IClipboardFacade _clipboardFacade;
    private TaskBarPopupForm? _popupForm;
    private bool _isFirstShown = true;

    private TaskBarPopupForm PopupForm => _popupForm ??= new TaskBarPopupForm(_clipboardFacade);

    public MainForm(IPluginFactory pluginFactory, IHotkeyManager hotkeyManager, IClipboardCommandFactory commandFactory, AppInitializer appInitializer)
    {
        _pluginFactory = pluginFactory;
        _hotkeyManager = hotkeyManager;
        _commandFactory = commandFactory;
        InitializeComponent();
        hotkeyManager.MainFormHandler = Handle;
        appInitializer.Initialize();
        _clipboardFacade = InitFacade();
        InitUi();
    }

    private void InitUi()
    {
        clipboardListBox.ClipboardFacade = _clipboardFacade;
        clipboardListBox.SelectionChanged += _ => UpdateTextField();
        UpdateTextField();
        InitPluginsMenu();
    }

    protected override void WndProc(ref Message m)
    {
        if (m.Msg == Win32Constants.WM_HOTKEY)
        {
            IHotKey? command = _hotkeyManager.FindHotkeyById(m.WParam.ToInt32());
            _commandFactory.ExecuteCommand(command);
        }
        base.WndProc(ref m);
    }

    protected override void SetVisibleCore(bool value)
    {
        if (_isFirstShown)
        {
            value = !AppSettings.Instance.AutoHideOnStart;
            _isFirstShown = false;
        }
        base.SetVisibleCore(value);
    }

    private void InitPluginsMenu()
    {
        var menuItems = _pluginFactory.Plugins.Select(p =>
            new ToolStripMenuItem(p.Name, null, pluginMenuItem_Click){Tag = p, Checked = true}).Cast<ToolStripItem>().ToArray();
        menuPlugins.DropDownItems.AddRange(menuItems);
    }

    private void pluginMenuItem_Click(object? sender, EventArgs e)
    {
        ToolStripMenuItem menuItem = (ToolStripMenuItem?)sender ?? throw new ArgumentNullException(nameof(sender));
        IPlugin plugin = (IPlugin?)menuItem.Tag ?? throw new ArgumentException("Sender doesn't contain reference to a Plugin", nameof(sender));
        menuItem.Checked = !menuItem.Checked;
        plugin.State = menuItem.Checked ? RunState.Running : RunState.Paused;
    }

    private ClipboardFacade InitFacade()
    {
        var clipboardDataProvider = new WindowsClipboardDataProvider();
        var facade = new ClipboardFacade(clipboardDataProvider, new NotifyIconNotificationService(notifyIcon));
        facade.History.ListChanged += (_, _) => UpdateTextField();
        return facade;
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Close();
        Application.Exit();
    }

    private void MainForm_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
    {
        if (e.KeyCode == Keys.Escape)
        {
            hideShowToolStripMenuItem_Click(sender, e);
        }
    }

    private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var settingsForm = new MainSettingsForm();
        settingsForm.ShowDialog();
    }

    private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            hideShowToolStripMenuItem_Click(sender, e);
        }
    }

    private void UpdateTextField()
    {
        textBoxCurrentClipboard.Text = _clipboardFacade.CurrentValue.Text;
        clipboardListBox.SelectedItem = _clipboardFacade.CurrentValue;
    }

    private void hideShowToolStripMenuItem_Click(object sender, EventArgs e)
    {
        PopupForm.ToggleVisibility();
    }

    private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        showHideMainWindowToolStripMenuItem_Click(sender, e);
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (e.CloseReason == CloseReason.UserClosing)
        {
            e.Cancel = true;
            Hide();
        }
    }

    private void showHideMainWindowToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (Visible)
            Hide();
        else Show();
    }

    private void mainMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
    {

    }
}
