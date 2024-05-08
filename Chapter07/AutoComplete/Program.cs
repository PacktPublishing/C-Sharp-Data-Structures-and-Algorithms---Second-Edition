// AUTO-COMPLETE
// Chapter 7 (Variants of Trees)
// C# Data Structures and Algorithms, Second Edition

using System.Text.RegularExpressions;

Trie trie = new();
string[] countries = await File.ReadAllLinesAsync("Countries.txt");
foreach (string country in countries)
{
    Regex regex = new("[^a-z]");
    string name = country.ToLower();
    name = regex.Replace(name, string.Empty);
    trie.Insert(name);
}

string text = string.Empty;
while (true)
{
    Console.Write("Enter next character: ");
    ConsoleKeyInfo key = Console.ReadKey();
    if (key.KeyChar < 'a' || key.KeyChar > 'z') { return; }
    text = (text + key.KeyChar).ToLower();
    List<string> results = trie.SearchByPrefix(text);
    if (results.Count == 0) { return; }
    Console.WriteLine($"\nSuggestions for {text.ToUpper()}:");
    results.ForEach(r => Console.WriteLine(r.ToUpper()));
    Console.WriteLine();
}
