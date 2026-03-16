namespace TokenizerClass;

public class Tokenizer
{
    public static MyQueue Tokenize(string input)
    {
        MyQueue tokens = new MyQueue();
        string number = "";

        foreach (char n in input)
        {
            if (char.IsDigit(n) || char.IsLetter(n))
            {
                number += n;
            }
            else
            {
                if (number != "")
                {
                    tokens.Enqueue(number);
                    number = "";
                }

                if (n == ' ')
                    continue;

                if ("+-*/^(),".Contains(n))
                    tokens.Enqueue(n.ToString());
            }
        }

        if (number != "")
            tokens.Enqueue(number);

        return tokens;
    }
}