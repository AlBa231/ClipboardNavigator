using ClipboardNavigator.Lib.Extensions;
using ClipboardNavigator.Lib.Plugins;
using ClipboardNavigator.Lib.Plugins.BackgroundServices;
using ClipboardNavigator.LibWin.Plugins.BackgroundServices;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace ClipboardNavigator
{
    internal static class Program
    {
        private static PluginManager? pluginManager;

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
            InitPlugins();
            Application.ThreadException += Application_ThreadException;
            Application.Run(new MainForm());
            pluginManager?.StopAllServices().Wait();
        }

        private static void InitPlugins()
        {
            IServiceProvider serviceProvider = InitServices();
            pluginManager = new PluginManager(new PluginFactory(serviceProvider));
            Task.Run(pluginManager.RunPlugins);
        }

        private static IServiceProvider InitServices()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddSingleton<IIdleTimeService, IdleTimeServiceWindows>();
            foreach (Type type in typeof(IPlugin).Assembly.GetTypesOf<IPlugin>())
            {
                serviceCollection.AddTransient(type);
            }

            return serviceCollection.BuildServiceProvider();
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