using ClipboardNavigator.Lib.Commands;
using ClipboardNavigator.Lib.Notification;
using ClipboardNavigator.Lib.Scripts;

namespace ClipboardNavigator.Tests;

public class ClipboardFacadeTests
{
    private readonly Mock<INotificationService> _notificationServiceMock = new();
    private readonly Mock<IScriptFactory> _scriptFactoryMock = new();
    private readonly Mock<IHotkeyManager> _hotkeyManagerMock = new();
    private readonly Mock<IClipboardCommandFactory> _commandFactoryMock = new();

    [Fact]
    public void TestClipboardFacadeGetItems()
    {
        // Arrange
        IClipboardFacade clipboardFacade = new ClipboardFacade(_scriptFactoryMock.Object, _hotkeyManagerMock.Object,
            _commandFactoryMock.Object, _notificationServiceMock.Object);

        // Act
        clipboardFacade.ProcessNewClipboardData(new ClipboardData("test data"));
        var items = clipboardFacade.History;

        // Assert
        Assert.Single(items);
        Assert.Equal("test data", items[0].Text);
    }
}
