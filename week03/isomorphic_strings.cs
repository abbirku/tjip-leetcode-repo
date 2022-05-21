// TC: O(N)
// MC: O(N)
public class Solution {
    public bool IsIsomorphic(string s, string t, int flag = 0) {
        var map = new Dictionary<char, char>();
            
        for (int i = 0; i < s.Length; i++)
        {
            if (!map.ContainsKey(s[i]))
                map.Add(s[i], t[i]);
            else if (!map[s[i]].Equals(t[i]))
                return false;
        }

        if (flag == 0) return IsIsomorphic(t, s, 1);

        return true;
    }
}