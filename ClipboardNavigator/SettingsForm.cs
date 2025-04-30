using ClipboardNavigator.Lib;
using ClipboardNavigator.LibWin;

namespace ClipboardNavigator;

public partial class SettingsForm : Form
{
    private readonly AutoRunRegistrySetting autoRunRegistry = new(Application.ExecutablePath, new WindowsRunRegistrySetting());
    public SettingsForm()
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
    }

    private void cbAutoStart_CheckedChanged(object sender, EventArgs e)
    {
        autoRunRegistry.IsAutoStart = cbAutoStart.Checked;
    }
}