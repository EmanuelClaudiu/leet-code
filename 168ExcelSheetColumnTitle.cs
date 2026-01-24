namespace LeetCode
{
    internal class _168ExcelSheetColumnTitle
    {
        public void Run()
        {
            int columnNumber = 2147483647;

            Console.WriteLine(ConvertToTitle(columnNumber));
        }

        public string ConvertToTitle(int columnNumber)
        {
            if (columnNumber <= 26) return ConvertToSingleLetter(columnNumber).ToString();

            return FactorOut(columnNumber);
        }

        private string FactorOut(int sum)
        {
            var b = sum % 26;
            if (b == 0) b = 26;

            if (sum > 702)
            {
                return $"{FactorOut((sum - b) / 26)}{ConvertToSingleLetter(b)}";
            }

            var a = (sum - b) / 26;

            return $"{ConvertToSingleLetter(a)}{ConvertToSingleLetter(b)}";
        }

        private char ConvertToSingleLetter(int n)
        {
            return (char)(n + 64);
        }
    }
}
