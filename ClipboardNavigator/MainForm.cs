using ClipboardNavigator.Lib;

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
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void hideShowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Visible)
                Hide();
            else Show();
        }

        private void MainForm_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                hideShowToolStripMenuItem_Click(sender, e);
            }
        }
    }
}