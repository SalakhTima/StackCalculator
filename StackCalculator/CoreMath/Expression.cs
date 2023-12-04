using System.Text.RegularExpressions;

namespace StackCalculator.CoreMath;

public static class Expression
{
    private const string Pattern = @"^[0-9+\-*/^,() ]+$";

    public static string ToPostfix(string expression)
    {
        if (!IsExpressionValid(expression))
            throw new FormatException();

        var elements = expression.Split(" ");
        var operators = new Stack<string>();
        var postfix = new List<string>();

        foreach (string element in elements)
        {
            if (element == "(")
            {
                operators.Push(element);
            }
            else if (element == ")")
            {
                for (var k = 0; k < operators.Count; k++)
                {
                    if (operators.Peek() == "(")
                    {
                        operators.Pop();
                        break;
                    }
                    postfix.Add(operators.Pop());
                }
            }
            else
            {
                if (Operator.IsOperator(element))
                {
                    while (operators.Count > 0 && Operator.IsOperator(operators.Peek()))
                    {
                        var current = OperatorsContainer.Operators.First(op => op.Token == char.Parse(element));
                        var top = OperatorsContainer.Operators.First(op => op.Token == char.Parse(operators.Peek()));

                        if (current.IsLeftAssociative && current.Precedence <= top.Precedence ||
                            current.IsRightAssociative && current.Precedence < top.Precedence)
                        {
                            postfix.Add(operators.Pop());
                            continue;
                        }
                        break;
                    }
                    operators.Push(element);
                }
                else
                {
                    postfix.Add(element);
                }
            }
        }

        while (operators.Count > 0)
            postfix.Add(operators.Pop());

        return string.Join(" ", postfix);
    }

    public static bool IsExpressionValid(string expression) =>
        Regex.IsMatch(expression, Pattern) && expression.Length >= 5;
}