namespace StackCalculator.Domain;

public interface ICommand
{
    double Execute(double leftOperand, double rightOperand);
}