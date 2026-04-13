using ClipboardNavigator.Lib.Windows;

namespace ClipboardNavigator.Lib.Notification;
public interface INotificationService
{
    public void ShowBalloonText(string text, string title = "");
    IMainForm? MainForm { get; set; }
}
