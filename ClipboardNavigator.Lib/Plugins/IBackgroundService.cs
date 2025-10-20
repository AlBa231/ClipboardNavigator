namespace ClipboardNavigator.Lib.Plugins;

public interface IBackgroundService: IPlugin
{
    Task Run(CancellationToken cancellationToken);
}