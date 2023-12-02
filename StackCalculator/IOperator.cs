namespace StackCalculator;

public interface IOperator
{
    char Operator { get; }
    double Calculate(double leftOp, double rightOp); 
}