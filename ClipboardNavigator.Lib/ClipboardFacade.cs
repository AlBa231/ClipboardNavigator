using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClipboardNavigator.Lib
{
    public class ClipboardFacade : IClipboardFacade
    {
        private readonly IClipboardDataProvider clipboardDataProvider;
        private BindingList<ClipboardData> History { get; set; } = new();

        public ClipboardData CurrentValue
        {
            get => clipboardDataProvider.GetCurrentValue();
            set => clipboardDataProvider.SetCurrentValue(value);
        }

        public ClipboardFacade(IClipboardDataProvider clipboardDataProvider)
        {
            this.clipboardDataProvider = clipboardDataProvider ?? throw new ArgumentNullException(nameof(clipboardDataProvider));
        }

        public BindingList<ClipboardData> GetLastData()
        {
            if (!Equals(CurrentValue, History.FirstOrDefault()))
                History.Insert(0, CurrentValue);
            return History;
        }
    }

    public interface IClipboardFacade
    {
        public BindingList<ClipboardData> GetLastData();

        public ClipboardData CurrentValue { get; set; }
    }
}
