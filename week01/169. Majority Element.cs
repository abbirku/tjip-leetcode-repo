public class Solution {
    public int MajorityElement(int[] nums) {
        var valueCounter = new Dictionary<int, int>();
        var finalRes = 0;
        var maxCount = -1;
        
        for(int i=0;i<nums.Length;i++){
            if(!valueCounter.ContainsKey(nums[i])){
                valueCounter.Add(nums[i], 0);
            }else{
                valueCounter[nums[i]] += 1;
            }
        }
        
        foreach(var item in valueCounter){
            if(item.Value > maxCount){
                finalRes = item.Key;
                maxCount = item.Value;
            }
        }
        
        return finalRes;
    }
}