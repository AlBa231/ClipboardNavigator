namespace ClipboardNavigator.Lib.Commands;

public interface IHotkeyManager
{
    IntPtr? MainFormHandler { get; set; }
    IHotKey? FindHotkeyById(int hotkeyId);
    bool RegisterHotKey(IHotKey hotkey);
}
