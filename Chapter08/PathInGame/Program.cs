// PATH IN GAME
// Chapter 8 (Exploring Graphs)
// C# Data Structures and Algorithms, Second Edition

using System.Text;

string[] lines =
[
    "0011100000111110000011111",
    "0011100000111110000011111",
    "0011100000111110000011111",
    "0000000000011100000011111",
    "0000001110000000000011111",
    "0001001110011100000011111",
    "1111111111111110111111100",
    "1111111111111110111111101",
    "1111111111111110111111100",
    "0000000000000000111111110",
    "0000000000000000111111100",
    "0001111111001100000001101",
    "0001111111001100000001100",
    "0001100000000000111111110",
    "1111100000000000111111100",
    "1111100011001100100010001",
    "1111100011001100001000100"
];
bool[][] map = new bool[lines.Length][];
for (int i = 0; i < lines.Length; i++)
{
    map[i] = lines[i]
        .Select(c => int.Parse(c.ToString()) == 0)
        .ToArray();
}

Graph<string> graph = new() { IsDirected = false, IsWeighted = true };
for (int i = 0; i < map.Length; i++)
{
    for (int j = 0; j < map[i].Length; j++)
    {
        if (!map[i][j]) { continue; }

        Node<string> from = graph.AddNode($"{i}-{j}");

        if (i > 0 && map[i - 1][j])
        {
            Node<string> to = graph.Nodes.Find(n => n.Data == $"{i - 1}-{j}")!;
            graph.AddEdge(from, to, 1);
        }

        if (j > 0 && map[i][j - 1])
        {
            Node<string> to = graph.Nodes.Find(n => n.Data == $"{i}-{j - 1}")!;
            graph.AddEdge(from, to, 1);
        }
    }
}

Node<string> s = graph.Nodes.Find(n => n.Data == "0-0")!;
Node<string> t = graph.Nodes.Find(n => n.Data == "16-24")!;
List<Edge<string>> path = graph.GetShortestPath(s, t);

Console.OutputEncoding = Encoding.UTF8;
for (int r = 0; r < map.Length; r++)
{
    for (int c = 0; c < map[r].Length; c++)
    {
        bool isPath = path.Any(e => e.From.Data == $"{r}-{c}" || e.To.Data == $"{r}-{c}");
        Console.ForegroundColor = isPath ? ConsoleColor.White
            : map[r][c] ? ConsoleColor.Green : ConsoleColor.Red;
        Console.Write("\u25cf ");
    }
    Console.WriteLine();
}
Console.ResetColor();
