// GRAPH
// Chapter 8 (Exploring Graphs)
// C# Data Structures and Algorithms, Second Edition

using Priority_Queue;

public partial class Graph<T>
{
    public required bool IsDirected { get; init; }
    public required bool IsWeighted { get; init; }
    public List<Node<T>> Nodes { get; set; } = [];

    #region Get edge and edges
    public Edge<T>? this[int from, int to]
    {
        get
        {
            Node<T> nodeFrom = Nodes[from];
            Node<T> nodeTo = Nodes[to];
            int i = nodeFrom.Neighbors.IndexOf(nodeTo);
            if (i < 0) { return null; }
            Edge<T> edge = new()
            {
                From = nodeFrom,
                To = nodeTo,
                Weight = i < nodeFrom.Weights.Count ? nodeFrom.Weights[i] : 0
            };
            return edge;
        }
    }

    public List<Edge<T>> GetEdges()
    {
        List<Edge<T>> edges = [];
        foreach (Node<T> from in Nodes)
        {
            for (int i = 0; i < from.Neighbors.Count; i++)
            {
                int weight = i < from.Weights.Count ? from.Weights[i] : 0;
                Edge<T> edge = new()
                {
                    From = from,
                    To = from.Neighbors[i],
                    Weight = weight
                };
                edges.Add(edge);
            }
        }
        return edges;
    }
    #endregion

    #region Add and remove nodes
    public Node<T> AddNode(T value)
    {
        Node<T> node = new() { Data = value };
        Nodes.Add(node);
        UpdateIndices();
        return node;
    }

    public void RemoveNode(Node<T> nodeToRemove)
    {
        Nodes.Remove(nodeToRemove);
        UpdateIndices();
        Nodes.ForEach(n => RemoveEdge(n, nodeToRemove));
    }

    private void UpdateIndices()
    {
        int i = 0;
        Nodes.ForEach(n => n.Index = i++);
    }
    #endregion

    #region Add and remove edges
    public void AddEdge(Node<T> from, Node<T> to, int w = 0)
    {
        from.Neighbors.Add(to);
        if (IsWeighted) { from.Weights.Add(w); }

        if (!IsDirected)
        {
            to.Neighbors.Add(from);
            if (IsWeighted) { to.Weights.Add(w); }
        }
    }

    public void RemoveEdge(Node<T> from, Node<T> to)
    {
        int index = from.Neighbors.FindIndex(n => n == to);
        if (index < 0) { return; }
        from.Neighbors.RemoveAt(index);
        if (IsWeighted) { from.Weights.RemoveAt(index); }

        if (!IsDirected)
        {
            index = to.Neighbors.FindIndex(n => n == from);
            if (index < 0) { return; }
            to.Neighbors.RemoveAt(index);
            if (IsWeighted) { to.Weights.RemoveAt(index); }
        }
    }
    #endregion

    #region Depth-First Search
    public List<Node<T>> DFS()
    {
        bool[] isVisited = new bool[Nodes.Count];
        List<Node<T>> result = [];
        DFS(isVisited, Nodes[0], result);
        return result;
    }

    private void DFS(bool[] isVisited, Node<T> node, List<Node<T>> result)
    {
        result.Add(node);
        isVisited[node.Index] = true;

        foreach (Node<T> neighbor in node.Neighbors)
        {
            if (!isVisited[neighbor.Index])
            {
                DFS(isVisited, neighbor, result);
            }
        }
    }
    #endregion

    #region Breadth-First Search
    public List<Node<T>> BFS() => BFS(Nodes[0]);

    private List<Node<T>> BFS(Node<T> node)
    {
        bool[] isVisited = new bool[Nodes.Count];
        isVisited[node.Index] = true;

        List<Node<T>> result = [];
        Queue<Node<T>> queue = [];
        queue.Enqueue(node);
        while (queue.Count > 0)
        {
            Node<T> next = queue.Dequeue();
            result.Add(next);

            foreach (Node<T> neighbor in next.Neighbors)
            {
                if (!isVisited[neighbor.Index])
                {
                    isVisited[neighbor.Index] = true;
                    queue.Enqueue(neighbor);
                }
            }
        }

        return result;
    }
    #endregion

    #region Minimum Spanning Tree - Kruskal's algorithm
    public List<Edge<T>> MSTKruskal()
    {
        List<Edge<T>> edges = GetEdges();
        edges.Sort((a, b) => a.Weight.CompareTo(b.Weight));
        Queue<Edge<T>> queue = new(edges);

        Subset<T>[] subsets = new Subset<T>[Nodes.Count];
        for (int i = 0; i < Nodes.Count; i++)
        {
            subsets[i] = new() { Parent = Nodes[i] };
        }

        List<Edge<T>> result = [];
        while (result.Count < Nodes.Count - 1)
        {
            Edge<T> edge = queue.Dequeue();
            Node<T> from = GetRoot(subsets, edge.From);
            Node<T> to = GetRoot(subsets, edge.To);
            if (from == to) { continue; }
            result.Add(edge);
            Union(subsets, from, to);
        }

        return result;
    }

    private Node<T> GetRoot(Subset<T>[] ss, Node<T> node)
    {
        int i = node.Index;
        ss[i].Parent = ss[i].Parent != node
            ? GetRoot(ss, ss[i].Parent)
            : ss[i].Parent;
        return ss[i].Parent;
    }

    private void Union(Subset<T>[] ss, Node<T> a, Node<T> b)
    {
        ss[b.Index].Parent = ss[a.Index].Rank >= ss[b.Index].Rank
            ? a : ss[b.Index].Parent;
        ss[a.Index].Parent = ss[a.Index].Rank < ss[b.Index].Rank
            ? b : ss[a.Index].Parent;
        if (ss[a.Index].Rank == ss[b.Index].Rank) { ss[a.Index].Rank++; }
    }
    #endregion

    #region Minimum Spanning Tree - Prim's algorithm
    public List<Edge<T>> MSTPrim()
    {
        int[] previous = new int[Nodes.Count];
        previous[0] = -1;

        int[] minWeight = new int[Nodes.Count];
        Array.Fill(minWeight, int.MaxValue);
        minWeight[0] = 0;

        bool[] isInMST = new bool[Nodes.Count];
        Array.Fill(isInMST, false);

        for (int i = 0; i < Nodes.Count - 1; i++)
        {
            int mwi = GetMinWeightIndex(minWeight, isInMST);
            isInMST[mwi] = true;

            for (int j = 0; j < Nodes.Count; j++)
            {
                Edge<T>? edge = this[mwi, j];
                int weight = edge != null ? edge.Weight : -1;
                if (edge != null && !isInMST[j] && weight < minWeight[j])
                {
                    previous[j] = mwi;
                    minWeight[j] = weight;
                }
            }
        }

        List<Edge<T>> result = [];
        for (int i = 1; i < Nodes.Count; i++)
        {
            result.Add(this[previous[i], i]!);
        }

        return result;
    }

    private int GetMinWeightIndex(int[] weights, bool[] isInMST)
    {
        int minValue = int.MaxValue;
        int minIndex = 0;

        for (int i = 0; i < Nodes.Count; i++)
        {
            if (!isInMST[i] && weights[i] < minValue)
            {
                minValue = weights[i];
                minIndex = i;
            }
        }

        return minIndex;
    }
    #endregion

    #region Coloring
    public int[] Color()
    {
        int[] colors = new int[Nodes.Count];
        Array.Fill(colors, -1);
        colors[0] = 0;

        bool[] available = new bool[Nodes.Count];
        for (int i = 1; i < Nodes.Count; i++)
        {
            Array.Fill(available, true);

            foreach (Node<T> neighbor in Nodes[i].Neighbors)
            {
                int ci = colors[neighbor.Index];
                if (ci >= 0) { available[ci] = false; }
            }

            colors[i] = Array.IndexOf(available, true);
        }

        return colors;
    }
    #endregion

    #region Shortest Path
    public List<Edge<T>> GetShortestPath(
    Node<T> source, Node<T> target)
    {
        int[] previous = new int[Nodes.Count];
        Array.Fill(previous, -1);

        int[] distances = new int[Nodes.Count];
        Array.Fill(distances, int.MaxValue);
        distances[source.Index] = 0;

        SimplePriorityQueue<Node<T>> nodes = new();
        for (int i = 0; i < Nodes.Count; i++)
        {
            nodes.Enqueue(Nodes[i], distances[i]);
        }

        while (nodes.Count != 0)
        {
            Node<T> node = nodes.Dequeue();
            for (int i = 0; i < node.Neighbors.Count; i++)
            {
                Node<T> neighbor = node.Neighbors[i];
                int weight = i < node.Weights.Count ? node.Weights[i] : 0;
                int wTotal = distances[node.Index] + weight;

                if (distances[neighbor.Index] > wTotal)
                {
                    distances[neighbor.Index] = wTotal;
                    previous[neighbor.Index] = node.Index;
                    nodes.UpdatePriority(neighbor, distances[neighbor.Index]);
                }
            }
        }

        List<int> indices = [];
        int index = target.Index;
        while (index >= 0)
        {
            indices.Add(index);
            index = previous[index];
        }

        indices.Reverse();
        List<Edge<T>> result = [];
        for (int i = 0; i < indices.Count - 1; i++)
        {
            Edge<T> edge = this[indices[i], indices[i + 1]]!;
            result.Add(edge);
        }

        return result;
    }
    #endregion
}
