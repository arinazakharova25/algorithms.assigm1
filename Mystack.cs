namespace MystackClass;

public class MyStack
{
    private const int Capacity = 100;
    private string[] array = new string[Capacity];
    private int pointer = 0;

    public void Push(string value)
    {
        if (pointer >= Capacity)
            throw new Exception("Stack is full");

        array[pointer++] = value;
    }

    public string Pop()
    {
        if (pointer == 0)
            throw new Exception("Stack is empty");

        pointer--;
        return array[pointer];
    }

    public string Peek()
    {
        if (pointer == 0)
            throw new Exception("Stack is empty");

        return array[pointer - 1];
    }

    public int Count
    {
         return array[pointer]; 
    }
}