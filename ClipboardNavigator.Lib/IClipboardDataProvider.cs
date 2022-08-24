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
        void SetCurrentValue(ClipboardData value);
    }
}
