public class TrieNode
{
    public bool IsWord;
    public TrieNode[] Nodes;
    public int count;

    public TrieNode()
        => Nodes = new TrieNode[26];
}

public class Solution
{
    TrieNode root;

    private void Insert(string word)
    {
        var currentNode = root;

        foreach (var ch in word)
        {
            var index = ch - 'a';

            if (currentNode.Nodes[index] == null)
                currentNode.Nodes[index] = new TrieNode();

            currentNode = currentNode.Nodes[index];
        }

        currentNode.IsWord = true;
        currentNode.count += 1;
    }

    private void CountSubSequence(string str, int i, ref int count, TrieNode node)
    {
        if (i > str.Length)
            return;

        for (int j = 0; j < 26; j++)
        {
            if (node.Nodes[j] != null)
            {
                var index = str.IndexOf((char)('a' + j), i);
                if (index != -1)
                    CountSubSequence(str, index + 1, ref count, node.Nodes[j]);
            }
        }

        if (node.IsWord)
            count += node.count;
    }

    public int NumMatchingSubseq(string s, string[] words)
    {
        root = new TrieNode();
        var count = 0;

        foreach (var word in words)
            Insert(word);

        CountSubSequence(s, 0, ref count, root);

        return count;
    }
}