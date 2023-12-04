namespace StackCalculator.Domain;

public class Multiply : ICommand
{
    public double Execute(double leftOperand, double rightOperand)
    {
        double result;
        try
        {
            checked
            {
                result = leftOperand * rightOperand;
            }
        }
        catch (OverflowException e)
        {
            Console.WriteLine(e.Message);
            result = default;
        }
        return result;
    }
}