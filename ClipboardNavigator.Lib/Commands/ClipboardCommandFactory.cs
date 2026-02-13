namespace ClipboardNavigator.Lib.Commands;

public class ClipboardCommandFactory : IClipboardCommandFactory
{
    private readonly Dictionary<IHotKey, IClipboardCommand> commands = new();

    public IClipboardCommand? FindCommand(IHotKey hotKey)
    {
        return commands.GetValueOrDefault(hotKey);
    }

    public void RegisterCommand(IHotKey hotKey, IClipboardCommand command)
    {
        try
        {
            commands.Add(hotKey, command);
        }
        catch (ArgumentException e)
        {
            throw new CommandException("Specified HotKey already registered.", e);
        }
    }
}
