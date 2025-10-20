using ClipboardNavigator.Lib.Plugins;

namespace ClipboardNavigator.Tests.Plugins;
public class PluginManagerTests
{
    [Fact]
    public async Task StopAllServices_ShouldCancelBackgroundServiceTasks()
    {
        // Arrange
        var testPlugin = new TestBackgroundService();
        var pluginFactory = Mock.Of<IPluginFactory>(p => p.Plugins == new List<IPlugin> { testPlugin });
        var pluginManager = new PluginManager(pluginFactory);

        // Act
        pluginManager.RunPlugins();
        await Task.Delay(10);
        await pluginManager.StopAllServices();

        // Assert
        Assert.True(testPlugin.TaskRunCount > 1);
    }
}