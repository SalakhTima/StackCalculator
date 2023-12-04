namespace StackCalculator.Domain;

public class Division : ICommand
{
    public double Execute(double leftOperand, double rightOperand)
    {
        try
        {
            return leftOperand / rightOperand;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return default;
        }
    }
}