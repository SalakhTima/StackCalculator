namespace StackCalculator.Exceptions;

internal class IncorrectFormatException : Exception
{
    public string Element { get; } = null!;
    public IncorrectFormatException() { }
    public IncorrectFormatException(string message) : base(message) { }
    public IncorrectFormatException(string message, string element) : base(message)
    {
        Element = element;
    }
}