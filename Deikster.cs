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
        if (op == "sin" || op == "cos" || op == "max") return 4;
        return 0;
    }

    public static MyQueue ConvertToRpn(MyQueue inpTokens)
    {
        MyStack stack = new MyStack();
        MyQueue output = new MyQueue();

        while (inpTokens.Count > 0)
        {
            string token = inpTokens.Dequeue();

            if (double.TryParse(token, out _))
            {
                output.Enqueue(token);
            }
            else if (token == "sin" || token == "cos" || token == "max")
            {
                stack.Push(token);
            }
            else if (token == ",")
            {
                while (stack.Count > 0 && stack.Peek() != "(")
                    output.Enqueue(stack.Pop());
            }
            else if (IsOperator(token))
            {
                while (stack.Count > 0 &&
                       IsOperator(stack.Peek()) &&
                       Priority(stack.Peek()) >= Priority(token))
                {
                    output.Enqueue(stack.Pop());
                }

                stack.Push(token);
            }
            else if (token == "(")
            {
                stack.Push(token);
            }
            else if (token == ")")
            {
                while (stack.Count > 0 && stack.Peek() != "(")
                    output.Enqueue(stack.Pop());

                if (stack.Count == 0)
                    throw new Exception("Bracket mismatch");

                stack.Pop();

                if (stack.Count > 0 &&
                    (stack.Peek() == "sin" ||
                     stack.Peek() == "cos" ||
                     stack.Peek() == "max"))
                {
                    output.Enqueue(stack.Pop());
                }
            }
        }

        while (stack.Count > 0)
            output.Enqueue(stack.Pop());

        return output;
    }
}
