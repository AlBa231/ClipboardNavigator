using ClipboardNavigator.Lib.Commands;
using ClipboardNavigator.Tests.LibTestImplementation;

namespace ClipboardNavigator.Tests;

public class ClipboardCommandFactoryTests
{
    [Fact]
    public void TestRegisterCommand()
    {
        var command = Mock.Of<IClipboardCommand>();
        var factory = new ClipboardCommandFactory();

        factory.RegisterCommand(new TestHotKey("Ctrl+Alt+W"), command);
        var commandFound = factory.FindCommand(new TestHotKey("Ctrl+Alt+W"));

        Assert.NotNull(commandFound);
        Assert.Equal(command, commandFound);
    }

    [Fact]
    public void TestRegisterDuplicateCommand()
    {
        var command = Mock.Of<IClipboardCommand>();
        var command2 = Mock.Of<IClipboardCommand>();
        var factory = new ClipboardCommandFactory();

        factory.RegisterCommand(new TestHotKey("Ctrl+Alt+W"), command);

        Assert.Throws<CommandException>(() =>
            factory.RegisterCommand(new TestHotKey("Ctrl+Alt+W"), command2));
    }
}
