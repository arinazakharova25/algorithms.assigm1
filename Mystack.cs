namespace MystackClass;
public class MyStack
{
    private const int Capacity = 100;
    private string[] array = new string[Capacity];
    private int pointer = 0;

    public void Push(string value)
    {
        array[pointer] = value;
        pointer++;
    }

    public string Pop()
    {
        pointer--;
        return array[pointer];
    }

    public string Peek()
    {
        return array[pointer - 1];
    }

    public bool IsEmpty()
    {
        return pointer == 0;
    }
}