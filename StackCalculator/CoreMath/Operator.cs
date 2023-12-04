namespace StackCalculator.CoreMath;

public class Operator
{
    public required char Token { get; init; }
    public required byte Precedence { get; init; }
    public required bool IsLeftAssociative { get; init; }
    public required bool IsRightAssociative { get; init; }
    public static bool IsOperator(string element) => element.Length == 1 && "+-*/^".Contains(element);
}