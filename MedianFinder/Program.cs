public class MedianFinder
{
    private readonly PriorityQueue<int, int> minHeap;
    private readonly PriorityQueue<int, int> maxHeap;

    public MedianFinder()
    {
        minHeap = new PriorityQueue<int, int>();
        maxHeap = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
    }

    public void AddNum(int num)
    {
        if (maxHeap.Count == 0 || num <= maxHeap.Peek())
        {
            maxHeap.Enqueue(num, num);
        }
        else
        {
            minHeap.Enqueue(num, num);
        }

        if (maxHeap.Count > minHeap.Count + 1)
        {
            minHeap.Enqueue(maxHeap.Dequeue(), maxHeap.Peek());
        }
        else if (minHeap.Count > maxHeap.Count)
        {
            maxHeap.Enqueue(minHeap.Dequeue(), minHeap.Peek());
        }
    }

    public double FindMedian()
    {
        if (maxHeap.Count > minHeap.Count)
        {
            return maxHeap.Peek();
        }
        else
        {
            return (maxHeap.Peek() + minHeap.Peek()) / 2.0;
        }
    }
}

public class Program
{
    public static void Main()
    {
        MedianFinder mf = new MedianFinder();
        mf.AddNum(1);
        Console.WriteLine(mf.FindMedian()); // returns 1
        mf.AddNum(2);
        Console.WriteLine(mf.FindMedian()); // returns 1.5
        mf.AddNum(3);
        Console.WriteLine(mf.FindMedian()); // returns 2
    }
}
