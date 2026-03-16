namespace ShuntingYard;

public class ShuntingYard
{
    private static bool IsOperator(string t)
    {
        return t == "+" || t == "-" || t == "*" || t == "/" || t == "^";
    }

    private static int Priority(string op)
    {
        if (op == "+" || op == "-") return 1;
        if (op == "*" || op == "/") return 2;
        if (op == "^") return 3;
        return 0;
    }

    public static string[] ConvertToRpn(string[] tokens)
    {
        MyStack<string> stack = new MyStack<string>();

        string[] output = new string[100];
        int count = 0;

        foreach (string token in tokens)
        {
            if (double.TryParse(token, out _))
            {
                output[count++] = token;
            }
            else if (IsOperator(token))
            {
                while (!stack.IsEmpty() && IsOperator(stack.Peek()) && Priority(stack.Peek()) >= Priority(token))
                {
                    output[count++] = stack.Pop();
                }

                stack.Push(token);
            }
            else if (token == "(")
            {
                stack.Push(token);
            }
            else if (token == ")")
            {
                while (stack.Peek() != "(")
                    output[count++] = stack.Pop();

                stack.Pop();
            }
            else
            {
                stack.Push(token);
            }
        }

        while (!stack.IsEmpty())
            output[count++] = stack.Pop();

        string[] result = new string[count];

        for (int i = 0; i < count; i++)
            result[i] = output[i];

        return result;
    }
}