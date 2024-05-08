// BST VISUALIZATION
// Chapter 7 (Variants of Trees)
// C# Data Structures and Algorithms, Second Edition

BinarySearchTree<int> tree = new();
tree.Root = new BinaryTreeNode<int>() { Data = 100 };
tree.Root.Left = new() { Data = 50, Parent = tree.Root };
tree.Root.Right = new() { Data = 150, Parent = tree.Root };
tree.Count = 3;
Visualize(tree, "BST with 3 nodes (50, 100, 150):");

tree.Add(75);
tree.Add(125);
Visualize(tree, "BST after adding 2 nodes (75, 125):");

tree.Add(25);
tree.Add(175);
tree.Add(90);
tree.Add(110);
tree.Add(135);
Visualize(tree, "BST after adding 5 nodes (25, 175, 90, 110, 135):");

tree.Remove(25);
Visualize(tree, "BST after removing the node 25:");

tree.Remove(50);
Visualize(tree, "BST after removing the node 50:");

tree.Remove(100);
Visualize(tree, "BST after removing the node 100:");

foreach (TraversalEnum mode in Enum.GetValues<TraversalEnum>())
{
    Console.Write($"\n{mode} traversal:\t");
    Console.Write(string.Join(", ", tree.Traverse(mode).Select(n => n.Data)));
}

void Visualize(BinarySearchTree<int> tree, string caption)
{
    char[,] console = Initialize(tree, out int width);
    VisualizeNode(tree.Root, 0, width / 2, console, width);
    Console.WriteLine(caption);
    Draw(console);
}

void Draw(char[,] console)
{
    for (int y = 0; y < console.GetLength(0); y++)
    {
        for (int x = 0; x < console.GetLength(1); x++)
        {
            Console.Write(console[y, x]);
        }
        Console.WriteLine();
    }
}

const int ColumnWidth = 5;

char[,] Initialize(BinarySearchTree<int> tree,
    out int width)
{
    int height = tree.GetHeight();
    width = (int)Math.Pow(2, height) - 1;
    char[,] console = new char[height * 2, ColumnWidth * width];
    for (int y = 0; y < console.GetLength(0); y++)
    {
        for (int x = 0; x < console.GetLength(1); x++)
        {
            console[y, x] = ' ';
        }
    }
    return console;
}

void VisualizeNode(BinaryTreeNode<int>? node, int row, int column, char[,] console, int width)
{
    if (node == null) { return; }

    char[] chars = node.Data.ToString().ToCharArray();
    int margin = (ColumnWidth - chars.Length) / 2;
    for (int i = 0; i < chars.Length; i++)
    {
        int col = ColumnWidth * column + i + margin;
        console[row, col] = chars[i];
    }

    int columnDelta = (width + 1) / (int)Math.Pow(2, node.GetHeight() + 1);
    VisualizeNode(node.Left, row + 2, column - columnDelta, console, width);
    VisualizeNode(node.Right, row + 2, column + columnDelta, console, width);
    DrawLineLeft(node, row, column, console, columnDelta);
    DrawLineRight(node, row, column, console, columnDelta);
}

void DrawLineLeft(BinaryTreeNode<int> node, int row, int column, char[,] console, int columnDelta)
{
    if (node.Left == null) { return; }

    int sci = ColumnWidth * (column - columnDelta) + 2;
    int eci = ColumnWidth * column + 2;
    for (int x = sci + 1; x < eci; x++)
    {
        console[row + 1, x] = '-';
    }

    console[row + 1, sci] = '+';
    console[row + 1, eci] = '+';
}

void DrawLineRight(BinaryTreeNode<int> node, int row, int column, char[,] console, int columnDelta)
{
    if (node.Right == null) { return; }

    int sci = ColumnWidth * column + 2;
    int eci = ColumnWidth * (column + columnDelta) + 2;
    for (int x = sci + 1; x < eci; x++)
    {
        console[row + 1, x] = '-';
    }

    console[row + 1, sci] = '+';
    console[row + 1, eci] = '+';
}
