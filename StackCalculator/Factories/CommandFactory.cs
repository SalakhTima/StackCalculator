using StackCalculator.Domain;

namespace StackCalculator.Factories;

public static class CommandFactory
{
    public static ICommand GetCommand(string token) => token switch
    {
        "^" => new Exponentiation(),
        "*" => new Multiply(),
        "/" => new Division(),
        "+" => new Addition(),
        "-" => new Subtraction(),
        _ => throw new ArgumentOutOfRangeException(nameof(token))
    };
}