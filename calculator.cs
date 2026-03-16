namespace MyCalculator;

public class Calculator
{
    private static bool IsOperator(string t)
    {
        return t == "+" || t == "-" || t == "*" || t == "/" || t == "^";
    }

    public static double Evaluate(MyQueue rpnTokens)
    {
        MyStack values = new MyStack();

        while (rpnTokens.Count > 0)
        {
            string token = rpnTokens.Dequeue();

            if (double.TryParse(token, out _))
            {
                values.Push(token);
            }
            else if (IsOperator(token))
            {
                double b = double.Parse(values.Pull());
                double a = double.Parse(values.Pull());
                double result = 0;
                
                if (token == "+") result = a + b;
                else if (token == "-") result = a - b;
                else if (token == "*") result = a * b;
                else if (token == "/")
                {
                    if (b == 0) throw new Exception("Cannot divide by zero");
                    result = a / b;
                }
                else if (token == "^") result = Math.Pow(a, b);
                else throw new Exception($"Unknown operator: {token}");

                values.Push(result.ToString());
            }
            else if (token == "sin") 
            { 
                double a = double.Parse(values.Pull()); 
                values.Push(Math.Sin(a).ToString()); 
            } 
            else if (token == "cos") 
            { 
                double a = double.Parse(values.Pull()); 
                values.Push(Math.Cos(a).ToString()); 
            }
            else if (token == "max")
            {
                double b = double.Parse(values.Pull());
                double a = double.Parse(values.Pull());
                values.Push(Math.Max(a, b).ToString());
            }
        }
        return double.Parse(values.Pull());
    }
}