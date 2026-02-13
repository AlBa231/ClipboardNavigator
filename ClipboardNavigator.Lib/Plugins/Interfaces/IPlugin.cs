namespace ClipboardNavigator.Lib.Plugins.Interfaces;
public interface IPlugin
{
    string Name { get; }

    RunState State { get; set; }
}