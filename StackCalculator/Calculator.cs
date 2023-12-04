using StackCalculator.CoreMath;
using StackCalculator.Exceptions;
using StackCalculator.Factories;

namespace StackCalculator;

public static class Calculator
{
    public static double Calculate(string postfix)
    {
        var elements = postfix.Split(" ");
        IsCorrectFormat(elements);
        var stack = new Stack<double>();

        foreach (string element in elements)
        {
            if (!Operator.IsOperator(element))
            {
                stack.Push(double.Parse(element/*, CultureInfo.InvariantCulture*/));
            }
            else
            {
                var rightOperand = stack.Pop();
                var leftOperand = stack.Pop();

                var command = CommandFactory.GetCommand(element);
                stack.Push(command.Execute(leftOperand, rightOperand));
            }
        }

        return stack.Pop();
    }

    private static void IsCorrectFormat(string[] elements)
    {
        foreach (string element in elements)
        {
            if (element.Contains('.'))
                throw new IncorrectFormatException("Should contain ',' instead '.'.", element);
        }
    }
}