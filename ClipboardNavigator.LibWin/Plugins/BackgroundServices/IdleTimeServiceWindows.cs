using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ClipboardNavigator.Lib.Exceptions;
using ClipboardNavigator.Lib.Plugins.BackgroundServices;

namespace ClipboardNavigator.LibWin.Plugins.BackgroundServices;

public class IdleTimeServiceWindows : IIdleTimeService
{
    private const int MouseMoveIdleResetMilliSeconds = 200;
    private const int MouseMoveIdleResetTick = 10;

    [StructLayout(LayoutKind.Sequential)]
    struct LASTINPUTINFO
    {
        public uint cbSize;
        public uint dwTime;
    }

    [DllImport("user32.dll")]
    static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

    [DllImport("user32.dll")]
    static extern void mouse_event(uint dwFlags, int dx, int dy, uint dwData, UIntPtr dwExtraInfo);

    const uint MOUSEEVENTF_MOVE = 0x0001;

    public uint GetIdleTime()
    {
        LASTINPUTINFO lastInput = new LASTINPUTINFO();
        lastInput.cbSize = (uint)Marshal.SizeOf(lastInput);
        if (!GetLastInputInfo(ref lastInput))
            throw new AppException("Cannot retrieve idle time");

        return (uint)Environment.TickCount - lastInput.dwTime;
    }

    public async Task ResetIdleTime(CancellationToken cancellationToken)
    {
        Point currentCursor = Cursor.Position;
        for (var i = 0;
             i < MouseMoveIdleResetMilliSeconds && !cancellationToken.IsCancellationRequested;
             i += MouseMoveIdleResetTick)
        {
            MoveTo(10 + 2 * i, 1 + 2 * i);
            await Task.Delay(MouseMoveIdleResetTick, cancellationToken);
        }

        Cursor.Position = currentCursor;
    }

    private static void MoveTo(int x, int y)
    {
        Debug.WriteLine($"Move mouse to X={x}.Y={y}");
        mouse_event(MOUSEEVENTF_MOVE, x, y, 0, UIntPtr.Zero);
    }
}