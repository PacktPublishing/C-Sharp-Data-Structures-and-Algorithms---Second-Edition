// UNDIRECTED AND UNWEIGHTED EDGES
// Chapter 8 (Exploring Graphs)
// C# Data Structures and Algorithms, Second Edition

Graph<int> graph = new() { IsDirected = false, IsWeighted = false };

Node<int> n1 = graph.AddNode(1);
Node<int> n2 = graph.AddNode(2);
Node<int> n3 = graph.AddNode(3);
Node<int> n4 = graph.AddNode(4);
Node<int> n5 = graph.AddNode(5);
Node<int> n6 = graph.AddNode(6);
Node<int> n7 = graph.AddNode(7);
Node<int> n8 = graph.AddNode(8);

graph.AddEdge(n1, n2);
graph.AddEdge(n1, n3);
graph.AddEdge(n2, n4);
graph.AddEdge(n3, n4);
graph.AddEdge(n4, n5);
graph.AddEdge(n5, n6);
graph.AddEdge(n5, n7);
graph.AddEdge(n5, n8);
graph.AddEdge(n6, n7);
graph.AddEdge(n7, n8);

Console.WriteLine("DFS:");
graph.DFS().ForEach(Console.WriteLine);

Console.WriteLine("\nBFS:");
graph.BFS().ForEach(Console.WriteLine);
