public class Solution {
    public bool IsBetween(int[] arr, int val)
        => arr[0] <= val && val <= arr[1];

    public int[][] Merge(int[][] intervals)
    {
        var finalRes = new List<int[]>();

        intervals = intervals.OrderBy(x => x[0]).ToArray();

        foreach (var item in intervals)
        {
            if (finalRes.Count == 0)
            {
                finalRes.Add(item);
                continue;
            }

            var topItem = finalRes[finalRes.Count - 1];

            if (IsBetween(topItem, item[0]) && IsBetween(topItem, item[1]))
                continue;
            if (IsBetween(topItem, item[0]) && topItem[1] < item[1])
                topItem[1] = item[1];
            else
                finalRes.Add(item);
        }

        return finalRes.ToArray();
    }
}