using ClipboardNavigator.Lib.Plugins;
using ClipboardNavigator.Lib.Plugins.Interfaces;

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

    [Fact]
    public async Task Pause_ValidService_ShouldPauseAction()
    {
        // Arrange
        var testPlugin = new TestBackgroundService();
        var pluginFactory = Mock.Of<IPluginFactory>(p => p.Plugins == new List<IPlugin> { testPlugin });
        var pluginManager = new PluginManager(pluginFactory);

        // Act
        testPlugin.State = RunState.Paused;
        pluginManager.RunPlugins();
        await Task.Delay(10);
        await pluginManager.StopAllServices();

        // Assert
        Assert.Equal(0, testPlugin.TaskRunCount);
    }
}