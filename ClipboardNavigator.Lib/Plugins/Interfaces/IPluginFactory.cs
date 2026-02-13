namespace ClipboardNavigator.Lib.Plugins.Interfaces;

public interface IPluginFactory
{
    List<IPlugin> Plugins { get; }
    T GetPlugin<T>() where T : IPlugin;
}