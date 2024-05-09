// BINARY SEARCH TREE
// Chapter 7 (Variants of Trees)
// C# Data Structures and Algorithms, Second Edition

public class BinarySearchTree<T>
    : BinaryTree<T>
    where T : IComparable
{
    public bool Contains(T data)
    {
        BinaryTreeNode<T>? node = Root;
        while (node != null)
        {
            int result = data.CompareTo(node.Data);
            if (result == 0) { return true; }
            else if (result < 0) { node = node.Left; }
            else { node = node.Right; }
        }
        return false;
    }

    public void Add(T data)
    {
        BinaryTreeNode<T>? parent = GetParentForNewNode(data);
        BinaryTreeNode<T> node = new()
        {
            Data = data,
            Parent = parent
        };

        if (parent == null) { Root = node; }
        else if (data.CompareTo(parent.Data) < 0) { parent.Left = node; }
        else { parent.Right = node; }

        Count++;
    }

    private BinaryTreeNode<T>? GetParentForNewNode(T data)
    {
        BinaryTreeNode<T>? current = Root;
        BinaryTreeNode<T>? parent = null;
        while (current != null)
        {
            parent = current;
            int result = data.CompareTo(current.Data);
            if (result == 0)
            {
                throw new ArgumentException($"The node {data} already exists.");
            }
            else if (result < 0) { current = current.Left; }
            else { current = current.Right; }
        }
        return parent;
    }

    public void Remove(T data) => Remove(Root, data);

    private void Remove(BinaryTreeNode<T>? node, T data)
    {
        if (node == null) { return; }
        else if (data.CompareTo(node.Data) < 0) { Remove(node.Left, data); }
        else if (data.CompareTo(node.Data) > 0) { Remove(node.Right, data); }
        else
        {
            if (node.Left == null || node.Right == null)
            {
                BinaryTreeNode<T>? newNode =
                    node.Left == null && node.Right == null
                        ? null
                        : node.Left ?? node.Right;
                ReplaceInParent(node, newNode!);
                Count--;
            }
            else
            {
                BinaryTreeNode<T> successor = FindMinimumInSubtree(node.Right);
                node.Data = successor.Data;
                Remove(successor, successor.Data!);
            }
        }
    }

    private void ReplaceInParent(BinaryTreeNode<T> node, BinaryTreeNode<T> newNode)
    {
        if (node.Parent != null)
        {
            BinaryTreeNode<T> parent = (BinaryTreeNode<T>)node.Parent;
            if (parent.Left == node) { parent.Left = newNode; }
            else { parent.Right = newNode; }
        }
        else { Root = newNode; }

        if (newNode != null) { newNode.Parent = node.Parent; }
    }

    private BinaryTreeNode<T> FindMinimumInSubtree(BinaryTreeNode<T> node)
    {
        while (node.Left != null) { node = node.Left; }
        return node;
    }
}
