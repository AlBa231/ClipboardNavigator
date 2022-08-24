using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WK.Libraries.SharpClipboardNS;

namespace ClipboardNavigator.Lib
{
    public class WindowsClipboardDataProvider : IClipboardDataProvider
    {
        private readonly SharpClipboard clipboard = new();

        public WindowsClipboardDataProvider()
        {
            clipboard.ClipboardChanged += Clipboard_ClipboardChanged;
        }

        private void Clipboard_ClipboardChanged(object? sender, SharpClipboard.ClipboardChangedEventArgs e)
        {
            
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
