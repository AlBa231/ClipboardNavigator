using System.Reflection;
using ClipboardNavigator.Lib.Commands;
using ClipboardNavigator.Lib.Extensions;
using ClipboardNavigator.Lib.Plugins;
using ClipboardNavigator.Lib.Plugins.BackgroundServices;
using ClipboardNavigator.Lib.Plugins.Interfaces;
using ClipboardNavigator.Lib.Windows;
using ClipboardNavigator.LibWin.Plugins.BackgroundServices;
using ClipboardNavigator.LibWin.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace ClipboardNavigator.Code.Extensions;

internal static class ServiceProviderExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddAppServices()
        {
            services.AddSingleton<IIdleTimeService, IdleTimeServiceWindows>();
            services.AddSingleton<IPluginFactory, PluginFactory>();
            services.AddSingleton<IPluginManager, PluginManager>();
            services.AddSingleton<IClipboardCommandFactory, ClipboardCommandFactory>();
            services.AddSingleton<IWindowService, WindowService>();
            services.AddSingleton<AppInitializer>();
            return services;
        }

        public IServiceCollection AddForms()
        {
            foreach (Type type in GetAssemblyWithForms().SelectMany(a=>a.GetTypesOf<Form>()))
            {
                services.AddTransient(type);
            }
            return services;
        }

        public IServiceCollection AddPlugins()
        {
            foreach (Type type in typeof(IPlugin).Assembly.GetTypesOf<IPlugin>())
            {
                services.AddTransient(type);
            }
            return services;
        }
    }

    private static IEnumerable<Assembly> GetAssemblyWithForms() =>
    [
        Assembly.GetAssembly(typeof(MainForm))!,
        Assembly.GetAssembly(typeof(WindowService))!
    ];
}
