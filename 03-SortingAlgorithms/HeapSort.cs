// SORTING ALGORITHMS
// Chapter 3 (Arrays and Sorting)
// C# Data Structures and Algorithms, Second Edition

public class HeapSort
    : AbstractSort
{
    public override void Sort(int[] a)
    {
        for (int i = a.Length / 2 - 1; i >= 0; i--)
        {
            Heapify(a, a.Length, i);
        }

        for (int i = a.Length - 1; i > 0; i--)
        {
            (a[0], a[i]) = (a[i], a[0]);
            Heapify(a, i, 0);
        }
    }

    private void Heapify(int[] a, int n, int i)
    {
        int max = i;
        int l = 2 * i + 1;
        int r = 2 * i + 2;

        max = l < n && a[l] > a[max] ? l : max;
        max = r < n && a[r] > a[max] ? r : max;

        if (max != i)
        {
            (a[i], a[max]) = (a[max], a[i]);
            Heapify(a, n, max);
        }
    }
}
