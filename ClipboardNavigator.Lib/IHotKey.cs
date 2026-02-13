namespace ClipboardNavigator.Lib;

public interface IHotKey: IEquatable<IHotKey>
{
    public string Name { get; }
}
