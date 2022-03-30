public int SingleNumber(int[] nums)
{
	var countManager = new Dictionary<int, int>();

	for (int i = 0; i < nums.Length; i++)
	{
		if (!countManager.ContainsKey(nums[i]))
			countManager.Add(nums[i], 0);
		else
			countManager[nums[i]]++;
	}

	return countManager.OrderBy(x => x.Value).FirstOrDefault().Key;
}