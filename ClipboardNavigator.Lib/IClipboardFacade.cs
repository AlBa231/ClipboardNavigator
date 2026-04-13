using System.ComponentModel;

namespace ClipboardNavigator.Lib;

public interface IClipboardFacade
{
    public BindingList<ClipboardData> History { get; }
    public void FindAndExecuteCommand(int hotkeyId);
    void ProcessNewClipboardData(ClipboardData data);
}
