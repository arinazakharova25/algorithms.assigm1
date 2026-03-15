namespace MyCalculator;

public class Calculator
{
    public int Calculate(string expression)
    {
        var stack = new Stack();

        var tokens = expression.Split(' ');

        for (var i = 0; i < tokens.Length; i++)
        {
            var t = tokens[i];

            if (t == "+" || t == "-" || t == "*" || t == "/")
            {
                var b = int.Parse(stack.Pull());
                var a = int.Parse(stack.Pull());

                var result = 0;

                if (t == "+")
                {
                    result = a + b;
                }

                if (t == "-")
                {
                    result = a - b;
                }

                if (t == "*")
                {
                    result = a * b;
                }

                if (t == "/")
                {
                    result = a / b;
                }

                stack.Push(result.ToString());
            }
            else
            {
                stack.Push(t);
            }
        }
        return int.Parse(stack.Pull());
    }
}