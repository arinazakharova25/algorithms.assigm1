namespace programCS;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter expression:");

        string input = Console.ReadLine();

        string[] tokens = Tokenizer.Tokenize(input);

        string[] rpn = ShuntingYard.Convert(tokens);

        Console.WriteLine("RPN:");

        foreach (string t in rpn)
            Console.Write(t + " ");

        Console.WriteLine();

        double result = Calculator.Calculate(rpn);

        Console.WriteLine("Result: " + result);
    }
}