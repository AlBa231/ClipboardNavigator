using System.Reflection;
using ClipboardNavigator.Lib.Plugins.BackgroundServices;
using ClipboardNavigator.Lib.Plugins.Interfaces;
using ClipboardNavigator.LibWin.Plugins.BackgroundServices;
using Microsoft.Extensions.DependencyInjection;
using ClipboardNavigator.Lib.Extensions;
using ClipboardNavigator.Lib.Plugins;
using ClipboardNavigator.Lib.Windows;
using ClipboardNavigator.LibWin.Windows;

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
            services.AddSingleton<IWindowService, WindowService>();
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
