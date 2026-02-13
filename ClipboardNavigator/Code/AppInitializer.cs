using ClipboardNavigator.Lib.Commands;
using ClipboardNavigator.Lib.Plugins;
using Serilog;

namespace ClipboardNavigator.Code;

public sealed class AppInitializer(IPluginManager pluginManager, IClipboardCommandFactory commandFactory):IDisposable
{
    public void Initialize()
    {
        InitLog();
        pluginManager.RunPlugins();
        RegisterAllCommands();
    }

    private void RegisterAllCommands()
    {
    }

    private static void InitLog()
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
            .Enrich.FromLogContext()
            .CreateLogger();
    }

    public void Dispose()
    {
        pluginManager.StopAllServices().Wait();
        Log.CloseAndFlush();
    }
}
