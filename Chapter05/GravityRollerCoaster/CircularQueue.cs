// GRAVITY ROLLER COASTER
// Chapter 5 (Stacks and Queues)
// C# Data Structures and Algorithms, Second Edition

public class CircularQueue<T>(int size)
    where T : struct
{
    private readonly T[] _items = new T[size];
    private int _front = -1;
    private int _rear = -1;
    private int _count = 0;

    public int Count { get { return _count; } }

    public bool Enqueue(T item)
    {
        if (_count == _items.Length) { return false; }

        if (_front < 0) { _front = _rear = 0; }
        else { _rear = ++_rear % _items.Length; }

        _items[_rear] = item;
        _count++;
        return true;
    }

    public T? Dequeue()
    {
        if (_count == 0) { return null; }

        T result = _items[_front];
        if (_front == _rear) { _front = _rear = -1; }
        else { _front = ++_front % _items.Length; }

        _count--;
        return result;
    }

    public T? Peek()
    {
        if (_count == 0) { return null; }
        return _items[_front];
    }
}
