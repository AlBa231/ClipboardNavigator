using System.Reflection;

namespace ClipboardNavigator.Lib.Extensions;
public static class AssemblyExtensions
{
    public static IEnumerable<Type> GetTypesOf<T>(this Assembly assembly)
    {
        return assembly.GetTypes()
            .Where(t => t is { IsClass: true, IsAbstract: false } && typeof(T).IsAssignableFrom(t));
    }
}
