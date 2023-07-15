namespace HPTest.Tools
{
    public static class StringExtentions
    {
        public static bool IsSimilar(this string first, string second)
        {
            if (first == null || second == null ||
                first.Length != second.Length) 
            { 
                return false; 
            }

            first = first.ToLower();
            second = second.ToLower();

            var firstChars = new HashSet<char>(first);
            foreach (var ch in second)
            {
                if (!firstChars.Contains(ch))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
