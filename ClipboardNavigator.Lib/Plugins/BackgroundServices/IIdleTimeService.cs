namespace ClipboardNavigator.Lib.Plugins.BackgroundServices;

public interface IIdleTimeService
{
    uint GetIdleTime();
    Task ResetIdleTime(CancellationToken cancellationToken);
}