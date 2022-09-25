namespace ClipboardNavigator.Lib;

public class AutoRunRegistrySetting
{
    private readonly string appPath;
    private readonly IRegistrySetting registrySetting;

    public AutoRunRegistrySetting(string appPath, IRegistrySetting registrySetting)
    {
        this.appPath = appPath ?? throw new ArgumentNullException(nameof(appPath));
        this.registrySetting = registrySetting ?? throw new ArgumentNullException(nameof(registrySetting));
    }

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