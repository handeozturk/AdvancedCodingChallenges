public static class StringAlgorithms
{
    public static int LengthOfLongestSubstring(string text)
    {
        int maxLength = 0;
        Dictionary<char, int> charIndexMap = new Dictionary<char, int>();
        int start = 0;

        for (int end = 0; end < text.Length; end++)
        {
            char ch = text[end];
            if (charIndexMap.ContainsKey(ch))
            {
                start = Math.Max(start, charIndexMap[ch] + 1);
            }
            charIndexMap[ch] = end;
            maxLength = Math.Max(maxLength, end - start + 1);
        }

        return maxLength;
    }
}