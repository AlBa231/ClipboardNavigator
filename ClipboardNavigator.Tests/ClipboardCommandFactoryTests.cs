using System.Windows.Forms;
using ClipboardNavigator.Lib.Commands;
using Moq;

namespace ClipboardNavigator.Tests
{
    public class ClipboardCommandFactoryTests
    {
        [Fact]
        public void TestFindCommand()
        {
            var factory = ClipboardCommandFactory.Instance;

            var command = factory.FindCommand(new [] { Keys.Control, Keys.Shift, Keys.Alt, Keys.W });

            Assert.NotNull(command);
        }

        [Fact]
        public void TestRegisterCommand()
        {
            var command = Mock.Of<IClipboardCommand>();
            var factory = ClipboardCommandFactory.Instance;

            factory.RegisterCommand(new [] { Keys.Control, Keys.Alt, Keys.A }, command);
            var commandFound = factory.FindCommand(new [] { Keys.Control, Keys.Alt, Keys.A });

            Assert.NotNull(commandFound);
            Assert.Equal(command, commandFound);
        }

        [Fact]
        public void TestRegisterDuplicateCommand()
        {
            var command = Mock.Of<IClipboardCommand>();
            var command2 = Mock.Of<IClipboardCommand>();
            var factory = ClipboardCommandFactory.Instance;

            factory.RegisterCommand(new [] { Keys.Control, Keys.Alt, Keys.A }, command);

            Assert.Throws<CommandException>(() =>
                factory.RegisterCommand(new[] { Keys.Control, Keys.Alt, Keys.A }, command2));
        }
    }
}
