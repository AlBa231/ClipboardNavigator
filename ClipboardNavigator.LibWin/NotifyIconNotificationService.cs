using System.Windows.Forms;
using ClipboardNavigator.Lib.Notification;

namespace ClipboardNavigator.LibWin;
public class NotifyIconNotificationService(NotifyIcon notifyIcon) : INotificationService
{
    public void ShowBalloonText(string text, string title = "")
    {
        notifyIcon.ShowBalloonTip(2000, title, text, ToolTipIcon.None);
    }
}
