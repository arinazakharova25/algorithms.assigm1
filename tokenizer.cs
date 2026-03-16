namespace TokenizerClass;

public class tokenizer
{
    public static string[] Tokenize(string input)
    {
        string[] tokens = new string[100];
        int count = 0;

        string number = "";

        foreach (char c in input)
        {
            if (char.IsDigit(c))
            {
                number += c;
            }
            else
            {
                if (number.Length > 0)
                {
                    tokens[count++] = number;
                    number = "";
                }

                if (c == ' ')
                    continue;

                tokens[count++] = c.ToString();
            }
        }

        if (number.Length > 0)
            tokens[count++] = number;

        string[] result = new string[count];

        for (int i = 0; i < count; i++)
            result[i] = tokens[i];

        return result;
    }
}