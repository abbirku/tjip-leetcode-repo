// TC: O(N)
// MC: O(N)
public class TrieNode
{
    public bool IsWord;
    public TrieNode[] Nodes;
    public string Data;

    public TrieNode()
        => Nodes = new TrieNode[26];
}

public class Solution
{
    TrieNode root;

    public Solution()
        => root = new TrieNode();

    private void Insert(string productName)
    {
        var currentNode = root;

        foreach (var ch in productName)
        {
            var index = ch - 'a';

            if (currentNode.Nodes[index] == null)
                currentNode.Nodes[index] = new TrieNode();

            currentNode = currentNode.Nodes[index];
        }

        currentNode.IsWord = true;
        currentNode.Data = productName;
    }

    private TrieNode Search(string word, bool isPrefixSearch = false)
    {
        var currentNode = root;

        foreach (var ch in word)
        {
            var index = ch - 'a';

            if (currentNode.Nodes[index] == null)
                return null;

            currentNode = currentNode.Nodes[index];
        }

        return currentNode != null && (currentNode.IsWord || isPrefixSearch) ? currentNode : null;
    }

    private void GatherProducts(TrieNode node, List<string> suggestions)
    {
        if (node != null && node.IsWord)
            suggestions.Add(node.Data);

        for (int i = 0; i < 26; i++)
        {
            if (node != null && node.Nodes[i] != null)
                GatherProducts(node.Nodes[i], suggestions);
        }

        return;
    }

    public IList<IList<string>> SuggestedProducts(string[] products, string searchWord)
    {
        var prefix = string.Empty;
        var allSuggestions = new List<IList<string>>();

        foreach (var product in products)
            Insert(product);

        foreach (var ch in searchWord)
        {
            var suggestions = new List<string>();
            prefix += ch;
            
            var node = Search(prefix, true);
            GatherProducts(node, suggestions);

            allSuggestions.Add(suggestions.Take(3).ToList());
        }

        return allSuggestions;
    }
}