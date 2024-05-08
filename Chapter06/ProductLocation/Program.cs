// PRODUCT LOCATION
// Chapter 6 (Dictionaries and Sets)
// C# Data Structures and Algorithms, Second Edition

Dictionary<string, string> products = new()
{
    { "5901020304050", "A1" },
    { "5910203040506", "B5" },
    { "5920304050607", "C9" }
};
products["5930405060708"] = "D7";

string key = "5940506070809";
if (!products.ContainsKey(key))
{
    products.Add(key, "A3");
}

if (!products.TryAdd(key, "B4"))
{
    Console.WriteLine("Cannot add.");
}

Console.WriteLine("All products:");
if (products.Count == 0) { Console.WriteLine("Empty"); }
foreach ((string k, string v) in products)
{
    Console.WriteLine($"{k}: {v}");
}

Console.Write("\nSearch by barcode: ");
string barcode = Console.ReadLine() ?? string.Empty;
if (products.TryGetValue(barcode, out string? location))
{
    Console.WriteLine($"The product is in: {location}.");
}
else
{
    Console.WriteLine("The product does not exist.");
}
