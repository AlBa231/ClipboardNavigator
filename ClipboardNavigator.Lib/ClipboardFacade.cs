using System.ComponentModel;
using ClipboardNavigator.Lib.Commands;
using ClipboardNavigator.Lib.Notification;
using ClipboardNavigator.Lib.Scripts;

namespace ClipboardNavigator.Lib;

public class ClipboardFacade(
    IScriptFactory scriptFactory,
    IHotkeyManager hotkeyManager,
    IClipboardCommandFactory commandFactory,
    INotificationService notificationService)
    : IClipboardFacade
{
    public BindingList<ClipboardData> History { get; } = [];

    public void FindAndExecuteCommand(int hotkeyId)
    {
        IHotKey? command = hotkeyManager.FindHotkeyById(hotkeyId);
        commandFactory.ExecuteCommand(command);
    }

    public void ProcessNewClipboardData(ClipboardData data)
    {
        scriptFactory.ProcessPostCopyHook(data);
        UpdateClipboardHistory(data);
    }

    private void UpdateClipboardHistory(ClipboardData data)
    {
        if (string.IsNullOrEmpty(data.Text)) return;
        if (Equals(data, History.FirstOrDefault())) return;

        History.Insert(0, data);
        if (History.Count > AppSettings.Instance.MaxHistoryItems)
            History.RemoveAt(History.Count - 1);
        if (AppSettings.Instance.DisplayNewDataNotification)
            notificationService.ShowBalloonText(data.Text);
    }
}
