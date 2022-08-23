using ClipboardNavigator.Lib;

namespace ClipboardNavigator.Tests
{
    public class ClipboardTests
    {
        [Fact]
        public void TestClipboardHookReceived()
        {
            var data = new ClipboardData { Text = "test" };

            var evt = Assert.Raises<ClipboardDataEventArgs>(
                h => ClipboardHook.Instance.ReceiveData += h,
                h => ClipboardHook.Instance.ReceiveData -= h,
                () => ClipboardHook.Instance.AddData(data)
            );
            

        }
    }
}