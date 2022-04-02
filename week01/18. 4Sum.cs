public class Solution {
    public class ValInd
        {
            public int Val { get; set; }
            public int Ind { get; set; }
        }

        public class CustomTypeComparer : IEqualityComparer<List<int>>
        {
            public bool Equals(List<int> x, List<int> y)
            {
                return x[0] == y[0] && x[1] == y[1] && x[2] == y[2] && x[3] == y[3];
            }

            public int GetHashCode(List<int> obj)
            {
                return $"{obj[0]}{obj[1]}{obj[2]}{obj[3]}".GetHashCode();
            }
        }

        public List<int> Sort(List<int> list)
        {
            int i, j, temp;
            bool swapped;
            for (i = 0; i < list.Count - 1; i++)
            {
                swapped = false;
                for (j = 0; j < list.Count - i - 1; j++)
                {
                    if (list[j] > list[j + 1])
                    {
                        temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                        swapped = true;
                    }
                }

                if (swapped == false)
                    break;
            }

            return list;
        }

        public void TwoSum(int[] nums, int indexOfThree, int indexOfFour, int target, HashSet<List<int>> hashSet)
        {
            var dictionary = new Dictionary<int, ValInd>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (i != indexOfThree && i != indexOfFour)
                {
                    var y = target - nums[i];
                    if (dictionary.ContainsKey(y))
                    {
                        var list = new List<int> { nums[i], dictionary[y].Val, nums[indexOfThree], nums[indexOfFour] };
                        list = Sort(list);

                        if (!hashSet.Contains(list))
                            hashSet.Add(list);

                        dictionary.Remove(y);
                    }
                    else
                    {
                        if (!dictionary.ContainsKey(nums[i]))
                            dictionary.Add(nums[i], new ValInd { Val = nums[i], Ind = i });
                    }
                }
            }
        }

        public void ThreeSum(int[] nums, int indexOfFour, int target, HashSet<List<int>> hashSet)
        {
            var dictionary = new Dictionary<int, int>();

            for (int i = indexOfFour + 1; i < nums.Length; i++)
            {
                if (!dictionary.ContainsKey(nums[i]))
                {
                    dictionary.Add(nums[i], nums[i]);
                    TwoSum(nums, i, indexOfFour, target - nums[i], hashSet);
                }
            }
        }

        public IList<IList<int>> FourSum(int[] nums, int inputTarget)
        {
            var hashSet = new HashSet<List<int>>(new CustomTypeComparer());
            var dictionary = new Dictionary<int, int>();

            if (nums == null || (nums != null && nums.Length < 4))
                return new List<IList<int>>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (!dictionary.ContainsKey(nums[i]))
                {
                    dictionary.Add(nums[i], nums[i]);
                    ThreeSum(nums, i, inputTarget - nums[i], hashSet);
                }
            }

            return hashSet.Select(x =>
            {
                return (IList<int>)x;
            }).ToList();
        }
}