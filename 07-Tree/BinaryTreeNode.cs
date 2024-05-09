// BINARY TREE NODE
// Chapter 7 (Variants of Trees)
// C# Data Structures and Algorithms, Second Edition

public class BinaryTreeNode<T>
    : TreeNode<T>
{
    public new BinaryTreeNode<T>?[] Children { get; set; } = [null, null];

    public BinaryTreeNode<T>? Left
    {
        get { return Children[0]; }
        set { Children[0] = value; }
    }

    public BinaryTreeNode<T>? Right
    {
        get { return Children[1]; }
        set { Children[1] = value; }
    }
}
