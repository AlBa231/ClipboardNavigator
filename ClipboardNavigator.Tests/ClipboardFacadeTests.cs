using Moq;

namespace ClipboardNavigator.Tests
{
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
    }
}
