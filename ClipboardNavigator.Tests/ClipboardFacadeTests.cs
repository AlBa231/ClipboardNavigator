namespace ClipboardNavigator.Tests;

public class ClipboardFacadeTests
{
    [Fact]
    public void TestClipboardFacadeGetItems()
    {
        var testData = new ClipboardData("test data");
        // ReSharper disable once PossibleUnintendedReferenceComparison
        var dataProvider = Mock.Of<IClipboardDataProvider>(p => p.GetCurrentValue() == testData);
        IClipboardFacade clipboardFacade = new ClipboardFacade(dataProvider);

        var items = clipboardFacade.History;

        Assert.Single(items);
        Assert.Equal("test data", items[0].Text);
    }

    [Fact]
    public void TestClipboardNewItem()
    {
        var testData = new ClipboardData("test data");
        var testData2 = new ClipboardData("test data 2");
        // ReSharper disable once PossibleUnintendedReferenceComparison
        var dataProvider = Mock.Of<IClipboardDataProvider>(p => p.GetCurrentValue() == testData);
        IClipboardFacade clipboardFacade = new ClipboardFacade(dataProvider);

        Mock.Get(dataProvider).Raise(m=>m.Changed += null, testData2);

        var items = clipboardFacade.History;

        Assert.Equal(2, items.Count);
        Assert.Equal("test data 2", items[0].Text);
        Assert.Equal("test data", items[1].Text);
    }

    [Fact]
    public void TestNoDuplicateItemOnSetCurrentValue()
    {
        var testData = new ClipboardData("test data");
        var dataProvider = new Mock<IClipboardDataProvider>();
        dataProvider.Setup(p => p.GetCurrentValue()).Returns(testData);
        dataProvider.Setup(p=>p.SetCurrentValue(It.IsAny<ClipboardData>()))
            .Raises(p => p.Changed += null, 
                new ClipboardData("test"));
        IClipboardFacade clipboardFacade = new ClipboardFacade(dataProvider.Object);

        dataProvider.Raise(m=>m.Changed += null, new ClipboardData("test data 2"));
        clipboardFacade.CurrentValue = new ClipboardData("test data 2");

        var items = clipboardFacade.History;

        Assert.Equal(2, items.Count);
    }
}