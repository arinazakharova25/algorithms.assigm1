namespace programCS;

using MyCalculator;

class Program
{
    static void Main(string[] args)
    {
        string input;
        if (args.Length > 0)
        {
            input = string.Join("", args);
        }
        else
        {
            Console.WriteLine("Enter expression:");
            input = Console.ReadLine();
        }
        if (string.IsNullOrWhiteSpace(input)) return;

        try
        {
           
            MyQueue tokens = Tokenizer.Tokenize(input);
            MyQueue rpn = ShuntingYard.ConvertToRpn(tokens);
            
            double result = Calculator.Evaluate(rpn);

            Console.WriteLine("Result: " + result);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}