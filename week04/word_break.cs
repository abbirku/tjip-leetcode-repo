// TC: O(N)
// MC: O(N)
public class TrieNode
{
	public bool IsWord;
	public TrieNode[] Nodes;

	public TrieNode()
		=> Nodes = new TrieNode[26];
}

public class Solution
{
	TrieNode root;

	public Solution()
	{
		root = new TrieNode();
	}

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
	}

	private bool Search(string word)
	{
		var currentNode = root;

		foreach (var ch in word)
		{
			var index = ch - 'a';

			if (currentNode.Nodes[index] == null)
				return false;

			currentNode = currentNode.Nodes[index];
		}

		return currentNode != null && currentNode.IsWord;
	}

	public bool CanBreak(string str, Dictionary<string, bool> dictionary)
	{
		if (string.IsNullOrEmpty(str))
			return true;

		for (int i = 1; i <= str.Length; i++)
		{
			var prefix = str.Substring(0, i);
			var sufix = string.Empty;

			if (i != str.Length)
				sufix = str.Substring(i, str.Length - i);

			if (!dictionary.ContainsKey(prefix))
				dictionary.Add(prefix, Search(prefix));

			if (!dictionary.ContainsKey(sufix))
			{
				var res = CanBreak(sufix, dictionary);
				if (!dictionary.ContainsKey(sufix))
					dictionary.Add(sufix, res);
			}

			if (dictionary[prefix] && dictionary[sufix])
				return true;
		}

		return false;
	}

	public bool WordBreak(string s, IList<string> wordDict)
	{
		var dictionary = new Dictionary<string, bool>();
		foreach (var word in wordDict)
			Insert(word);

		var res = CanBreak(s, dictionary);

		return res;
	}
}