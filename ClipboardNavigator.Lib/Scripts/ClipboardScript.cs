using ClipboardNavigator.Lib.Notification;

namespace ClipboardNavigator.Lib.Scripts;

public abstract class ClipboardScript
{
    public string Name => GetType().Name;
    public INotificationService? NotificationService { get; set; }

    public virtual async Task Execute(ClipboardDataEventArgs clipboardData)
    {
        try
        {
            await TryExecute(clipboardData);
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Error executing script {Name}: {ex.Message}");
        }
    }

    protected abstract Task TryExecute(ClipboardDataEventArgs clipboardData);
}