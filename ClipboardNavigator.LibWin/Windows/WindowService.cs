using ClipboardNavigator.Lib.Windows;
using ClipboardNavigator.LibWin.Windows.Forms;

namespace ClipboardNavigator.LibWin.Windows;

public class WindowService : IWindowService
{
    public WindowObject<T> ShowSettingsDialog<T>(T settingsObject)
    {
        var dialog = new SettingsForm { SettingsObject = settingsObject };
        bool cancelled = dialog.ShowDialog() != DialogResult.OK;

        return new WindowObject<T>
        {
            Result = cancelled ? default : settingsObject,
            Window = dialog
        };
    }
}
