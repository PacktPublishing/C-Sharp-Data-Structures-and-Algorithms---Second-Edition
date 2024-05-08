// VOIVODESHIP MAP
// Chapter 8 (Exploring Graphs)
// C# Data Structures and Algorithms, Second Edition

Graph<string> graph = new() { IsDirected = false, IsWeighted = false };

List<string> borders =
[
    "PK:LU|SK|MA",
    "LU:PK|SK|MZ|PD",
    "SK:PK|MA|SL|LD|MZ|LU",
    "MA:PK|SK|SL",
    "SL:MA|SK|LD|OP",
    "LD:SL|SK|MZ|KP|WP|OP",
    "WP:LD|KP|PM|ZP|LB|DS|OP",
    "OP:SL|LD|WP|DS",
    "MZ:LU|SK|LD|KP|WM|PD",
    "PD:LU|MZ|WM",
    "WM:PD|MZ|KP|PM",
    "KP:MZ|LD|WP|PM|WM",
    "PM:WM|KP|WP|ZP",
    "ZP:PM|WP|LB",
    "LB:ZP|WP|DS",
    "DS:LB|WP|OP"
];

Dictionary<string, Node<string>> nodes = [];
foreach (string border in borders)
{
    string[] parts = border.Split(':');
    string name = parts[0];
    nodes[name] = graph.AddNode(name);
}

foreach (string border in borders)
{
    string[] parts = border.Split(':');
    string name = parts[0];
    string[] vicinities = parts[1].Split('|');
    foreach (string vicinity in vicinities)
    {
        Node<string> from = nodes[name];
        Node<string> to = nodes[vicinity];
        if (!from.Neighbors.Contains(to))
        {
            graph.AddEdge(from, to);
        }
    }
}

int[] colors = graph.Color();
for (int i = 0; i < colors.Length; i++)
{
    Console.WriteLine($"{graph.Nodes[i].Data}: {colors[i]}");
}
