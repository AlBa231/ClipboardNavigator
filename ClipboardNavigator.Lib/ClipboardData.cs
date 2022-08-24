namespace ClipboardNavigator.Lib;

public class ClipboardData
{
    public string Text { get; }

    public ClipboardData(string text)
    {
        Text = text;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        if (this == obj) return true;
        if (obj is ClipboardData second)
            return string.Equals(Text, second.Text);

        return false;
    }

    public override int GetHashCode()
    {
        return string.GetHashCode(Text);
    }
}