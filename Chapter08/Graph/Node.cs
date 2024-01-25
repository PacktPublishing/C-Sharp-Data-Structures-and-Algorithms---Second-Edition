// GRAPH NODE
// Chapter 8 (Exploring Graphs)
// C# Data Structures and Algorithms, Second Edition

public class Node<T>
{
    public int Index { get; set; }
    public required T Data { get; set; }
    public List<Node<T>> Neighbors { get; set; } = [];
    public List<int> Weights { get; set; } = [];
    public override string ToString() => $"Index: {Index}. Data: {Data}. Neighbors: { Neighbors.Count}.";
}
