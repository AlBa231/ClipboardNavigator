namespace ClipboardNavigator.Lib;

public interface IClipboardDataProvider
{
    public ClipboardData GetCurrentValue();
    public void SetCurrentValue(ClipboardData value);
    public event ClipboardDataChanged Changed;
}

public delegate void ClipboardDataChanged(ClipboardData data);