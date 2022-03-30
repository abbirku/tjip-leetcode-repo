public class Solution {
    public int FirstMissingPositive(int[] nums)
    {
        double maxNum = nums.Max();
        var hashSet = new HashSet<int>(nums);
        for (int i = 1; i <= maxNum + 1; i++)
        {
            if (!hashSet.Contains(i))
            {
                return i;
            }
        }
        return 0;
    }
}