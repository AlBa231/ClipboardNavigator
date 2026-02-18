using System.ComponentModel;

namespace ClipboardNavigator.Code.Windows.Forms;

public partial class PluginSettingsForm : Form
{
    public PluginSettingsForm()
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
