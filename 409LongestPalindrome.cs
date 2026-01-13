namespace LeetCode
{
    internal class _409LongestPalindrome
    {
        private Dictionary<char, int> _frequencies = [];

        public void Run()
        {
            string s = "abccccdd";

            var sol = LongestPalindrome(s);

            Console.WriteLine(sol);
        }

        public int LongestPalindrome(string s)
        {
            foreach (var character in s)
            {
                if (!_frequencies.ContainsKey(character))
                {
                    _frequencies[character] = 1;
                    continue;
                }

                _frequencies[character] = _frequencies[character] + 1;
            }

            var longestPalindromeSize = 0;
            var remainder = 0;

            foreach (var character in _frequencies.Keys)
            {
                var frequency = _frequencies[character];
                longestPalindromeSize += (frequency / 2) * 2;
                if (frequency % 2 != 0) remainder = 1;
            }

            return longestPalindromeSize + remainder;
        }
    }
}
