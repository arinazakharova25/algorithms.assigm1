namespace MyCalculator;
public class RpnCalculator
{
    private static bool IsOperator(string t)
    {
        return t == "+" || t == "-" || t == "*" || t == "/" || t == "^";
    }

    public static double Evaluate(string[] rpn)
    {
        MyStack<double> stack = new MyStack<double>();

        foreach (string token in rpn)
        {
            if (double.TryParse(token, out double number))
            {
                stack.Push(number);
            }
            else if (IsOperator(token))
            {
                double b = stack.Pop();
                double a = stack.Pop();

                if (token == "+") stack.Push(a + b);
                if (token == "-") stack.Push(a - b);
                if (token == "*") stack.Push(a * b);
                if (token == "/") stack.Push(a / b);
                if (token == "^") stack.Push(Math.Pow(a, b));
            }
            else if (token == "sin")
            {
                double a = stack.Pop();
                stack.Push(Math.Sin(a));
            }
            else if (token == "cos")
            {
                double a = stack.Pop();
                stack.Push(Math.Cos(a));
            }
            else if (token == "max")
            {
                double b = stack.Pop();
                double a = stack.Pop();
                stack.Push(Math.Max(a, b));
            }
        }

        return stack.Pop();
    }
}