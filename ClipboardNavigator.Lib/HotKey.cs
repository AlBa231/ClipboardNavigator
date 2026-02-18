namespace ClipboardNavigator.Lib;

public sealed class HotKey : IHotKey
{
    public string Name => $"{Modifiers}+{Key}";

    public HotkeyModifiers Modifiers { get; set; }

    public int Key { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj is IHotKey other)
            return Equals(other);
        return false;
    }

    public bool Equals(IHotKey? other)
    {
        return Key == other?.Key && Modifiers == other.Modifiers;
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
}
