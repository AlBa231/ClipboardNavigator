using ClipboardNavigator.Lib;
using ClipboardNavigator.LibWin;

namespace ClipboardNavigator;

public partial class MainSettingsForm : Form
{
    private readonly AutoRunRegistrySetting autoRunRegistry = new(Application.ExecutablePath, new WindowsRunRegistrySetting());
    public MainSettingsForm()
    {
        InitializeComponent();
        TryInitFields();
    }

    private void TryInitFields()
    {
        try
        {
            InitFields();
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void InitFields()
    {
        cbAutoStart.Checked = autoRunRegistry.IsAutoStart;
        cbAutoHide.Checked = autoRunRegistry.IsAutoStart && AppSettings.Instance.AutoHideOnStart;
    }

    private void cbAutoStart_CheckedChanged(object sender, EventArgs e)
    {
        autoRunRegistry.IsAutoStart = cbAutoStart.Checked;
        cbAutoHide.Enabled = cbAutoStart.Checked;
    }

    private void cbAutoHide_CheckedChanged(object sender, EventArgs e)
    {
        AppSettings.Instance.AutoHideOnStart = cbAutoHide.Checked;
    }
}
