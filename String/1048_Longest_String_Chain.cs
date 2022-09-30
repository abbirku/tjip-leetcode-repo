public class Solution {
    private Dictionary<int, List<string>> WordLengthMap;
    private Dictionary<string, int> Memo;
        
    public Solution()
    {
        WordLengthMap = new Dictionary<int, List<string>>();
        Memo = new Dictionary<string, int>();
    }
    
    public int LongestStrChain(string[] words) {
        int maxPath = 1;
        
        foreach(var word in words)
        {
            if(!WordLengthMap.ContainsKey(word.Length))
                WordLengthMap.Add(word.Length, new List<string>());
            
            WordLengthMap[word.Length].Add(word);
        }
        
        foreach(var word in words)
            maxPath = Math.Max(maxPath, Dfs(word));
        
        return maxPath;
    }
    
    public int Dfs(string word)
    {
        // if there are no words of the next length, we're done with this path.
        if(!WordLengthMap.ContainsKey(word.Length + 1))
            return 1;
        
        // if we're computed this word before, return the result.
        if(Memo.ContainsKey(word))
            return Memo[word];
        
        int maxPath = 0;
        var nextWords = WordLengthMap[word.Length + 1];
        
        foreach(var nw in nextWords)
        {
            if(IsNextWord(word, nw))
                maxPath = Math.Max(maxPath, Dfs(nw));
        }
        
        Memo.Add(word, maxPath + 1);
        return Memo[word];
    }
    
    public bool IsNextWord(string a, string b)
    {
        int count = 0;
        
        for(int i = 0, j = 0; i < b.Length && j < a.Length && count <= 1; i++)
        {
            if(a[j] == b[i])
                j++;
            else
                count++;
        }
        
        return count <= 1;
    }
}