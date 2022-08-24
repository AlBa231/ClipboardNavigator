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
    }
}