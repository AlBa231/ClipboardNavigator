namespace ClipboardNavigator.Lib;
public class AppSettings
{
    public static AppSettings Instance { get; } = new AppSettings();

    public bool DisplayNewDataNotification { get; set; }
    public bool AutoHideOnStart { get; set; } = true;
    public int MaxHistoryItems { get; set; } = 50;
}
