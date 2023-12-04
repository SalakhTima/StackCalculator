namespace StackCalculator;

public class Postfix
{
    //private static readonly string[] Operators = { "(", ")", "+", "-", "/", "*", "^" };
    private const string Pattern = "()+-/*^";
    private static Stack<string> _operators = new();
    private static string _outputExpression = default!;

    public static string Parse(string exp)
    {
        var separatedElements = exp.Split(" ");
        var operators = new Stack<string>();
        var output = new List<string>();

        foreach (string elem in separatedElements)
        {
            if (!Pattern.Contains(elem))
            {
                output.Add(elem);
            }
            else if (elem == "(")
            {
                operators.Push(elem);
            }
            else if (elem == ")")
            {
                while (operators.Count > 0 && operators.Peek() != "(")
                {
                    output.Add(operators.Pop());
                }
                //if (operators.Count > 0 && operators.Peek() == "(")
                //{
                //    operators.Pop();
                //}
                operators.Pop();
            }
            else
            {
                if (operators.Count > 0 && DefinePriority(operators.Peek()) >= DefinePriority(elem))
                {   // was a 'while' loop
                    output.Add(operators.Pop());
                }
                operators.Push(elem);
            }
        }

        while (operators.Count > 0)
        {
            output.Add(operators.Pop());
        }

        return string.Join(" ", output);
    }

    private static int DefinePriority(string op) => op switch
    {
        "(" or ")" => 4,
        "^" => 3,
        "*" or "/" => 2,
        "+" or "-" => 1,
        _ => throw new ArgumentOutOfRangeException(nameof(op))
    };
}