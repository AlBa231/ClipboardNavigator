using ClipboardNavigator.Lib.Plugins.Interfaces;

namespace ClipboardNavigator.Lib.Plugins;

public sealed class PluginManager(IPluginFactory pluginFactory) : IPluginManager
{
    private readonly List<Task> backgroundServiceTasks = [];
    private readonly CancellationTokenSource cancellationTokenSource = new();

    public IPluginFactory PluginFactory { get; } = pluginFactory;

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
        foreach (IBackgroundService backgroundService in PluginFactory.Plugins.OfType<IBackgroundService>())
        {
            backgroundServiceTasks.Add(backgroundService.Run(cancellationTokenSource.Token));
        }
    }
}
