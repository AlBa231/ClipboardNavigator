using Microsoft.Extensions.DependencyInjection;

namespace ClipboardNavigator.Code.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddFactory<T>(this IServiceCollection services) where T : class
    {
        services.AddTransient<Func<T>>(sp => sp.GetRequiredService<T>);
        return services;
    }
}
