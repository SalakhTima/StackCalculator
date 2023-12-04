namespace StackCalculator.Domain;

public class Exponentiation : ICommand
{
    public double Execute(double leftOperand, double rightOperand)
    {
        double result;
        try
        {
            checked
            {
                result = Math.Pow(leftOperand, rightOperand);
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