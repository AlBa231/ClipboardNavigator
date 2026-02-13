namespace ClipboardNavigator.Lib.Commands;

public interface IClipboardCommandFactory
{
    IClipboardCommand? FindCommand(IHotKey hotKey);
    void RegisterCommand(IHotKey hotKey, IClipboardCommand command);
}
