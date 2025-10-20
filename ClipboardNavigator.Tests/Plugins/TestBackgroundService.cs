using ClipboardNavigator.Lib.Plugins;

namespace ClipboardNavigator.Tests.Plugins;

internal class TestBackgroundService : IBackgroundService
{
    public int TaskRunCount { get; set; }

    public Task Run(CancellationToken cancellationToken)
    {
        return Task.Run(async () =>
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                TaskRunCount++;
                await Task.Delay(1, cancellationToken);
            }
        }, cancellationToken);
    }
}