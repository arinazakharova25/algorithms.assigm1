namespace MystackClass;
public class MyStack
{
    private const int Capacity = 100;

    private string[] _array = new string[Capacity];

    private int _pointer = 0;

    public void Push(string value)
    {
        _array[_pointer] = value;
        _pointer++;
    }

    public string Pull()
    {
        if (_pointer == 0)
        {
            return null;
        }

        _pointer--;
        return _array[_pointer];
    }

    public string Peek()
    {
        if (_pointer == 0)
        {
            return null;
        }

        return _array[_pointer - 1];
    }

    public bool IsEmpty()
    {
        return _pointer == 0;
    }
}