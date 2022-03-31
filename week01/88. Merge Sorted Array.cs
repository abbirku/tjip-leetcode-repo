public void Merge(int[] nums1, int m, int[] nums2, int n)
{
	int i = m - 1, j = n - 1, pointer = nums1.Length - 1;
	while (true)
	{
		if (i == -1)
		{
			nums1[pointer] = nums2[j];
			j--;
			pointer--;
		}
		else if (i != -1 && j != -1 && nums1[i] < nums2[j])
		{
			nums1[pointer] = nums2[j];
			j--;
			pointer--;
		}
		else if (i != -1 && j != -1 && nums2[j] < nums1[i])
		{
			nums1[pointer] = nums1[i];
			i--;
			pointer--;
		}
		else if (j != -1)
		{
			nums1[pointer] = nums2[j];
			j--;
			pointer--;
		}

		if (j < 0)
			break;
	}
}