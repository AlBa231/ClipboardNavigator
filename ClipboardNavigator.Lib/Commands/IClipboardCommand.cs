namespace ClipboardNavigator.Lib.Commands;

public interface IClipboardCommand
{
    public IHotKey HotKey { get; }

    public void Execute();
}