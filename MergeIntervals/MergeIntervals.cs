public class MergeIntervals
{
    public static int[][] Merge(int[][] intervals)
    {
        if (intervals.Length == 0)
            return [];

        intervals = intervals.OrderBy(interval => interval[0]).ToArray();
        List<int[]> mergedIntervals = new List<int[]>();
        int[] currentInterval = intervals[0];
        mergedIntervals.Add(currentInterval);

        foreach (var interval in intervals)
        {
            int currentEnd = currentInterval[1];
            int nextStart = interval[0];
            int nextEnd = interval[1];

            if (currentEnd >= nextStart)
            {
                currentInterval[1] = Math.Max(currentEnd, nextEnd);
            }
            else
            {
                currentInterval = interval;
                mergedIntervals.Add(currentInterval);
            }
        }

        return mergedIntervals.ToArray();
    }

    public static void Main()
    {
        int[][] intervals1 = [[1, 3], [2, 6], [8, 10], [15, 18]];
        int[][] result1 = Merge(intervals1);
        foreach (var interval in result1)
        {
            Console.WriteLine($"[{interval[0]}, {interval[1]}]");
        }

        int[][] intervals2 = [[1, 4], [4, 5]];
        int[][] result2 = Merge(intervals2);
        foreach (var interval in result2)
        {
            Console.WriteLine($"[{interval[0]}, {interval[1]}]");
        }
    }
}
