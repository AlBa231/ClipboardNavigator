using System.Windows.Forms;
using WK.Libraries.SharpClipboardNS;

namespace ClipboardNavigator.Lib
{
    public class WindowsClipboardDataProvider : IClipboardDataProvider
    {
        private readonly SharpClipboard clipboard = new();

        public event ClipboardDataChanged? Changed;

        public WindowsClipboardDataProvider()
        {
            clipboard.ClipboardChanged += Clipboard_ClipboardChanged;
        }

        private void Clipboard_ClipboardChanged(object? sender, SharpClipboard.ClipboardChangedEventArgs e)
        {
            if (e.ContentType == SharpClipboard.ContentTypes.Text)
                Changed?.Invoke(new ClipboardData((string)e.Content));
        }

        public ClipboardData GetCurrentValue()
        {
            return new ClipboardData(this.clipboard.ClipboardText);
        }

        public void SetCurrentValue(ClipboardData value)
        {
            Clipboard.SetText(value.Text);
        }
    }
}
