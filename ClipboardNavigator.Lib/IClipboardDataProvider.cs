using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClipboardNavigator.Lib
{
    public interface IClipboardDataProvider
    {
        public ClipboardData GetCurrentValue();
        public void SetCurrentValue(ClipboardData value);
        public event ClipboardDataChanged Changed;
    }

    public delegate void ClipboardDataChanged(ClipboardData data);
}
