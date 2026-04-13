namespace ClipboardNavigator.Lib.Commands;

public interface IHotkeyManager
{
    IHotKey? FindHotkeyById(int hotkeyId);
    bool RegisterHotKey(IHotKey hotkey);
}
