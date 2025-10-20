using System.Diagnostics;
using ClipboardNavigator.LibWin.Plugins;

namespace ClipboardNavigator.Lib.Plugins.BackgroundServices;
public class ActivityKeeperPlugin(IIdleTimeService iddTimeService) : BackgroundServiceBase
{
    private const int IdleTimeoutToResetSeconds = 120;

    protected override int TickTimeoutSeconds => 15;

    protected override async Task ExecutePluginCheck(CancellationToken cancellationToken)
    {
        var idleTime = TimeSpan.FromMilliseconds(iddTimeService.GetIdleTime());
        if (idleTime.TotalSeconds > IdleTimeoutToResetSeconds)
            await iddTimeService.ResetIdleTime(cancellationToken);
    }
}