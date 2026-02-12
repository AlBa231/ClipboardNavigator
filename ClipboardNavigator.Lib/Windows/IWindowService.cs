namespace ClipboardNavigator.Lib.Windows;

public interface IWindowService
{
    WindowObject<T> ShowSettingsDialog<T>(T settingsObject);
}

public class WindowObject<T>
{
    public required object Window { get; set; }

    public T? Result { get; set; }
}
