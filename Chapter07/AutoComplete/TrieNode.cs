// AUTO-COMPLETE
// Chapter 7 (Variants of Trees)
// C# Data Structures and Algorithms, Second Edition

public class TrieNode
{
    public TrieNode[] Children { get; set; } = new TrieNode[26];
    public bool IsWord { get; set; } = false;
}
