namespace ClipboardNavigator.Tests;

public class ClipboardDataTests
{
    [Fact]
    public void TestClipboardDataEquals()
    {
        var data1 = new ClipboardData("test value");
        var data2 = new ClipboardData("test value");

        var equality = Equals(data1, data2);

        Assert.True(equality);
    }

    [Fact]
    public void TestClipboardDataNotEquals()
    {
        var data1 = new ClipboardData("test value");
        var data2 = new ClipboardData("test value 2");

        var equality = Equals(data1, data2);

        Assert.False(equality);
    }
}