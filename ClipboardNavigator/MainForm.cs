using ClipboardNavigator.Code;
using ClipboardNavigator.Lib;
using ClipboardNavigator.Lib.Plugins;
using ClipboardNavigator.Lib.Plugins.Interfaces;
using ClipboardNavigator.Lib.Windows;
using ClipboardNavigator.LibWin.Win32;

namespace ClipboardNavigator;

public partial class MainForm : Form, IMainForm
{
    private readonly IClipboardFacade _clipboardFacade;
    private readonly IWindowService _windowService;
    private bool _isFirstShown = true;

    public IClipboardListBox MainListBox => clipboardListBox;

    public MainForm(IClipboardFacade clipboardFacade, IWindowService windowService, AppInitializer appInitializer)
    {
        _clipboardFacade = clipboardFacade;
        _windowService = windowService;
        InitializeComponent();
        appInitializer.Initialize(this);
    }

    public Task ShowNotification(string title, string message, NotificationType type)
    {
        notifyIcon.ShowBalloonTip(2000, title, message, ToolTipIcon.None);
        return Task.CompletedTask;
    }

    public void InitPluginsMenu(IEnumerable<IPlugin> plugins)
    {
        var menuItems = plugins.Select(p =>
            new ToolStripMenuItem(p.Name, null, pluginMenuItem_Click) { Tag = p, Checked = true }).Cast<ToolStripItem>().ToArray();
        menuPlugins.DropDownItems.AddRange(menuItems);
    }

    public void UpdateSelectedItem(ClipboardData clipboardData)
    {
        textBoxCurrentClipboard.Text = clipboardData.Text;
        clipboardListBox.SelectedItem = clipboardData;
    }

    protected override void WndProc(ref Message m)
    {
        if (m.Msg == Win32Constants.WM_HOTKEY)
            _clipboardFacade.FindAndExecuteCommand(m.WParam.ToInt32());
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

    private void pluginMenuItem_Click(object? sender, EventArgs e)
    {
        ToolStripMenuItem menuItem = (ToolStripMenuItem?)sender ?? throw new ArgumentNullException(nameof(sender));
        IPlugin plugin = (IPlugin?)menuItem.Tag ?? throw new ArgumentException("Sender doesn't contain reference to a Plugin", nameof(sender));
        menuItem.Checked = !menuItem.Checked;
        plugin.State = menuItem.Checked ? RunState.Running : RunState.Paused;
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

    private void hideShowToolStripMenuItem_Click(object sender, EventArgs e)
    {
        _windowService.TogglePopupForm();
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
