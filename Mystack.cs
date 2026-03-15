namespace MystackClass;
public class MyStack
{
    private const int Capacity = 50;

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

        var value = _array[_pointer];
        _pointer--;
        return value;
    }
}