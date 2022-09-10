using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClipboardNavigator.Lib.Commands
{
    public class ClipboardCommandFactory
    {
        public static ClipboardCommandFactory Instance { get; } = new();

        private readonly Dictionary<Keys[], IClipboardCommand> commands = new();

        private ClipboardCommandFactory() { }

        public void RegisterCommand(Keys[] hotKey, IClipboardCommand command)
        {
            var orderedKeys = hotKey.OrderBy(k => k).ToArray();
            commands.Add(orderedKeys, command);
        }

        public IClipboardCommand? FindCommand(Keys[] hotKey)
        {
            var orderedKeys = hotKey.OrderBy(k => k).ToArray();

            return commands.GetValueOrDefault(orderedKeys);
        }
    }

    public class CommandException : Exception
    {
        public CommandException()
        {
        }

        public CommandException(string? message) : base(message)
        {
        }
    }
}
