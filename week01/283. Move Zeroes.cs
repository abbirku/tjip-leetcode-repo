public class Solution {
    public void MoveZeroes(int[] nums) {
        var zeroCount = 0;
        var presentIndex = 0;
        
        for(int i = 0; i < nums.Count(); i++){
            if(nums[i] != 0) {
                nums[presentIndex] = nums[i];
                presentIndex++;
            } else {
                zeroCount++;
            }
        }
        
        for(int i = nums.Count()-1; zeroCount > 0; i--) {
            nums[i] = 0;
            zeroCount--;
        }
    }
}