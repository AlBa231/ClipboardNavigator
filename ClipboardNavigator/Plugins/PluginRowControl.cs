using System.ComponentModel;
using ClipboardNavigator.Lib.Plugins.Interfaces;
using ClipboardNavigator.Lib.Windows;

namespace ClipboardNavigator.Plugins;

public partial class PluginRowControl : UserControl
{
    private readonly IWindowService _windowService;

    public PluginRowControl(IWindowService windowService)
    {
        _windowService = windowService;
        InitializeComponent();
    }

    [DefaultValue(null)]
    public IPlugin? Plugin
    {
        get;
        set
        {
            field = value;
            UpdateLabels();
        }
    }

    private void UpdateLabels()
    {
        if (Plugin == null) return;

        lblName.Text = Plugin.Name;
        btnSettings.Visible = Plugin is IPluginWithSettings;
    }

    private void btnSettings_Click(object sender, EventArgs e)
    {
        if (Plugin is IPluginWithSettings pluginWithSettings)
        {
            _windowService.ShowSettingsDialog(pluginWithSettings.GetSettings());
        }
    }
}
