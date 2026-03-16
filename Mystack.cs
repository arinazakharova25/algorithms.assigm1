namespace MystackClass;
public class MyStack
{
    private const int Capacity = 100;
    private string[] array = new string[Capacity];
    private int pointer = 0;

    public void Push(string value)
    {
        if (pointer >= Capacity)
        {
            throw new Exception ("Stack is overflow")
        }
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
        if (pointer == 0)
        {
            throw new Exception ("Stack is empty")
        }    
        return array[pointer - 1];
    }