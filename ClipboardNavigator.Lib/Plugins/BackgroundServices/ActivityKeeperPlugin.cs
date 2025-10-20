using ClipboardNavigator.LibWin.Plugins;

namespace ClipboardNavigator.Lib.Plugins.BackgroundServices;
public class ActivityKeeperPlugin(IIdleTimeService iddTimeService) : BackgroundServiceBase
{
    private const int IdleTimeoutToResetSeconds = 120;

    protected override int TickTimeoutSeconds => 15;

    protected override Task ExecutePluginCheck()
    {
        var idleTime = TimeSpan.FromMilliseconds(iddTimeService.GetIdleTime());
        if (idleTime.Seconds > IdleTimeoutToResetSeconds)
            iddTimeService.ResetIdleTime();
        return Task.CompletedTask;
    }
}