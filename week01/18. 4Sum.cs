public class Solution {
    public int GetSequenceHashCode(IList<int> sequence)
    {
        int hash = 0;

        foreach (int integer in sequence)
        {
            int x = integer;

            x ^= x >> 17;
            x *= 830770091;   // 0xed5ad4bb
            x ^= x >> 11;
            x *= -1404298415; // 0xac4c1b51
            x ^= x >> 15;
            x *= 830770091;   // 0x31848bab
            x ^= x >> 14;

            hash += x;
        }

        return hash;
    }

    public void TwoSum(int[] nums, int indexOfFour, int indexOfThree, int target, Dictionary<int, IList<int>> finalRes)
    {
        var keyValSet = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (i != indexOfThree && i != indexOfFour)
            {
                var y = target - nums[i];
                if (keyValSet.ContainsKey(y))
                {
                    var list = new List<int> { nums[i], keyValSet[y], nums[indexOfThree], nums[indexOfFour] };

                    var listHashCode = GetSequenceHashCode(list);
                    if (!finalRes.ContainsKey(listHashCode))
                        finalRes.Add(listHashCode, list);

                    keyValSet.Remove(y);
                }
                else if (!keyValSet.ContainsKey(nums[i]))
                    keyValSet.Add(nums[i], nums[i]);
            }
        }
    }

    public void ThreeSum(int[] nums, int indexOfFour, int target, Dictionary<int, IList<int>> finalRes)
    {
        var dictionary = new Dictionary<int, int>();

        for (int i = indexOfFour + 1; i < nums.Length; i++)
        {
            if (!dictionary.ContainsKey(nums[i]))
            {
                dictionary.Add(nums[i], nums[i]);
                TwoSum(nums, indexOfFour, i, target - nums[i], finalRes);
            }
        }
    }

    public IList<IList<int>> FourSum(int[] nums, int target)
    {
        if (nums == null || (nums != null && nums.Length < 4))
            return new List<IList<int>>();

        var finalRes = new Dictionary<int, IList<int>>();
        var dictionary = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (!dictionary.ContainsKey(nums[i]))
            {
                dictionary.Add(nums[i], nums[i]);
                ThreeSum(nums, i, target - nums[i], finalRes);
            }
        }

        return finalRes.Select(x => x.Value).ToList();

    }
}