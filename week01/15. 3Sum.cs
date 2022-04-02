public class Solution {
    public List<int> Sort(List<int> list)
        {
            if(list[1] < list[0])
            {
                var temp = list[1];
                list[1] = list[0];
                list[0] = temp;
            }

            if (list[2] < list[1])
            {
                var temp = list[2];
                list[2] = list[1];
                list[1] = temp;
            }

            if (list[1] < list[0])
            {
                var temp = list[1];
                list[1] = list[0];
                list[0] = temp;
            }

            return list;
        }

        public List<IList<int>> TwoSum(int[] nums, int index, int target, List<IList<int>> finalRes)
        {
            var hash = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if(i != index)
                {
                    var y = target - nums[i];
                    if (hash.ContainsKey(y))
                    {
                        var list = new List<int> { nums[i], hash[y], nums[index] };
                        list = Sort(list);

                        if (finalRes.Where(x => x.SequenceEqual(list)).ToList().Count == 0)
                            finalRes.Add(list);

                        hash.Remove(y);
                    }
                    else
                    {
                        if(!hash.ContainsKey(nums[i]))
                            hash.Add(nums[i], nums[i]);
                    }
                }
            }

            return finalRes;
        }

        public IList<IList<int>> ThreeSum(int[] nums)
        {
            if (nums == null || (nums != null && nums.Length < 3))
                return new List<IList<int>>();

            var finalRes = new List<IList<int>>();

            for (int i = 0; i < nums.Length; i++)
                TwoSum(nums, i, nums[i] * (-1), finalRes);

            return finalRes;
        }
}