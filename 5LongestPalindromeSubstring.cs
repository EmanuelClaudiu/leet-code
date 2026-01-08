namespace LeetCode
{
    internal class _5LongestPalindromeSubstring
    {
        public void Run()
        {
            string s = "abcccbd";

            string sol = LongestPalindrome(s);

            Console.WriteLine(sol);
        }

        public string LongestPalindrome(string s)
        {
            var longestPalindrome = "";

            for (int i = 0; i < s.Length; i++)
            {
                int minDistanceToEdge = Math.Min(i, s.Length - i - 1); 

                for (int length = longestPalindrome.Length / 2; length <= minDistanceToEdge + 1; length++)
                {
                    int startIndex = Math.Max(0, i - length);
                    int endIndex = Math.Min(s.Length - 1, i + length);
                    int substringLength = endIndex - startIndex + 1;

                    string substring = s.Substring(startIndex, substringLength);

                    if (substring.Length > longestPalindrome.Length && IsPalindrome(substring))
                    {
                        longestPalindrome = substring;
                        continue;
                    }
                    if (substring[1..].Length > longestPalindrome.Length && IsPalindrome(substring[1..]))
                    {
                        longestPalindrome = substring[1..];
                        continue;
                    }
                    if (substring[..^1].Length > longestPalindrome.Length && IsPalindrome(substring[..^1]))
                    {
                        longestPalindrome = substring[..^1];
                        continue;
                    }
                }
            }

            return longestPalindrome;
        }

        private bool IsPalindrome(string s)
        {
            if (s.Length <= 1) return true;

            if (s[0] != s[s.Length - 1]) return false;

            return IsPalindrome(s[1..^1]);
        }
    }
}
