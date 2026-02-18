namespace ClipboardNavigator.Tests.LibTestImplementation;

internal class TestHotKey : IHotKey
{
    public TestHotKey(string hotKeyName)
    {
        Name = hotKeyName;
    }

    public string Name { get; }
    public HotkeyModifiers Modifiers { get; set; }
    public int Key { get; set; }

    public bool Equals(IHotKey? other)
    {
        return string.Equals(Name, other?.Name);
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
}
