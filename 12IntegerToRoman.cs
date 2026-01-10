namespace LeetCode
{
    internal class _12IntegerToRoman
    {
        public void Run()
        {
            int n = 4;

            Console.WriteLine(IntToRoman(n));
        }

        private readonly Dictionary<string, int> _symbolsWithValue = new Dictionary<string, int> 
        {
            { "M", 1000 },
            { "CM", 900 },
            { "D", 500 },
            { "CD", 400 },
            { "C", 100 },
            { "XC", 90 },
            { "L", 50 },
            { "XL", 40 },
            { "X", 10 },
            { "IX", 9 },
            { "V", 5 },
            { "IV", 4 },
            { "I", 1 },
        };

        public string IntToRoman(int num)
        {
            if (num == 0) return "";

            foreach (var symbol in _symbolsWithValue.Keys)
            {
                var symbolValue = _symbolsWithValue[symbol];
                if (symbolValue <= num)
                {
                    return symbol + IntToRoman(num - symbolValue);
                }
            }

            return "";
        }
    }
}
