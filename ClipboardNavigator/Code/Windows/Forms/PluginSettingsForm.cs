using System.ComponentModel;

namespace ClipboardNavigator.Code.Windows.Forms;

public partial class PluginSettingsForm : Form
{
    public PluginSettingsForm()
    {
        InitializeComponent();
    }

    [DefaultValue(null)]
    public object? SettingsObject
    {
        get => propertyGrid.SelectedObject;
        set => propertyGrid.SelectedObject = value;
    }
}
