namespace ClipboardNavigator.Lib.Scripts;

public interface IClipboardScript
{
    string Name { get; }
    Task Execute(ClipboardDataEventArgs clipboardData);
}
