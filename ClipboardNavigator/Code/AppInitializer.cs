using ClipboardNavigator.Lib;
using ClipboardNavigator.Lib.Commands;
using ClipboardNavigator.Lib.Plugins;
using ClipboardNavigator.Lib.Windows;
using ClipboardNavigator.LibWin.Commands.Impl;
using Serilog;

namespace ClipboardNavigator.Code;

public sealed class AppInitializer(
    IClipboardDataProvider clipboardDataProvider,
    IClipboardFacade clipboardFacade,
    IPluginManager pluginManager,
    IClipboardCommandFactory commandFactory,
    IMainForm mainForm,
    IWindowService windowService) : IDisposable
{
    public void Initialize()
    {
        InitLog();
        pluginManager.StartPlugins();
        RegisterAllCommands();
        clipboardDataProvider.Changed += clipboardFacade.ProcessNewClipboardData;
        clipboardFacade.ProcessNewClipboardData(clipboardDataProvider.GetCurrentValue());
        InitMainForm();
    }

    private void RegisterAllCommands()
    {
        commandFactory.RegisterCommand(
            new HotKey { Modifiers = HotkeyModifiers.Shift | HotkeyModifiers.Control, Key = (int)Keys.P },
            new ShowPluginsCommand(windowService));
    }

    private static void InitLog()
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
            .Enrich.FromLogContext()
            .CreateLogger();
    }

    private void InitMainForm()
    {
        mainForm.InitPluginsMenu(pluginManager.PluginFactory.Plugins);
        mainForm.MainListBox.DataProvider = clipboardDataProvider;
        mainForm.MainListBox.ClipboardFacade = clipboardFacade;
        mainForm.MainListBox.SelectionChanged += mainForm.UpdateSelectedItem;
        clipboardFacade.History.ListChanged += (_, e) => mainForm.UpdateSelectedItem(clipboardFacade.History[e.NewIndex]);
    }

    public void Dispose()
    {
        pluginManager.StopAllServices().Wait();
        Log.CloseAndFlush();
    }
}
