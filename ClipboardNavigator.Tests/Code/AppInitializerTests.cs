using ClipboardNavigator.Code;
using ClipboardNavigator.Lib.Commands;
using ClipboardNavigator.Lib.Plugins;

namespace ClipboardNavigator.Tests.Code;

public class AppInitializerTests
{
    [Fact]
    public void Initialize_ShouldRunPlugins()
    {
        // Arrange
        var pluginManagerMock = new Mock<IPluginManager>();
        var commandFactoryMock = new Mock<IClipboardCommandFactory>();
        var appInitializer = new AppInitializer(pluginManagerMock.Object, commandFactoryMock.Object);

        // Act
        appInitializer.Initialize();

        // Asser
        pluginManagerMock.Verify(x=>x.RunPlugins(), Times.Once);
        pluginManagerMock.VerifyNoOtherCalls();
    }

    [Fact]
    public void Dispose_ShouldStopPlugins()
    {
        // Arrange
        var pluginManagerMock = new Mock<IPluginManager>();
        var commandFactoryMock = new Mock<IClipboardCommandFactory>();
        var appInitializer = new AppInitializer(pluginManagerMock.Object, commandFactoryMock.Object);

        // Act
        appInitializer.Dispose();

        // Asser
        pluginManagerMock.Verify(x=>x.StopAllServices(), Times.Once);
        pluginManagerMock.VerifyNoOtherCalls();
    }
}
