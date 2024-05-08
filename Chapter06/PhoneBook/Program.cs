// PHONE BOOK
// Chapter 6 (Dictionaries and Sets)
// C# Data Structures and Algorithms, Second Edition

using System.Collections;

Hashtable phoneBook = new()
{
    { "Marcin", "101-202-303" },
    { "John", "202-303-404" }
};
phoneBook["Aline"] = "303-404-505";

Console.WriteLine("Phone numbers:");
if (phoneBook.Count == 0)
{
    Console.WriteLine("Empty list.");
}

foreach (DictionaryEntry entry in phoneBook)
{
    Console.WriteLine($"{entry.Key}: {entry.Value}");
}

Console.Write("\nSearch by name: ");
string name = Console.ReadLine() ?? string.Empty;
if (phoneBook.ContainsKey(name))
{
    string number = (string)phoneBook[name]!;
    Console.WriteLine($"Phone number: {number}");
}
else
{
    Console.WriteLine("Does not exist.");
}
