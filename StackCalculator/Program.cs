using System.Text;

namespace StackCalculator;

public class Program
{
    private const int LeftAssociative = 0;
    private const int RightAssociative = 1;
    private static readonly Dictionary<string, Operator> Operators = new();

    private static void Main(string[] args)
    {
        //var infixString = "3.005 + 4 * 2 / ( 1 - 5 ) ^ 2";

        //InitializeOperators();
        //string output = GetRPN(infixString);
        //Console.WriteLine(output);

        var infixString = "3.005 + 4 * 2 / ( 1 - 5 ) ^ 2";
        string output = Postfix.Parse(infixString);
        Console.WriteLine(output);
    }

    private static void InitializeOperators()
    {
        Operators.Add("^", new Operator { Token = "^", Associativity = RightAssociative, Precedence = 2 });
        Operators.Add("%", new Operator { Token = "%", Associativity = LeftAssociative, Precedence = 1 });
        Operators.Add("/", new Operator { Token = "/", Associativity = LeftAssociative, Precedence = 1 });
        Operators.Add("*", new Operator { Token = "*", Associativity = LeftAssociative, Precedence = 1 });
        Operators.Add("-", new Operator { Token = "-", Associativity = LeftAssociative, Precedence = 0 });
        Operators.Add("+", new Operator { Token = "+", Associativity = LeftAssociative, Precedence = 0 });
    }

    private static bool isOperator(string token)
    {
        return Operators.ContainsKey(token);
    }

    private static string GetRPN(string exp)
    {
        string[] elements = exp.Split(" ");
        var operators = new Stack<string>();
        var output = new StringBuilder();

        foreach (string elem in elements)
        {
            switch (elem)
            {
                case "(":
                    operators.Push(elem);
                    break;
                case ")":
                {
                    for (int k = 0; k < operators.Count; k++)
                    {
                        if (operators.Peek() == "(")
                        {
                            operators.Pop();
                            break;
                        }

                        output.Append(operators.Pop() + " ");
                    }

                    break;
                }
                default:
                {
                    if (isOperator(elem))
                    {
                        while (operators.Count > 0 && isOperator(operators.Peek()))
                        {
                            string tokenAtTopOfStack = operators.Peek();

                            var token1 = elem;
                            Operator o1 = Operators.Values.First(opCode => opCode.Token.Equals(token1));
                            Operator o2 = Operators.Values.First(opCode => opCode.Token.Equals(tokenAtTopOfStack));

                            if ((o1.Associativity == LeftAssociative && o1.Precedence <= o2.Precedence) ||
                                (o1.Associativity == RightAssociative && o1.Precedence < o2.Precedence))
                            {
                                output.Append(operators.Pop() + " ");
                                continue;
                            }
                            break;
                        }
                        operators.Push(elem);
                    }
                    else
                    {
                        output.Append(elem + " ");
                    }
                    break;
                }
            }
        }

        if (operators.Count <= 0) return output.ToString();

        while (operators.Count > 0)
        {
            if (isOperator(operators.Peek()))
            {
                output.Append(operators.Pop() + " ");
            }
            else
            {
                operators.Pop();
            }
        }
        return output.ToString();
    }
}

public class Operator
{
    public required string Token { get; init; }
    public required int Associativity { get; init; }
    public required byte Precedence { get; init; }
}