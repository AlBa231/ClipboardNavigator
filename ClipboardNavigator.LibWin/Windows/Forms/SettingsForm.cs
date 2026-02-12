using System.ComponentModel;

namespace ClipboardNavigator.LibWin.Windows.Forms;

public partial class SettingsForm : Form
{
    public SettingsForm()
    {
        InitializeComponent();
    }

    [DefaultValue(null)]
    internal object? SettingsObject
    {
        get => propertyGrid.SelectedObject;
        set => propertyGrid.SelectedObject = value;
    }
}
