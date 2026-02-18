namespace ClipboardNavigator.Lib.Commands;

public class ClipboardCommandFactory(IHotkeyManager hotkeyManager) : IClipboardCommandFactory
{
    private readonly Dictionary<IHotKey, IClipboardCommand> _commands = new();

    public IClipboardCommand? FindCommand(IHotKey hotKey)
    {
        return _commands.GetValueOrDefault(hotKey);
    }

    public IClipboardCommand? ExecuteCommand(IHotKey? hotKey)
    {
        if (hotKey == null) return null;
        var command = FindCommand(hotKey);
        command?.Execute();
        return command;
    }

    public void RegisterCommand(IHotKey hotKey, IClipboardCommand command)
    {
        try
        {
            _commands.Add(hotKey, command);
            hotkeyManager.RegisterHotKey(hotKey);
        }
        catch (ArgumentException e)
        {
            throw new CommandException("Specified HotKey already registered.", e);
        }
    }
}
