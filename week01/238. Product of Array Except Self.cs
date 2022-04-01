public int[] ProductExceptSelf(int[] nums)
{
	var length = nums.Length;
	var prefix = new int[length];
	var sufix = new int[length];

	prefix[0] = 1;
	sufix[length - 1] = 1;

	for (var i = 1; i < length; i++)
		prefix[i] = prefix[i - 1] * nums[i - 1];

	for (var i = length - 2; i > -1; i--)
		sufix[i] = sufix[i + 1] * nums[i + 1];

	for (var i = 0; i < length; i++)
		nums[i] = prefix[i] * sufix[i];

	return nums;
}