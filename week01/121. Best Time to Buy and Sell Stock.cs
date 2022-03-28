public class Solution {
    public int MaxProfit(int[] prices) {
        int minPrice = 10001;
        int maxProfit = 0;
        
        for(int i=0;i<prices.Count();i++){
            if(minPrice > prices[i]){
                minPrice = prices[i];
            }
            if(i+1 < prices.Count() && prices[i+1] - minPrice > maxProfit){
                maxProfit = prices[i+1] - minPrice;
            }
        }
        
        return maxProfit;
    }
}