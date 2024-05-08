// MULTIPLICATION TABLE
// Chapter 3 (Arrays and Sorting)
// C# Data Structures and Algorithms, Second Edition

int[,] results = new int[10, 10];

for (int i = 0; i < results.GetLength(0); i++)
{
    for (int j = 0; j < results.GetLength(1); j++)
    {
        results[i, j] = (i + 1) * (j + 1);
        Console.Write($"{results[i, j],4}");
    }
    Console.WriteLine();
}
