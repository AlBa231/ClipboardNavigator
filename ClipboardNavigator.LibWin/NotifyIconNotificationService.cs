using ClipboardNavigator.Lib.Notification;
using ClipboardNavigator.Lib.Windows;

namespace ClipboardNavigator.LibWin;
public class NotifyIconNotificationService(IMainForm mainForm) : INotificationService
{
    public void ShowBalloonText(string text, string title = "")
    {
        mainForm.ShowNotification(title, text, NotificationType.Info);
    }
}
