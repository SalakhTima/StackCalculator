namespace StackCalculator.Domain;

public class Subtraction : ICommand
{
    public double Execute(double leftOperand, double rightOperand) => leftOperand - rightOperand;
}