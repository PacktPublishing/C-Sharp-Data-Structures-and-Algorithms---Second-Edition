// ADDRESS BOOK
// Chapter 4 (Variants of Lists)
// C# Data Structures and Algorithms, Second Edition

SortedList<string, Person> people = new()
{
    { "Marcin Jamro", new("Marcin Jamro", "Polish Street 1/23", "35-001", "Rzeszow", "PL") },
    { "Martyna Kowalska", new("Martyna Kowalska", "World Street 5", "00-123", "Warsaw", "PL") }
};
people.Add("Mark Smith", new("Mark Smith", "German Street 6", "10000", "Berlin", "DE"));
foreach ((string k, Person p) in people)
{
    Console.WriteLine($"{k}: {p.Street}, {p.PostalCode} {p.City}, {p.Country}.");
}
