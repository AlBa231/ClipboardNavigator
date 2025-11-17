namespace ClipboardNavigator.Lib.Plugins;
public interface IPlugin
{
    string Name { get; }

    RunState State { get; set; }
}