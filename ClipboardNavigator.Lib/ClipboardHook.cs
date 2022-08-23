namespace ClipboardNavigator.Lib
{
    public sealed class ClipboardHook
    {
        private static ClipboardHook? instance;

        public static ClipboardHook Instance => instance ??= new ClipboardHook();

        private ClipboardHook()
        {
        }

        public event EventHandler<ClipboardDataEventArgs>? ReceiveData;

        public void AddData(ClipboardData data)
        {
            ReceiveData?.Invoke(this, new ClipboardDataEventArgs(data));
        }
    }
}