using ClipboardNavigator.Lib;
using ClipboardNavigator.Lib.Commands;
using ClipboardNavigator.Lib.Notification;
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
    IHotkeyManager hotkeyManager,
    INotificationService notificationService,
    IWindowService windowService) : IDisposable
{
    public void Initialize(IMainForm mainForm)
    {
        InitLog();
        hotkeyManager.MainFormHandler = mainForm.Handle;
        pluginManager.StartPlugins();
        RegisterAllCommands();
        clipboardDataProvider.Changed += clipboardFacade.ProcessNewClipboardData;
        clipboardFacade.ProcessNewClipboardData(clipboardDataProvider.GetCurrentValue());
        notificationService.MainForm = mainForm;
        InitMainForm(mainForm);
    }

    private void RegisterAllCommands()
    {
        commandFactory.RegisterCommand(
            new HotKey { Modifiers = HotkeyModifiers.Shift | HotkeyModifiers.Control | HotkeyModifiers.Alt, Key = (int)Keys.P },
            new ShowPluginsCommand(windowService));
    }

    private static void InitLog()
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
            .Enrich.FromLogContext()
            .CreateLogger();
    }

    private void InitMainForm(IMainForm mainForm)
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
