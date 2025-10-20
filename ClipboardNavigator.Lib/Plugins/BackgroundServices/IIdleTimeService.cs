namespace ClipboardNavigator.Lib.Plugins.BackgroundServices;

public interface IIdleTimeService
{
    uint GetIdleTime();
    void ResetIdleTime();
}