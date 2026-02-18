using ClipboardNavigator.Lib.Commands;
using ClipboardNavigator.Tests.LibTestImplementation;

namespace ClipboardNavigator.Tests;

public class ClipboardCommandFactoryTests
{
    [Fact]
    public void TestRegisterCommand()
    {
        // Arrange
        var command = Mock.Of<IClipboardCommand>();
        var hotkeyProvider = Mock.Of<IHotkeyManager>();
        var factory = new ClipboardCommandFactory(hotkeyProvider);

        // Act
        factory.RegisterCommand(new TestHotKey("Ctrl+Alt+W"), command);
        var commandFound = factory.FindCommand(new TestHotKey("Ctrl+Alt+W"));

        // Assert
        Assert.NotNull(commandFound);
        Assert.Equal(command, commandFound);
        Mock.Get(hotkeyProvider).Verify(x => x.RegisterHotKey(It.IsAny<TestHotKey>()), Times.Once);
    }

    [Fact]
    public void TestRegisterDuplicateCommand()
    {
        // Arrange
        var command = Mock.Of<IClipboardCommand>();
        var command2 = Mock.Of<IClipboardCommand>();
        var hotkeyProvider = Mock.Of<IHotkeyManager>();
        var factory = new ClipboardCommandFactory(hotkeyProvider);

        // Act
        factory.RegisterCommand(new TestHotKey("Ctrl+Alt+W"), command);

        // Assert
        Assert.Throws<CommandException>(() =>
            factory.RegisterCommand(new TestHotKey("Ctrl+Alt+W"), command2));
        Mock.Get(hotkeyProvider).Verify(x => x.RegisterHotKey(It.IsAny<TestHotKey>()), Times.Once);
        Mock.Get(hotkeyProvider).VerifyNoOtherCalls();
    }

    [Fact]
    public void ExecuteCommand_ExistingCommand_ShouldRunExecute()
    {
        // Arrange
        var command = Mock.Of<IClipboardCommand>();
        var hotkeyProvider = Mock.Of<IHotkeyManager>();
        var factory = new ClipboardCommandFactory(hotkeyProvider);
        var hotkey = new TestHotKey("Ctrl+Alt+W");
        factory.RegisterCommand(hotkey, command);

        // Act
        factory.ExecuteCommand(hotkey);

        // Assert
        Mock.Get(command).Verify(x => x.Execute(), Times.Once);
    }

    [Fact]
    public void ExecuteCommand_OtherCommand_ShouldNotExecute()
    {
        // Arrange
        var command = Mock.Of<IClipboardCommand>();
        var hotkeyProvider = Mock.Of<IHotkeyManager>();
        var factory = new ClipboardCommandFactory(hotkeyProvider);
        var hotkey = new TestHotKey("Ctrl+Alt+W");
        factory.RegisterCommand(hotkey, command);

        // Act
        factory.ExecuteCommand(new TestHotKey("Ctrl+Alt+Q"));

        // Assert
        Mock.Get(command).Verify(x => x.Execute(), Times.Never);
    }

    [Fact]
    public void ExecuteCommand_NullCommand_ShouldNotExecute()
    {
        // Arrange
        var command = Mock.Of<IClipboardCommand>();
        var hotkeyProvider = Mock.Of<IHotkeyManager>();
        var factory = new ClipboardCommandFactory(hotkeyProvider);
        var hotkey = new TestHotKey("Ctrl+Alt+W");
        factory.RegisterCommand(hotkey, command);

        // Act
        factory.ExecuteCommand(null);

        // Assert
        Mock.Get(command).Verify(x => x.Execute(), Times.Never);
    }
}
