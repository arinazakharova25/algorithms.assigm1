namespace programCS;

public class Program
{
    public static void Main(string[] args)
    {
        var calculator = new Calculator();

        Console.WriteLine("Enter expression:");

        var text = Console.ReadLine();

        var result = calculator.Calculate(text);

        Console.WriteLine("Result: " + result);
    }
}