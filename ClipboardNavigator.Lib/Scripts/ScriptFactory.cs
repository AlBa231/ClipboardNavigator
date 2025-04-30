using ClipboardNavigator.Lib.Notification;

namespace ClipboardNavigator.Lib.Scripts;

public class ScriptFactory : IScriptFactory
{
    private readonly INotificationService notificationService;

    public List<ClipboardScript> ClipboardScripts { get; }

    public ScriptFactory(INotificationService notificationService)
    {
        this.notificationService = notificationService;
        ClipboardScripts = InitScripts();
    }

    public async Task ProcessPostCopyHook(ClipboardData clipboardData)
    {
        var eventArgs = new ClipboardDataEventArgs(clipboardData);
        foreach (var clipboardScript in ClipboardScripts)
        {
            await clipboardScript.Execute(eventArgs);
            if (eventArgs.StopOtherScripts) break;
        }
    }

    private List<ClipboardScript> InitScripts()
    {
        var scripts = typeof(ScriptFactory).Assembly.GetTypes()
            .Where(type => typeof(ClipboardScript).IsAssignableFrom(type) && !type.IsAbstract)
            .Select(type => (ClipboardScript?)Activator.CreateInstance(type))
            .OfType<ClipboardScript>()
            .ToList();
        InitScripts(scripts);

        return scripts;
    }

    private void InitScripts(List<ClipboardScript> scripts)
    {
        foreach (var clipboardScript in scripts)
        {
            clipboardScript.NotificationService = notificationService;
        }
    }
}