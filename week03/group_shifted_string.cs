// TC: O(M * N)
// MC: O(N)
public class Solution {
    public int CalculateHash(string str)
	{
		var hash = 0;
		int MOD = 10000019;

		foreach (var ch in str)
		{
			hash = (hash * 257) + (ch - str[0] + 26) % 26 + 1;
			hash %= MOD;
		}

		return hash;
	}

	public IList<IList<string>> GroupStrings(string[] strings)
	{
		var groupedStrings = new Dictionary<int, IList<string>>();

		foreach (var str in strings)
		{
			var key = CalculateHash(str);

			if (groupedStrings.ContainsKey(key))
				groupedStrings[key].Add(str);
			else
				groupedStrings.Add(key, new List<string>
				{
					str
				});
		}

		return groupedStrings.Select(x => x.Value).ToList();
	}
}