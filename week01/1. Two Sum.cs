public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        var keyValSet = new Dictionary<int, int>();
        
        for(int i=0;i < nums.Length; i++){
            var y = target - nums[i];
            if(keyValSet.ContainsKey(y)){
                return new int[] { keyValSet[y], i };
            }else if(!keyValSet.ContainsKey(nums[i])){
                keyValSet.Add(nums[i], i);
            }
        }
        
        return new int[]{};
    }
}