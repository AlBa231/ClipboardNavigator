using ClipboardNavigator.Code;
using ClipboardNavigator.Code.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace ClipboardNavigator;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        using IHost host = Host.CreateDefaultBuilder()
            .UseSerilog()
            .ConfigureServices((_, services) => ConfigureServices(services))
            .Build();
        Application.ThreadException += Application_ThreadException;
        Application.Run(host.Services.GetRequiredService<MainForm>());
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services
            .AddControls()
            .AddAppServices()
            .AddPlugins();
    }

    private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
    {
        Log.Error(e.Exception, "Thread exception");
    }
}
