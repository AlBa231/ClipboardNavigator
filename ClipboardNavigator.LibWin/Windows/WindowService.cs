using ClipboardNavigator.Lib.Windows;
using ClipboardNavigator.LibWin.Windows.Forms;

namespace ClipboardNavigator.LibWin.Windows;

public class WindowService(Func<SettingsForm> formFactory) : IWindowService
{
    public bool ShowSettingsDialog<T>(T settingsObject)
    {
        var dialog = formFactory();
        dialog.SettingsObject = settingsObject;
        return dialog.ShowDialog() == DialogResult.OK;
    }
}
