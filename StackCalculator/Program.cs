using StackCalculator.Converter;

namespace StackCalculator;

public class Program
{
    private static void Main()
    {
        var infix = "2.5 - 9,0012 * 12 + ( 14,012 - 18 ) * 8";

        var postfix = Expression.ToPostfix(infix);

        var result = Calculator.Calculate(postfix);

        Console.WriteLine(result);
    }
}