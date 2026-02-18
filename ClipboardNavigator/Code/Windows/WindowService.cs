using ClipboardNavigator.Code.Windows.Forms;
using ClipboardNavigator.Code.Windows.Forms.Plugins;
using ClipboardNavigator.Lib.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace ClipboardNavigator.Code.Windows;

public class WindowService(IServiceProvider serviceProvider) : IWindowService
{
    public bool ShowSettingsDialog<T>(T settingsObject)
    {
        var dialog = serviceProvider.GetRequiredService<PluginSettingsForm>();
        dialog.SettingsObject = settingsObject;
        return dialog.ShowDialog() == DialogResult.OK;
    }

    public bool ShowPluginsDialog()
    {
        var dialog = serviceProvider.GetRequiredService<PluginListForm>();
        return dialog.ShowDialog() == DialogResult.OK;
    }
}
