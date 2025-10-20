using System.Runtime.InteropServices;
using ClipboardNavigator.Lib.Exceptions;
using ClipboardNavigator.Lib.Plugins.BackgroundServices;

namespace ClipboardNavigator.LibWin.Plugins.BackgroundServices;

public class IdleTimeServiceWindows : IIdleTimeService
{

    [StructLayout(LayoutKind.Sequential)]
    struct LASTINPUTINFO
    {
        public uint cbSize;
        public uint dwTime;
    }

    [DllImport("user32.dll")]
    static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

    [DllImport("user32.dll")]
    static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, UIntPtr dwExtraInfo);

    const uint MOUSEEVENTF_MOVE = 0x0001;

    public uint GetIdleTime()
    {
        LASTINPUTINFO lastInput = new LASTINPUTINFO();
        lastInput.cbSize = (uint)Marshal.SizeOf(lastInput);
        if (!GetLastInputInfo(ref lastInput))
            throw new AppException("Cannot retrieve iddle time");

        return (uint)Environment.TickCount - lastInput.dwTime;
    }

    public void ResetIdleTime()
    {
        mouse_event(MOUSEEVENTF_MOVE, 0, 1, 0, UIntPtr.Zero);
        mouse_event(MOUSEEVENTF_MOVE, 0, unchecked((uint)-1), 0, UIntPtr.Zero);
    }
}