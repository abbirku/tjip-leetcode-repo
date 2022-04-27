// TC: O(N)
// MC: O(1)
public class Solution {
    public int RomanToInt(string s)
    {
        var map = new Dictionary<string, int>
        {
            { "I", 1 },
            { "V", 5 },
            { "X", 10 },
            { "L", 50 },
            { "C", 100 },
            { "D", 500 },
            { "M", 1000 },
            { "IV", 4 },
            { "IX", 9 },
            { "XL", 40 },
            { "XC", 90 },
            { "CD", 400 },
            { "CM", 900 }
        };
        var index = 0;
        var total = 0;
        while (index < s.Length)
        {
            if (index <= s.Length - 2 && map.ContainsKey(s.Substring(index, 2)))
            {
                total += map[s.Substring(index, 2)];
                index += 2;
            }
            else
            {
                total += map[s.Substring(index, 1)];
                index += 1;
            }
        }
        return total;
    }
}