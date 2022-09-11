namespace ClipboardNavigator.Tests.LibTestImplementation
{
    internal class TestHotKey : IHotKey
    {
        public TestHotKey(string hotKeyName)
        {
            Name = hotKeyName;
        }

        public string Name { get; }

        public bool Equals(IHotKey? other)
        {
            return string.Equals(Name, other?.Name);
        }
        
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
