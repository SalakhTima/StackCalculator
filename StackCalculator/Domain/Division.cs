namespace StackCalculator.Domain;

public class Division : ICommand
{
    public double Execute(double leftOperand, double rightOperand)
    {
        var result = leftOperand / rightOperand;
        return double.IsInfinity(result) ? default : result;
    }
}