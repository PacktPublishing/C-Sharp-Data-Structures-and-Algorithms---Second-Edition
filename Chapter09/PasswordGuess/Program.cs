// PASSWORD GUESS
// Chapter 9 (See in Action)
// C# Data Structures and Algorithms, Second Edition

using System.Diagnostics;
using System.Text;

const string secretPassword = "csharp";

int charsCount = 0;
char[] chars = new char[36];
for (char c = 'a'; c <= 'z'; c++) { chars[charsCount++] = c; }
for (char c = '0'; c <= '9'; c++) { chars[charsCount++] = c; }

for (int length = 2; length <= 8; length++)
{
    Stopwatch sw = Stopwatch.StartNew();
    int[] indices = new int[length];
    for (int i = 0; i < length; i++) { indices[i] = 0; }

    bool isCompleted = false;
    StringBuilder builder = new();
    long count = 0;
    while (!isCompleted)
    {
        builder.Clear();
        for (int i = 0; i < length; i++)
        {
            builder.Append(chars[indices[i]]);
        }

        string guess = builder.ToString();
        if (guess == secretPassword)
        {
            Console.WriteLine("Found.");
        }

        count++;

        if (count % 10000000 == 0)
        {
            Console.WriteLine($" > Checked: {count}.");
        }

        indices[length - 1]++;
        if (indices[length - 1] >= charsCount)
        {
            for (int i = length - 1; i >= 0; i--)
            {
                indices[i] = 0;
                indices[i - 1]++;
                if (indices[i - 1] < charsCount) { break; }
                if (i - 1 == 0 && indices[0] >= charsCount)
                {
                    isCompleted = true;
                    break;
                }
            }
        }
    }

    sw.Stop();
    int seconds = (int)sw.ElapsedMilliseconds / 1000;
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine($"{length} chars: {seconds}s");
    Console.ResetColor();
}
