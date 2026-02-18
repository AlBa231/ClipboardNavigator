using ClipboardNavigator.Lib;
using ClipboardNavigator.Lib.Commands;
using ClipboardNavigator.Lib.Windows;

namespace ClipboardNavigator.LibWin.Commands.Impl;

public class ShowPluginsCommand(IWindowService windowService):IClipboardCommand
{
    public void Execute()
    {
        windowService.ShowPluginsDialog();
    }
}
