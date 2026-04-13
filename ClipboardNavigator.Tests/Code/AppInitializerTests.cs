using ClipboardNavigator.Code;
using ClipboardNavigator.Lib.Commands;
using ClipboardNavigator.Lib.Notification;
using ClipboardNavigator.Lib.Plugins;
using ClipboardNavigator.Lib.Windows;

namespace ClipboardNavigator.Tests.Code;

public class AppInitializerTests
{
    private readonly IWindowService _windowService = Mock.Of<IWindowService>();
    private readonly Mock<IClipboardDataProvider> _dataProviderMock = new();
    private readonly Mock<IClipboardFacade> _clipboardFacadeMock = new();
    private readonly Mock<IMainForm> _mainFormMock = new();
    private readonly Mock<IHotkeyManager> _hotkeyManagerMock = new();
    private readonly Mock<IClipboardListBox> _mainListBoxMock = new();
    private readonly Mock<INotificationService> _notificationServiceMock = new();

    public AppInitializerTests()
    {
        _dataProviderMock.Setup(x => x.GetCurrentValue()).Returns(new ClipboardData("test data"));
        _mainFormMock.Setup(x => x.MainListBox).Returns(_mainListBoxMock.Object);
        _clipboardFacadeMock.Setup(x => x.History).Returns([]);
    }

    [Fact]
    public void Initialize_ShouldRunPlugins()
    {
        // Arrange
        var pluginManagerMock = new Mock<IPluginManager>();
        var commandFactoryMock = new Mock<IClipboardCommandFactory>();
        var appInitializer = new AppInitializer(_dataProviderMock.Object, _clipboardFacadeMock.Object, pluginManagerMock.Object, commandFactoryMock.Object, _hotkeyManagerMock.Object, _notificationServiceMock.Object, _windowService);
        pluginManagerMock.Setup(x => x.PluginFactory.Plugins).Returns([]);

        // Act
        appInitializer.Initialize(_mainFormMock.Object);

        // Asser
        pluginManagerMock.VerifyAll();
        pluginManagerMock.Verify(x=>x.StartPlugins(), Times.Once);
        pluginManagerMock.VerifyNoOtherCalls();
    }

    [Fact]
    public void Dispose_ShouldStopPlugins()
    {
        // Arrange
        var pluginManagerMock = new Mock<IPluginManager>();
        var commandFactoryMock = new Mock<IClipboardCommandFactory>();
        var appInitializer = new AppInitializer(_dataProviderMock.Object, _clipboardFacadeMock.Object, pluginManagerMock.Object, commandFactoryMock.Object, _hotkeyManagerMock.Object, _notificationServiceMock.Object, _windowService);

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
        var appInitializer = new AppInitializer(_dataProviderMock.Object, _clipboardFacadeMock.Object, pluginManagerMock.Object, commandFactoryMock.Object, _hotkeyManagerMock.Object, _notificationServiceMock.Object, _windowService);

        pluginManagerMock.Setup(x => x.PluginFactory.Plugins).Returns([]);

        // Act
        appInitializer.Initialize(_mainFormMock.Object);

        // Asser
        commandFactoryMock.Verify(x => x.RegisterCommand(It.IsAny<IHotKey>(), It.IsAny<IClipboardCommand>()), Times.AtLeastOnce);
        commandFactoryMock.VerifyNoOtherCalls();
    }
}
