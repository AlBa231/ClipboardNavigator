using ClipboardNavigator.Lib;
using ClipboardNavigator.Lib.Commands;
using ClipboardNavigator.Lib.Plugins;
using ClipboardNavigator.Lib.Windows;
using ClipboardNavigator.LibWin.Commands.Impl;
using Serilog;

namespace ClipboardNavigator.Code;

public sealed class AppInitializer(IPluginManager pluginManager, IClipboardCommandFactory commandFactory, IWindowService windowService) : IDisposable
{
    public void Initialize()
    {
        InitLog();
        pluginManager.RunPlugins();
        RegisterAllCommands();
    }

    private void RegisterAllCommands()
    {
        commandFactory.RegisterCommand(new HotKey { Modifiers = HotkeyModifiers.Shift | HotkeyModifiers.Control, Key = (int)Keys.P }, new ShowPluginsCommand(windowService));
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
