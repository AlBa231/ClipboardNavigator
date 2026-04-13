using ClipboardNavigator.Lib.Notification;
using ClipboardNavigator.Lib.Windows;

namespace ClipboardNavigator.LibWin;
public class NotifyIconNotificationService : INotificationService
{
    public IMainForm? MainForm { get; set; }

    public void ShowBalloonText(string text, string title = "")
    {
        MainForm?.ShowNotification(title, text, NotificationType.Info);
    }
}
