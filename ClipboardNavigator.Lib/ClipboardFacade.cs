using System.ComponentModel;
using ClipboardNavigator.Lib.Notification;
using ClipboardNavigator.Lib.Scripts;

namespace ClipboardNavigator.Lib;

public class ClipboardFacade : IClipboardFacade
{
    private readonly IClipboardDataProvider clipboardDataProvider;
    public BindingList<ClipboardData> History { get; } = [];
    private bool ignoreDuplicates;
    private readonly IScriptFactory scriptFactory;
    private readonly INotificationService notificationService;

    public ClipboardData CurrentValue
    {
        get => clipboardDataProvider.GetCurrentValue();
        set
        {
            ignoreDuplicates = true;
            clipboardDataProvider.SetCurrentValue(value);
            ignoreDuplicates = false;
        }
    }

    public ClipboardFacade(IClipboardDataProvider clipboardDataProvider, INotificationService notificationService)
    {
        this.clipboardDataProvider = clipboardDataProvider ?? throw new ArgumentNullException(nameof(clipboardDataProvider));
        this.notificationService = notificationService;
        this.scriptFactory = new ScriptFactory(notificationService);
        this.clipboardDataProvider.Changed += ClipboardDataProvider_Changed;
        if (!string.IsNullOrWhiteSpace(CurrentValue?.Text))
            History.Add(CurrentValue);
    }

    private void ClipboardDataProvider_Changed(ClipboardData data)
    {
        scriptFactory.ProcessPostCopyHook(data);
        UpdateClipboardHistory(data);
    }

    private void UpdateClipboardHistory(ClipboardData data)
    {
        if (Equals(data, History.FirstOrDefault())) return;
        if (IsDuplicateItem(data)) return;

        History.Insert(0, data);
        if (History.Count > AppSettings.Instance.MaxHistoryItems)
            History.RemoveAt(History.Count - 1);
        if (AppSettings.Instance.DisplayNewDataNotification)
            notificationService.ShowBalloonText(data.Text);
    }

    private bool IsDuplicateItem(ClipboardData data)
    {
        return ignoreDuplicates || History.Contains(data);
    }
}

public interface IClipboardFacade
{
    public BindingList<ClipboardData> History { get; }

    public ClipboardData CurrentValue { get; set; }
}
