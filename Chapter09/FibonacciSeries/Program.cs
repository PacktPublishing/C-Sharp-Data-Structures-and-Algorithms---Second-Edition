// FIBONACCI SERIES
// Chapter 9 (See in Action)
// C# Data Structures and Algorithms, Second Edition

// Simple recursive implementation:
// long Fibonacci(int n)
// {
//     if (n == 0) { return 0; }
//     if (n == 1) { return 1; }
//     return Fibonacci(n - 1) + Fibonacci(n - 2);
// }

// Dynamic programming with top-down approach:
// Dictionary<int, long> cache = [];
// long Fibonacci(int n)
// {
//     if (n == 0) { return 0; }
//     if (n == 1) { return 1; }
//     if (cache.ContainsKey(n)) { return cache[n]; }
//     long result = Fibonacci(n - 1) + Fibonacci(n - 2);
//     cache[n] = result;
//     return result;
// }

// Dynamic programming with bottom-up approach:
long Fibonacci(int n)
{
    if (n == 0) { return 0; }
    if (n == 1) { return 1; }

    long a = 0;
    long b = 1;
    for (int i = 2; i <= n; i++)
    {
        long result = a + b;
        a = b;
        b = result;
    }

    return b;
}

long result = Fibonacci(25);
Console.WriteLine($"F(25) = {result}");
