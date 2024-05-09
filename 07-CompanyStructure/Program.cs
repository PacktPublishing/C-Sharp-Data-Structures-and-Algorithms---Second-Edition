// COMPANY STRUCTURE
// Chapter 7 (Variants of Trees)
// C# Data Structures and Algorithms, Second Edition

Tree<Person> company = new()
{
    Root = new()
    {
        Data = new Person("Marcin Jamro", "Chief Executive Officer"),
        Parent = null
    }
};

company.Root.Children =
[
    new() { Data = new Person("John Smith", "Head of Development"), Parent = company.Root },
    new() { Data = new Person("Alice Batman", "Head of Research"), Parent = company.Root },
    new() { Data = new Person("Lily Smith", "Head of Sales"), Parent = company.Root }
];
company.Root.Children[2].Children =
[
    new() { Data = new Person("Anthony Black", "Senior Sales Specialist"), Parent = company.Root.Children[2] }
];
