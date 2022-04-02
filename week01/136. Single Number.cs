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

	var minVal = 999999;
	var res = 0;
	for(int i=0;i<countManager.Count();i++){
		if(minVal > countManager[i].value){
			minVal = countManager[i].value;
			res = countManager[i].Key;
		}
	}

	return res;
}