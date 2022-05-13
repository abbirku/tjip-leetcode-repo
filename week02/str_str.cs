//TC: O(N^2)
//MC: O(1)
public class Solution {
    public int StrStr(string haystack, string needle)
    {
        if (string.IsNullOrWhiteSpace(needle))
            return 0;

        for (int i = 0; i <= haystack.Length - needle.Length; i++)
        {
            if (haystack.Substring(i, needle.Length).Equals(needle))
                return i;
        }

        return -1;
    }
}

//TC: O(N)
//MC: O(N)
public class Solution
{
	int Base = 29;
	int MOD = 1000000007; //(10^9+7) is a prime number
	long[] haystackHash;
	long[] po;

	public void CalculateHashPo(string str)
	{
		haystackHash[0] = str[0];
		for (int i = 1; i < str.Length; i++)
		{
			haystackHash[i] = (haystackHash[i - 1] * Base + str[i]) % MOD;
			po[i] = po[i - 1] * Base % MOD;
		}
	}

	public long GetRangeHash(int l, int r)
	{
		var x1 = haystackHash[r];
		var x2 = l == 0 ? 0 : haystackHash[l - 1] * po[r - l + 1] % MOD;
		return (x1 - x2 + MOD) % MOD;
	}

	public long GenerateHash(string str)
	{
		long hashNum = 0;
		foreach (var ch in str)
			hashNum = (hashNum * Base + ch) % MOD;
		return hashNum;
	}

	public int StrStr(string haystack, string needle)
	{
		haystackHash = new long[haystack.Length];
		po = Enumerable.Repeat<long>(1, haystack.Length).ToArray();
		CalculateHashPo(haystack);

		if (string.IsNullOrWhiteSpace(needle))
			return 0;

		var hl = haystack.Length;
		var nl = needle.Length;
		var needleHash = GenerateHash(needle);

		for (int i = 0; i <= hl - nl; i++)
		{
			if (GetRangeHash(i, i + nl - 1) == needleHash)
				return i;
		}

		return -1;
	}
}