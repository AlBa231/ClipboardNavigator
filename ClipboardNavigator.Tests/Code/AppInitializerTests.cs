using ClipboardNavigator.Code;
using ClipboardNavigator.Lib.Commands;
using ClipboardNavigator.Lib.Plugins;
using ClipboardNavigator.Lib.Windows;

namespace ClipboardNavigator.Tests.Code;

public class AppInitializerTests
{
    private readonly IWindowService _windowService = Mock.Of<IWindowService>();

    [Fact]
    public void Initialize_ShouldRunPlugins()
    {
        // Arrange
        var pluginManagerMock = new Mock<IPluginManager>();
        var commandFactoryMock = new Mock<IClipboardCommandFactory>();
        var appInitializer = new AppInitializer(pluginManagerMock.Object, commandFactoryMock.Object, _windowService);

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
        var appInitializer = new AppInitializer(pluginManagerMock.Object, commandFactoryMock.Object, _windowService);

        // Act
        appInitializer.Dispose();

        // Asser
        pluginManagerMock.Verify(x=>x.StopAllServices(), Times.Once);
        pluginManagerMock.VerifyNoOtherCalls();
    }

    [Fact]
    public void Initialize_ShouldRegisterCommands()
    {
        // Arrange
        var pluginManagerMock = new Mock<IPluginManager>();
        var commandFactoryMock = new Mock<IClipboardCommandFactory>();
        var appInitializer = new AppInitializer(pluginManagerMock.Object, commandFactoryMock.Object, _windowService);

        // Act
        appInitializer.Initialize();

        // Asser
        commandFactoryMock.Verify(x => x.RegisterCommand(It.IsAny<IHotKey>(), It.IsAny<IClipboardCommand>()), Times.AtLeastOnce);
        commandFactoryMock.VerifyNoOtherCalls();
    }
}
