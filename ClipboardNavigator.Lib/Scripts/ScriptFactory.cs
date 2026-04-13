using Microsoft.Extensions.DependencyInjection;

namespace ClipboardNavigator.Lib.Scripts;

public class ScriptFactory(IServiceProvider serviceProvider) : IScriptFactory
{
    public List<IClipboardScript> ClipboardScripts => field ??= InitScripts();

    public async Task ProcessPostCopyHook(ClipboardData clipboardData)
    {
        var eventArgs = new ClipboardDataEventArgs(clipboardData);
        foreach (IClipboardScript clipboardScript in ClipboardScripts)
        {
            await clipboardScript.Execute(eventArgs);
            if (eventArgs.StopOtherScripts) break;
        }
    }

    private List<IClipboardScript> InitScripts()
    {
        return serviceProvider.GetServices<IClipboardScript>().ToList();
    }
}
