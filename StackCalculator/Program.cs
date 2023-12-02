
namespace StackCalculator;

public class Program
{
    private static void Main()
    {
        string infixExp = "8+4*6-5/2"; //84+6*5-2/

        Console.WriteLine(InfixToPostfix(infixExp));

        
    }

    private static int Calculate(string postfixExp) 
    {
        int container = 0;
        var stack = new Stack<int>();

        foreach (char s in postfixExp)
        {
            if (!IsMathOperator(s))
            {
                stack.Push(s);
            }
            else
            {
                int statement = 
            }
        }
    }

    private static string InfixToPostfix(string infix)
    {
        var postfix = new List<char>();
        var stack = new Stack<char>();

        foreach (char s in infix)
        {
            if (IsMathOperator(s))
            {
                if (stack.Count != 0)
                {
                    postfix.Add(stack.Pop());
                }
                stack.Push(s);
            }
            else
            {
                postfix.Add(s);
            }
        }

        while (stack.Count != 0)
        {
            postfix.Add(stack.Pop());
        }

        return new string(postfix.ToArray());
    }

    private static bool IsMathOperator(char symbol)
    {
        char[] mathOperators = { '+', '-', '/', '*' };
        return mathOperators.Contains(symbol);
    }
}