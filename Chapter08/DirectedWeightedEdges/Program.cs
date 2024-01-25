// DIRECTED AND WEIGHTED EDGES
// Chapter 8 (Exploring Graphs)
// C# Data Structures and Algorithms, Second Edition

Graph<int> graph = new() { IsDirected = true, IsWeighted = true };

Node<int> n1 = graph.AddNode(1);
Node<int> n2 = graph.AddNode(2);
Node<int> n3 = graph.AddNode(3);
Node<int> n4 = graph.AddNode(4);
Node<int> n5 = graph.AddNode(5);
Node<int> n6 = graph.AddNode(6);
Node<int> n7 = graph.AddNode(7);
Node<int> n8 = graph.AddNode(8);

graph.AddEdge(n1, n2, 9);
graph.AddEdge(n1, n3, 5);
graph.AddEdge(n2, n1, 3);
graph.AddEdge(n2, n4, 18);
graph.AddEdge(n3, n4, 12);
graph.AddEdge(n4, n2, 2);
graph.AddEdge(n4, n8, 8);
graph.AddEdge(n5, n4, 9);
graph.AddEdge(n5, n6, 2);
graph.AddEdge(n5, n7, 5);
graph.AddEdge(n5, n8, 3);
graph.AddEdge(n6, n7, 1);
graph.AddEdge(n7, n5, 4);
graph.AddEdge(n7, n8, 6);
graph.AddEdge(n8, n5, 3);

Console.WriteLine("DFS:");
graph.DFS().ForEach(Console.WriteLine);

Console.WriteLine("\nBFS:");
graph.BFS().ForEach(Console.WriteLine);

Console.WriteLine("\nShortest path:");
List<Edge<int>> path = graph.GetShortestPath(n1, n5);
path.ForEach(Console.WriteLine);
