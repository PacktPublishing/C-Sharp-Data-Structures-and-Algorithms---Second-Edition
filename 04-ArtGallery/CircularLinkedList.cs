// ART GALLERY
// Chapter 4 (Variants of Lists)
// C# Data Structures and Algorithms, Second Edition

using System.Collections;

public class CircularLinkedList<T>
    : LinkedList<T>
{
    public new IEnumerator GetEnumerator() => new CircularEnumerator<T>(this);
}
