using ClipboardNavigator.Lib;
using ClipboardNavigator.Lib.Plugins;
using ClipboardNavigator.Lib.Plugins.Interfaces;
using ClipboardNavigator.LibWin;

namespace ClipboardNavigator
{
    public partial class MainForm : Form
    {
        private readonly IPluginFactory _pluginFactory;
        private readonly IClipboardFacade clipboardFacade;
        private TaskBarPopupForm? popupForm;
        private bool isFirstShown = true;

        private TaskBarPopupForm PopupForm => popupForm ??= new TaskBarPopupForm(clipboardFacade);

        public MainForm(IPluginFactory pluginFactory)
        {
            _pluginFactory = pluginFactory;
            InitializeComponent();
            clipboardFacade = InitFacade();
            clipboardListBox.ClipboardFacade = clipboardFacade;
            clipboardListBox.SelectionChanged += (v) => UpdateTextField();
            UpdateTextField();
            InitPluginsMenu();
        }

        protected override void SetVisibleCore(bool value)
        {
            if (isFirstShown)
            {
                value = !AppSettings.Instance.AutoHideOnStart;
                isFirstShown = false;
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
            var settingsForm = new SettingsForm();
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
            textBoxCurrentClipboard.Text = clipboardFacade.CurrentValue.Text;
            clipboardListBox.SelectedItem = clipboardFacade.CurrentValue;
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
}