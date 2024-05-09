// SORTING ALGORITHMS
// Chapter 3 (Arrays and Sorting)
// C# Data Structures and Algorithms, Second Edition

public class Quicksort
    : AbstractSort
{
    public override void Sort(int[] a)
    {
        SortPart(a, 0, a.Length - 1);
    }

    private void SortPart(int[] a, int l, int u)
    {
        if (l >= u) { return; }

        int pivot = a[u];
        int j = l - 1;
        for (int i = l; i < u; i++)
        {
            if (a[i] < pivot)
            {
                j++;
                (a[j], a[i]) = (a[i], a[j]);
            }
        }

        int p = j + 1;
        (a[p], a[u]) = (a[u], a[p]);

        SortPart(a, l, p - 1);
        SortPart(a, p + 1, u);
    }
}
