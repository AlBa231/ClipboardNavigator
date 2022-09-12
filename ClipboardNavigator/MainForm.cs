using ClipboardNavigator.Lib;
using ClipboardNavigator.LibWin;

namespace ClipboardNavigator
{
    public partial class MainForm : Form
    {
        private IClipboardFacade clipboardFacade;
        public MainForm()
        {
            InitializeComponent();
            this.clipboardFacade = new ClipboardFacade(new WindowsClipboardDataProvider());
            this.lbClipboardHistory.DataSource = this.clipboardFacade.History;
            clipboardFacade.History.ListChanged += (_, _) => UpdateTextField();
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

        private void hideShowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Visible)
                Hide();
            else Show();
        }

        private void lbClipboardHistory_MouseClick(object sender, MouseEventArgs e)
        {
            if (lbClipboardHistory.SelectedItem is ClipboardData item) 
                clipboardFacade.CurrentValue = item;
            UpdateTextField();
        }

        private void UpdateTextField()
        {
            textBoxCurrentClipboard.Text = clipboardFacade.CurrentValue.Text;
            lbClipboardHistory.SelectedItem = clipboardFacade.CurrentValue;
        }
    }
}