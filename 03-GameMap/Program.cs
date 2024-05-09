// GAME MAP
// Chapter 3 (Arrays and Sorting)
// C# Data Structures and Algorithms, Second Edition

using System.Text;

char[,] map =
{
    { 's', 's', 's', 'g', 'g', 'g', 'g', 'g' },
    { 's', 's', 's', 'g', 'g', 'g', 'g', 'g' },
    { 's', 's', 's', 's', 's', 'b', 'b', 'b' },
    { 's', 's', 's', 's', 's', 'b', 's', 's' },
    { 'w', 'w', 'w', 'w', 'w', 'b', 'w', 'w' },
    { 'w', 'w', 'w', 'w', 'w', 'b', 'w', 'w' }

};
Console.OutputEncoding = Encoding.UTF8;
for (int r = 0; r < map.GetLength(0); r++)
{
    for (int c = 0; c < map.GetLength(1); c++)
    {
        Console.ForegroundColor = GetColor(map[r, c]);
        Console.Write(GetChar(map[r, c]) + " ");
    }
    Console.WriteLine();
}
Console.ResetColor();


ConsoleColor GetColor(char terrain)
{
    return terrain switch
    {
        'g' => ConsoleColor.Green,
        's' => ConsoleColor.Yellow,
        'w' => ConsoleColor.Blue,
        _ => ConsoleColor.DarkGray
    };
}

char GetChar(char terrain)
{
    return terrain switch
    {
        'g' => '\u201c',
        's' => '\u25cb',
        'w' => '\u2248',
        _ => '\u25cf'
    };
}
