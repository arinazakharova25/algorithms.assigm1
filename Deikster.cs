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

    public static MyQueue ConvertToRpn(MyQueue InpTokens)
    {
        MyStack stack = new MyStack();
        MyQueue outputQueue = new MyQueue();
        
        while (InpTokens.Count > 0)
        {
            string token = InpTokens.Dequeue();
            
            if (double.TryParse(token, out _))
            {
                outputQueue.Enqueue(token);
            }
            else if (token == "sin" || token == "cos" || token == "max")
            {
                stack.Push(token);
            }
            else if (token == ",")
            {
                while (stack.Count > 0 && stack.Peek() != "(")
                {
                    outputQueue.Enqueue(stack.Pull());
                }
                if (stack.Count == 0) throw new Exception("The coma wasnt in the right place or there was no coma");
            }
            else if (IsOperator(token))
            {
                while (stack.Count > 0 && IsOperator(stack.Peek()) && Priority(stack.Peek()) >= Priority(token))
                {
                    outputQueue.Enqueue(stack.Pull());
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
                {
                    outputQueue.Enqueue(stack.Pull());
                }

                if (stack.Count == 0) throw new Exception("Помилка: невідповідність дужок (відсутня '(')");
                
                stack.Pull();
                
                if (stack.Count > 0 && (stack.Peek() == "sin" || stack.Peek() == "cos" || stack.Peek() == "max"))
                {
                    outputQueue.Enqueue(stack.Pull());
                }
            }
            else
            {
                throw new Exception($"Невідомий токен: {token}");
            }
        }
        
        while (stack.Count > 0)
        {
            if (stack.Peek() == "(") throw new Exception("There are to many'('");
            outputQueue.Enqueue(stack.Pull());
        }

        return outputQueue;
    }
}
