using ClipboardNavigator.Lib.Plugins;

namespace ClipboardNavigator.LibWin.Plugins;
public abstract class BackgroundServiceBase: IBackgroundService
{
    protected abstract int TickTimeoutSeconds { get; }

    public async Task Run(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            await ExecutePluginCheck();
            await Task.Delay(TimeSpan.FromSeconds(TickTimeoutSeconds), cancellationToken);
        }
    }

    protected abstract Task ExecutePluginCheck();
}
