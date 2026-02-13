
using ClipboardNavigator.Lib.Plugins.Interfaces;

namespace ClipboardNavigator.Lib.Plugins;
public abstract class BackgroundServiceBase: IBackgroundService
{
    protected abstract int TickTimeoutMs { get; }
    public abstract string Name { get; }

    public RunState State { get; set; } = RunState.Running;

    public async Task Run(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            if (State == RunState.Running)
                await ExecutePluginCheck(cancellationToken);
            await Task.Delay(TimeSpan.FromMilliseconds(TickTimeoutMs), cancellationToken);
        }
    }

    protected abstract Task ExecutePluginCheck(CancellationToken cancellationToken);
}