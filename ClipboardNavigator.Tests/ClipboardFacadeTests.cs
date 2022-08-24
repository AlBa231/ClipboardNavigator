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

            var items = clipboardFacade.GetLastData();

            Assert.Single(items);
            Assert.Equal("test data", items[0].Text);
        }
    }
}
