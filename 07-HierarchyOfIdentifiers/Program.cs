// HIERARCHY OF IDENTIFIERS
// Chapter 7 (Variants of Trees)
// C# Data Structures and Algorithms, Second Edition

Tree<int> tree = new() { Root = new() { Data = 100 } };
tree.Root.Children =
[
    new() { Data = 50, Parent = tree.Root },
    new() { Data = 1, Parent = tree.Root },
    new() { Data = 150, Parent = tree.Root }
];
tree.Root.Children[2].Children =
[
    new() { Data = 30, Parent = tree.Root.Children[2] }
];
