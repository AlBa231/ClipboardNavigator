
namespace ClipboardNavigator.Lib.Plugins.BackgroundServices;
public class ActivityKeeperPlugin(IIdleTimeService iddTimeService) : BackgroundServiceBase
{
    private const int IdleTimeoutToResetSeconds = 120;

    protected override int TickTimeoutMs => 15 * 1000;

    public override string Name => "Activity Keeper";

    protected override async Task ExecutePluginCheck(CancellationToken cancellationToken)
    {
        var idleTime = TimeSpan.FromMilliseconds(iddTimeService.GetIdleTime());
        if (idleTime.TotalSeconds > IdleTimeoutToResetSeconds && State == RunState.Running)
            await iddTimeService.ResetIdleTime(cancellationToken);
    }
}