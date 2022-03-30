public class Solution {
    public int FirstMissingPositive(int[] nums)
    {
        var heightNum = 0;
        var containsOne = false;

        nums = nums.Where(x => x != 0).ToArray();

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 1)
                containsOne = true;

            if (nums[i] < 0)
                nums[i] = 1;

            if (heightNum < nums[i])
                heightNum = nums[i];
        }

        if (!containsOne)
            return 1;

        for (int i = 0; i < nums.Length; i++)
        {
            var chosen = nums[i];
            chosen = chosen < 0 ? chosen * (-1) : chosen;

            if (chosen <= nums.Length)
            {
                if (chosen > 0 && nums[chosen - 1] > 0)
                    nums[chosen - 1] *= -1;
            }
        }

        var allNegative = nums.All(x => x < 0);

        if (allNegative)
            return heightNum + 1;
        else
        {
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0)
                    return i + 1;
            }
        }

        return 1;
    }
}