// USER DETAILS
// Chapter 6 (Dictionaries and Sets)
// C# Data Structures and Algorithms, Second Edition

Dictionary<int, Employee> employees = new()
{
  { 100, new Employee("Marcin", "Jamro", "101-202-303") },
  { 210, new Employee("John", "Smith", "202-303-404") },
  { 303, new Employee("Aline", "Weather", "303-404-505") }
};

do
{
    Console.Write("Enter the identifier: ");
    string idString = Console.ReadLine() ?? string.Empty;
    if (!int.TryParse(idString, out int id)) { break; }

    if (employees.TryGetValue(id, out Employee? employee))
    {
        Console.WriteLine(
            "Full name: {0} {1}\nPhone number: {2}\n",
            employee.FirstName,
            employee.LastName,
            employee.PhoneNumber);
    }
    else { Console.WriteLine("Does not exist.\n"); }
}
while (true);
