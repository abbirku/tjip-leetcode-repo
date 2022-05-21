// TC: O(N)
// MC: O(N)
public class TrieNode
{
    public TrieNode[] Nodes { get; set; }
    public string Data { get; set; }

    public TrieNode()
        => Nodes = new TrieNode[26];
}

public class Solution
{
    TrieNode root;
    List<string> wordsOnBoard;
    int[] directionArr;

    public Solution()
    {
        root = new TrieNode();
        directionArr = new int[] { -1, 0, 1, 0, -1 };
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

        currentNode.Data = word;
    }

    public void SearchBoard((int, int) point, char[][] board, TrieNode current)
    {
        var nextIndex = board[point.Item1][point.Item2] - 'a';
        if (current != null && current.Nodes[nextIndex] == null)
            return;

        var cellData = board[point.Item1][point.Item2];
        board[point.Item1][point.Item2] = '#';
        current = current.Nodes[nextIndex];

        if (!string.IsNullOrWhiteSpace(current.Data))
        {
            wordsOnBoard.Add(current.Data);
            current.Data = string.Empty;
        }

        for (int i = 0; i < 4; i++)
        {
            var X = point.Item1 + directionArr[i];
            var Y = point.Item2 + directionArr[i + 1];

            if (X < 0 || Y < 0 || X > board.Length - 1 || Y > board[0].Length - 1)
                continue;

            if (board[X][Y] == '#')
                continue;

            var index = board[X][Y] - 'a';
            if(current.Nodes[index] != null)
                SearchBoard((X, Y), board, current);
        }

        board[point.Item1][point.Item2] = cellData;
    }

    public IList<string> FindWords(char[][] board, string[] words)
    {
        wordsOnBoard = new List<string>();

        foreach (var word in words)
            Insert(word);

        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[i].Length; j++)
                SearchBoard((i, j), board, root);
        }

        return wordsOnBoard;
    }
}