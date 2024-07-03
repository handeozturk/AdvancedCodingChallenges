namespace FindUniqueNumbers;

public class UniqueIntegerFinder() 
{
    public static int FindUniqueInteger(int[] nums)
    {
        int unique = 0;

        foreach (int num in nums)
        {
            unique ^= num;
        }

        return unique;
    }
}