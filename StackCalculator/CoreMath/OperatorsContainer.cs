namespace StackCalculator.CoreMath;

public static class OperatorsContainer
{
    public static List<Operator> Operators { get; } = new()
    {
        new Operator { Token = '^', Precedence = 2, IsLeftAssociative = false, IsRightAssociative = true },
        new Operator { Token = '/', Precedence = 1, IsLeftAssociative = true, IsRightAssociative = false },
        new Operator { Token = '*', Precedence = 1, IsLeftAssociative = true, IsRightAssociative = false },
        new Operator { Token = '-', Precedence = 0, IsLeftAssociative = true, IsRightAssociative = false },
        new Operator { Token = '+', Precedence = 0, IsLeftAssociative = true, IsRightAssociative = false }
    };
}