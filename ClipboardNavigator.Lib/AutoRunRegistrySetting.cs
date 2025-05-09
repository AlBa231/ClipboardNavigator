namespace ClipboardNavigator.Lib;

public class AutoRunRegistrySetting(string appPath, IRegistrySetting registrySetting)
{
    private readonly string appPath = appPath ?? throw new ArgumentNullException(nameof(appPath));
    private readonly IRegistrySetting registrySetting = registrySetting ?? throw new ArgumentNullException(nameof(registrySetting));

    public bool IsAutoStart
    {
        get => registrySetting.RunPath == appPath;
        set => UpdateRegistryValueIfChanged(value ? appPath : null);
    }

    private void UpdateRegistryValueIfChanged(string? path)
    {
        if (registrySetting.RunPath == path) return;
        registrySetting.RunPath = path;
    }
}