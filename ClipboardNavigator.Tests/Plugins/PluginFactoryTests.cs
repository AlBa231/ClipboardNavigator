using ClipboardNavigator.Lib.Plugins;
using ClipboardNavigator.Lib.Plugins.BackgroundServices;

namespace ClipboardNavigator.Tests.Plugins;
public class PluginFactoryTests
{
    [Fact]
    public void GetPlugin_ShouldReturnCorrectPluginInstance()
    {
        // Arrange
        var serviceProvider = Mock.Of<IServiceProvider>(x => x.GetService(typeof(IIdleTimeService)) == Mock.Of<IIdleTimeService>()
            && x.GetService(typeof(ActivityKeeperPlugin)) == new ActivityKeeperPlugin(Mock.Of<IIdleTimeService>())
            && x.GetService(typeof(TestBackgroundService)) == new TestBackgroundService());
        var factory = new PluginFactory(serviceProvider);

        // Act
        var plugin = factory.GetPlugin<ActivityKeeperPlugin>();

        // Assert
        Assert.NotNull(plugin);
        Assert.IsType<ActivityKeeperPlugin>(plugin);
    }
}
