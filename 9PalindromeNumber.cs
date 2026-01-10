namespace LeetCode
{
    internal class _9PalindromeNumber
    {
        public void Run()
        {
            int n = 11;

            var numberString = n.ToString();
            var numberString1 = numberString.Substring(1, numberString.Length - 2);

            Console.WriteLine(IsPalindrome(n));
        }

        public bool IsPalindrome(int x)
        {
            return IsPalindrome(x.ToString());
        }

        private bool IsPalindrome(string numberString)
        {
            if (numberString.Length <= 1) return true;

            if (numberString[0] != numberString[numberString.Length - 1]) return false;

            return IsPalindrome(numberString.Substring(1, numberString.Length - 2));
        }
    }
}
