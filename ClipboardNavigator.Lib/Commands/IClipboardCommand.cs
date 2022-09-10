using System.Windows.Forms;

namespace ClipboardNavigator.Lib.Commands;

public interface IClipboardCommand
{
    public Keys[] Keys { get; }

    public void Execute();
}