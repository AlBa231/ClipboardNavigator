using ClipboardNavigator.Lib.Exceptions;
using ClipboardNavigator.Lib.Extensions;

namespace ClipboardNavigator.Lib.Plugins;

public class PluginFactory(IServiceProvider serviceProvider) : IPluginFactory
{
    private List<IPlugin>? plugins;
    public List<IPlugin> Plugins => plugins ??= LoadPluginsFromAssembly();

    public T GetPlugin<T>() where T : IPlugin
    {
        return (T)Plugins.First(p => p.GetType() == typeof(T));
    }

    private List<IPlugin> LoadPluginsFromAssembly()
    {
        return GetType().Assembly.GetTypesOf<IPlugin>()
            .Select(type => (IPlugin)(serviceProvider.GetService(type) ?? throw new AppException($"Cannot initialize {type.FullName}")))
            .ToList();
    }
}