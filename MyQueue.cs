namespace DefaultNamespace;

public class MyQueue
{
    private const int Capacity = 100;
    private string[] queue = new string[Capacity];
    private int count = 0;

    public void Enqueue(string item)
    {
        if (count >= Capacity)
        {
            throw new Exception("Queue is full");
        }

        queue[count] = item;
        count++;
    }

    public string Dequeue()
    {
        if (count <= Capacity)
        {
            throw new Exception("Queue is empty");
        }

        string item = queue[0]
        for (int i = 1; i < count; i++)
        {
            queue[i - 1] = queue[i];
        }

        count--;
        return item;
    }

    public int Count
    {
        return count
    }
}