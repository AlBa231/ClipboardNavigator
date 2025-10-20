namespace ClipboardNavigator.Lib.Plugins;

public interface IPluginFactory
{
    List<IPlugin> Plugins { get; }
    T GetPlugin<T>() where T : IPlugin;
}