namespace ClipboardNavigator.Lib.Plugins.Interfaces;

public interface IBackgroundService: IPlugin
{
    Task Run(CancellationToken cancellationToken);
}