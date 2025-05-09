using ClipboardNavigator.Lib;
using ClipboardNavigator.LibWin;

namespace ClipboardNavigator
{
    public partial class MainForm : Form
    {
        private readonly IClipboardFacade clipboardFacade;
        private TaskBarPopupForm? popupForm;

        private TaskBarPopupForm PopupForm => popupForm ??= new TaskBarPopupForm(clipboardFacade);

        public MainForm()
        {
            InitializeComponent();
            this.clipboardFacade = InitFacade();
            clipboardFacade.History.ListChanged += (_, _) => UpdateTextField();
            this.clipboardListBox.ClipboardFacade = this.clipboardFacade;
            this.clipboardListBox.SelectionChanged += (v) => UpdateTextField();
            UpdateTextField();
            if (AppSettings.Instance.AutoHideOnStart) Hide();
        }

        private ClipboardFacade InitFacade()
        {
            var clipboardDataProvider = new WindowsClipboardDataProvider();
            return new ClipboardFacade(clipboardDataProvider, new NotifyIconNotificationService(notifyIcon));
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
    }
}