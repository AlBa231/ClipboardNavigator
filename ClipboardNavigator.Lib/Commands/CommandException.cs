using ClipboardNavigator.Lib.Exceptions;

namespace ClipboardNavigator.Lib.Commands;

public class CommandException : AppException
{
    public CommandException()
    {
    }

    public CommandException(string? message) : base(message)
    {
    }

    public CommandException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}