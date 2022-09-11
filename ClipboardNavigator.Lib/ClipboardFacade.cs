using System.ComponentModel;

namespace ClipboardNavigator.Lib
{
    public class ClipboardFacade : IClipboardFacade
    {
        private readonly IClipboardDataProvider clipboardDataProvider;
        public BindingList<ClipboardData> History { get; } = new();

        public ClipboardData CurrentValue
        {
            get => clipboardDataProvider.GetCurrentValue();
            set => clipboardDataProvider.SetCurrentValue(value);
        }

        public ClipboardFacade(IClipboardDataProvider clipboardDataProvider)
        {
            this.clipboardDataProvider = clipboardDataProvider ?? throw new ArgumentNullException(nameof(clipboardDataProvider));
            this.clipboardDataProvider.Changed += ClipboardDataProvider_Changed;
            if (!string.IsNullOrWhiteSpace(CurrentValue?.Text))
                History.Add(CurrentValue);
        }

        private void ClipboardDataProvider_Changed(ClipboardData data)
        {
            if (Equals(data, History.FirstOrDefault())) return;

           History.Insert(0, data);
        }
    }

    public interface IClipboardFacade
    {
        public BindingList<ClipboardData> History { get; }

        public ClipboardData CurrentValue { get; set; }
    }
}
