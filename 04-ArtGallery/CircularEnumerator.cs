// ART GALLERY
// Chapter 4 (Variants of Lists)
// C# Data Structures and Algorithms, Second Edition

using System.Collections;

public class CircularEnumerator<T>(LinkedList<T> list)
    : IEnumerator<T>
{
    private LinkedListNode<T>? _current = null;
    public T Current => _current != null ? _current.Value : default!;
    object IEnumerator.Current => Current!;

    public bool MoveNext()
    {
        if (_current == null)
        {
            _current = list?.First;
            return _current != null;
        }
        else
        {
            _current = _current.Next ?? _current!.List?.First;
            return true;
        }
    }

    public void Reset()
    {
        _current = null;
    }

    public void Dispose()
    {
    }
}