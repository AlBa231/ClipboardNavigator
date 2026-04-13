using ClipboardNavigator.Lib.Plugins.Interfaces;

namespace ClipboardNavigator.Lib.Plugins;

public interface IPluginManager
{
    IPluginFactory PluginFactory { get; }
    void StartPlugins();
    Task StopAllServices();
}
