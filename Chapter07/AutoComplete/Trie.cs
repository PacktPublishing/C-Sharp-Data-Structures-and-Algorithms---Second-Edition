// AUTO-COMPLETE
// Chapter 7 (Variants of Trees)
// C# Data Structures and Algorithms, Second Edition

public class Trie
{
    private readonly TrieNode _root = new();

    public bool DoesExist(string word)
    {
        TrieNode current = _root;
        foreach (char c in word)
        {
            TrieNode child = current.Children[c - 'a'];
            if (child == null) { return false; }
            current = child;
        }
        return current.IsWord;
    }

    public void Insert(string word)
    {
        TrieNode current = _root;
        foreach (char c in word)
        {
            int i = c - 'a';
            current.Children[i] = current.Children[i] ?? new();
            current = current.Children[i];
        }
        current.IsWord = true;
    }

    public List<string> SearchByPrefix(string prefix)
    {
        TrieNode current = _root;
        foreach (char c in prefix)
        {
            TrieNode child = current.Children[c - 'a'];
            if (child == null) { return []; }
            current = child;
        }

        List<string> results = [];
        GetAllWithPrefix(current, prefix, results);
        return results;
    }

    private void GetAllWithPrefix(TrieNode node, string prefix, List<string> results)
    {
        if (node == null) { return; }
        if (node.IsWord) { results.Add(prefix); }

        for (char c = 'a'; c <= 'z'; c++)
        {
            GetAllWithPrefix(node.Children[c - 'a'], prefix + c, results);
        }
    }
}
