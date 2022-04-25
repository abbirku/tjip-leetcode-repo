// TC: O(N)
// MC: O(N)
public class DetectSquares {
    
    Dictionary<(int, int), int> points;
    public DetectSquares()
    {
        points = new Dictionary<(int, int), int>();
    }

    public void Add(int[] point)
    {
        if (points.ContainsKey((point[0], point[1])))
            points[(point[0], point[1])] += 1;
        else
            points.Add((point[0], point[1]), 1);
    }

    public int Count(int[] point)
    {
        var total = 0;
        foreach (var p in points)
        {
            var x1 = point[0];
            var y1 = point[1];
            var x3 = p.Key.Item1;
            var y3 = p.Key.Item2;
            if (points.ContainsKey((x3, y1)) && points.ContainsKey((x1, y3))
                && Math.Abs(x3 - x1) == Math.Abs(y3 - y1) && ((x3 != x1) || (y3 != y1)))
                total += points[(x3, y1)] * points[(x1, y3)] * points[(x3, y3)];
        }
        return total;
    }
}