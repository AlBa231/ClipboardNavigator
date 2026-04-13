using ClipboardNavigator.Lib.Plugins.Interfaces;

namespace ClipboardNavigator.Lib.Windows;

public interface IMainForm
{
    IntPtr Handle { get; }

    Task ShowNotification(string title, string message, NotificationType type);

    void InitPluginsMenu(IEnumerable<IPlugin> plugins);

    IClipboardListBox MainListBox { get; }
    void UpdateSelectedItem(ClipboardData clipboardData);
}

public enum NotificationType { Info, Warning, Error }
