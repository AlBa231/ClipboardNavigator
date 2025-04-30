namespace ClipboardNavigator.Lib.Scripts;
public interface IScriptFactory
{
    public Task ProcessPostCopyHook(ClipboardData clipboardData);
}