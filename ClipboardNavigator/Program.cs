using ClipboardNavigator.Code.Extensions;
using ClipboardNavigator.Lib.Plugins;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace ClipboardNavigator
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            InitLog();
            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((_, services) => ConfigureServices(services))
                .Build();
            Application.ThreadException += Application_ThreadException;
            host.Services.GetRequiredService<IPluginManager>().RunPlugins();
            Application.Run(host.Services.GetRequiredService<MainForm>());
            host.Services.GetRequiredService<IPluginManager>().StopAllServices().Wait();
        }

        private static IServiceCollection ConfigureServices(IServiceCollection services)
        {
            return services
                .AddAppServices()
                .AddPlugins()
                .AddForms();
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Log.Error(e.Exception, "Thread exception");
        }

        private static void InitLog()
        {
            new LoggerConfiguration()
                .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }
    }
}