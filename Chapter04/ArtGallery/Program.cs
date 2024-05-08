// ART GALLERY
// Chapter 4 (Variants of Lists)
// C# Data Structures and Algorithms, Second Edition

string[][] arts = GetArts();
CircularLinkedList<string[]> images = new();
foreach (string[] art in arts) { images.AddLast(art); }

LinkedListNode<string[]> node = images.First!;
ConsoleKey key = ConsoleKey.Spacebar;
do
{
    if (key == ConsoleKey.RightArrow)
    {
        node = node.Next()!;
    }
    else if (key == ConsoleKey.LeftArrow)
    {
        node = node.Prev()!;
    }

    Console.Clear();
    foreach (string line in node.Value)
    {
        Console.WriteLine(line);
    }
}
while ((key = Console.ReadKey().Key) != ConsoleKey.Escape);

string[][] GetArts() => [
    [
        "  +-----+  ",
        "o-| o o |-o",
        "  |  -  |  ",
        "  +-----+  ",
        "    | |    "
    ],
    [
        "o +-----+  ",
        " \\| o o |\\ ",
        "  |  -  | o",
        "  +-----+  ",
        "    / |    "
    ],
    [
        "  +-----+ o",
        " /| o o |/ ",
        "o |  -  |  ",
        "  +-----+  ",
        "    | \\    "
    ]
];
