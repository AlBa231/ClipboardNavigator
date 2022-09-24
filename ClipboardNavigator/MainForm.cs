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
            this.clipboardFacade = new ClipboardFacade(new WindowsClipboardDataProvider());
            clipboardFacade.History.ListChanged += (_, _) => UpdateTextField();
            this.clipboardListBox.ClipboardFacade = this.clipboardFacade;
            this.clipboardListBox.SelectionChanged += (v) => UpdateTextField();
            UpdateTextField();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
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
            new SettingsForm().ShowDialog();
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
            PopupForm.Show();
            PopupForm.SetupLocation();
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Visible)
                Hide();
            else Show();
        }
    }
}