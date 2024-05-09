// REMOVING DUPLICATES
// Chapter 6 (Dictionaries and Sets)
// C# Data Structures and Algorithms, Second Edition

List<string> names = [ "Marcin", "Mary", "James", "Albert", "Lily", "Emily", "marcin", "James", "Jane" ];
SortedSet<string> sorted = new(
    names,
    Comparer<string>.Create((a, b) => a.ToLower().CompareTo(b.ToLower())));
foreach (string name in sorted)
{
    Console.WriteLine(name);
}
