// TC: O(N)
// MC: O(N)

public class TrieNode
{
	public bool IsWord;
	public TrieNode[] Nodes;

	public TrieNode()
		=> Nodes = new TrieNode[26];
}

public class Trie
{
	TrieNode root;

	public Trie()
		=> root = new TrieNode();

	public void Insert(string word)
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
	}

	public bool Search(string word, bool isPrefixSearch = false)
	{
		var currentNode = root;

		foreach (var ch in word)
		{
			var index = ch - 'a';

			if (currentNode.Nodes[index] == null)
				return false;

			currentNode = currentNode.Nodes[index];
		}

		return currentNode != null && (currentNode.IsWord || isPrefixSearch);
	}

	public bool StartsWith(string prefix)
		=> Search(prefix, true);
}