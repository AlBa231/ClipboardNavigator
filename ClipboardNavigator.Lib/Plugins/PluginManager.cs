namespace ClipboardNavigator.Lib.Plugins;
public sealed class PluginManager(IPluginFactory pluginFactory)
{
    private readonly List<Task> backgroundServiceTasks = new();
    private readonly CancellationTokenSource cancellationTokenSource = new();

    public void RunPlugins()
    {
        RunBackgroundServices();
    }

    public async Task StopAllServices()
    {
        try
        {
            await cancellationTokenSource.CancelAsync();
            await Task.WhenAll(backgroundServiceTasks);
        }
        catch (OperationCanceledException)
        {
            // Expected when cancelling tasks
        }
        finally
        {
            cancellationTokenSource.Dispose();
        }
    }

    private void RunBackgroundServices()
    {
        foreach (IBackgroundService backgroundService in pluginFactory.Plugins.OfType<IBackgroundService>())
        {
            backgroundServiceTasks.Add(backgroundService.Run(cancellationTokenSource.Token));
        }
    }
}
