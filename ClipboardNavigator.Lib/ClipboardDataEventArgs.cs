namespace ClipboardNavigator.Lib;

public class ClipboardDataEventArgs : EventArgs
{
    public ClipboardDataEventArgs(ClipboardData data)
    {
        Data = data;
    }

    public ClipboardData Data { get; }

    public bool StopOtherScripts { get; set; }
}