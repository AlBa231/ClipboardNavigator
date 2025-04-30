namespace ClipboardNavigator.Lib.Notification;
public interface INotificationService
{
    public void ShowBalloonText(string text, string title = "");
}
