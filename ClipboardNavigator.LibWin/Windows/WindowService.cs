using ClipboardNavigator.Lib.Windows;
using ClipboardNavigator.LibWin.Windows.Forms;

namespace ClipboardNavigator.LibWin.Windows;

public class WindowService : IWindowService
{
    public bool ShowSettingsDialog<T>(T settingsObject)
    {
        var dialog = new SettingsForm { SettingsObject = settingsObject };
        return dialog.ShowDialog() == DialogResult.OK;
    }
}
