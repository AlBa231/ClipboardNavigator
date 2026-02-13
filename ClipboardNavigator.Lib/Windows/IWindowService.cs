namespace ClipboardNavigator.Lib.Windows;

public interface IWindowService
{
    bool ShowSettingsDialog<T>(T settingsObject);
}