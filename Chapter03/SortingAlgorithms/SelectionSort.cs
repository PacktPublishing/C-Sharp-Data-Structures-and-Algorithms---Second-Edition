using System;

namespace SelectionSort
{
    abstract class AbstractSort
    {
        public abstract void Sort(int[] a);
    }

    class SelectionSort : AbstractSort
    {
        public override void Sort(int[] a)
        {
            for (int i = 0; i < a.Length - 1; i++)
            {
                int minIndex = i;
                int minValue = a[i];
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (a[j] < minValue)
                    {
                        minIndex = j;
                        minValue = a[j];
                    }
                }

                (a[i], a[minIndex]) = (a[minIndex], a[i]); // Swap elements
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { -11, 12, -42, 0, 1, 90, 68, 6, -9 };
            SelectionSort sort = new SelectionSort();
            sort.Sort(array);
            Console.WriteLine(string.Join(" | ", array));
        }
    }
}
