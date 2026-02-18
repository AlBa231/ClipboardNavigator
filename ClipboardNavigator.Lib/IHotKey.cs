namespace ClipboardNavigator.Lib;

public interface IHotKey: IEquatable<IHotKey>
{
    public string Name { get; }
    HotkeyModifiers Modifiers { get; set; }
    public int Key { get; set; }
}
