using ClipboardNavigator.Lib.Plugins;

namespace ClipboardNavigator.Tests.Plugins;

internal class TestBackgroundService : BackgroundServiceBase
{
    public int TaskRunCount { get; set; }

    protected override Task ExecutePluginCheck(CancellationToken cancellationToken)
    {
        TaskRunCount++;
        return Task.CompletedTask;
    }

    protected override int TickTimeoutMs => 1;
    public override string Name => "Test service";
}