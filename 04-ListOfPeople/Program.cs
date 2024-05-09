// LIST OF PEOPLE
// Chapter 4 (Variants of Lists)
// C# Data Structures and Algorithms, Second Edition

List<Person> people =
[
    new("Marcin", 35, "PL"),
    new("Sabine", 25, "DE"),
    new("Mark", 31, "PL")
];

List<Person> r = [.. people.OrderBy(p => p.Name)];
foreach (Person p in r)
{
    string line = $"{p.Name} ({p.Age}) from {p.Country}.";
    Console.WriteLine(line);
}
