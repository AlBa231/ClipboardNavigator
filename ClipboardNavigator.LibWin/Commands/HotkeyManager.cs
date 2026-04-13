using System.Runtime.InteropServices;
using ClipboardNavigator.Lib;
using ClipboardNavigator.Lib.Commands;
using ClipboardNavigator.Lib.Windows;
using Microsoft.Extensions.Logging;

namespace ClipboardNavigator.LibWin.Commands;

public class HotkeyManager(ILogger<HotkeyManager> logger, IMainForm mainForm):IHotkeyManager
{
    private const int InitHotkeyId = 100;
    [DllImport("user32.dll")]
    private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

    [DllImport("user32.dll")]
    private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

    private readonly List<IHotKey> _registeredHotkeys = [];


    public IHotKey? FindHotkeyById(int hotkeyId)
    {
        int hotkeyIndex = hotkeyId - InitHotkeyId - 1;
        if (hotkeyIndex < 0 || hotkeyIndex >= _registeredHotkeys.Count)
            return null;

        return _registeredHotkeys[hotkeyIndex];
    }

    public bool RegisterHotKey(IHotKey hotkey)
    {
        try
        {
            _registeredHotkeys.Add(hotkey);
            return RegisterHotKey(mainForm.Handle, _registeredHotkeys.Count + InitHotkeyId, (uint)hotkey.Modifiers, (uint)hotkey.Key);
        }
        catch (Exception e)
        {
            logger.LogError(e, "Failed to register hotkey {Hotkey}", hotkey);
        }

        return false;
    }
}
