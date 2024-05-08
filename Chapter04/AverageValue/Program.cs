// AVERAGE VALUE
// Chapter 4 (Variants of Lists)
// C# Data Structures and Algorithms, Second Edition

List<double> num = [];
do
{
    Console.Write("Enter the number: ");
    string numStr = Console.ReadLine() ?? string.Empty;
    if (!double.TryParse(numStr, out double n)) { break; }
    num.Add(n);
    Console.WriteLine($"Average value: {num.Average()}");
}
while (true);
