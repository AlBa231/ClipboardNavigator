using System.Reflection;
using ClipboardNavigator.Code.Windows;
using ClipboardNavigator.Code.Windows.Forms.Plugins;
using ClipboardNavigator.Lib.Commands;
using ClipboardNavigator.Lib.Extensions;
using ClipboardNavigator.Lib.Plugins;
using ClipboardNavigator.Lib.Plugins.BackgroundServices;
using ClipboardNavigator.Lib.Plugins.Interfaces;
using ClipboardNavigator.Lib.Windows;
using ClipboardNavigator.LibWin.Commands;
using ClipboardNavigator.LibWin.Plugins.BackgroundServices;
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
            services.AddSingleton<IHotkeyManager, HotkeyManager>();
            services.AddSingleton<IClipboardCommandFactory, ClipboardCommandFactory>();
            services.AddSingleton<IWindowService, WindowService>();
            services.AddSingleton<AppInitializer>();
            return services;
        }

        public IServiceCollection AddControls()
        {
            foreach (Type type in GetAssemblyWithUiComponents().SelectMany(a=>a.GetTypesOf<Control>()))
            {
                services.AddTransient(type);
            }
            services.AddFactory<PluginRowControl>();
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

    private static IEnumerable<Assembly> GetAssemblyWithUiComponents() =>
    [
        Assembly.GetAssembly(typeof(MainForm))!,
        Assembly.GetAssembly(typeof(WindowService))!
    ];
}
