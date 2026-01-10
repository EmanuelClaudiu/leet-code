namespace LeetCode
{
    internal class _13RomanToInteger
    {
        public void Run()
        {
            string romanNumber = "MCMXCIV";

            Console.WriteLine(RomanToInt(romanNumber));
        }

        public int RomanToInt(string s)
        {
            if (s.Length == 0) return 0;

            if (s[0] == 'I')
            {
                if (s.Length > 1 && (s[1] == 'V' || s[1] == 'X'))
                {
                    if (s[1] == 'V') return 4 + RomanToInt(s[2..]);
                    if (s[1] == 'X') return 9 + RomanToInt(s[2..]);
                }
                return 1 + RomanToInt(s[1..]);
            }

            if (s[0] == 'V')
            {
                return 5 + RomanToInt(s[1..]);
            }

            if (s[0] == 'X')
            {
                if (s.Length > 1 && (s[1] == 'L' || s[1] == 'C'))
                {
                    if (s[1] == 'L') return 40 + RomanToInt(s[2..]);
                    if (s[1] == 'C') return 90 + RomanToInt(s[2..]);
                }
                return 10 + RomanToInt(s[1..]);
            }

            if (s[0] == 'L')
            {
                return 50 + RomanToInt(s[1..]);
            }

            if (s[0] == 'C')
            {
                if (s.Length > 1 && (s[1] == 'D' || s[1] == 'M'))
                {
                    if (s[1] == 'D') return 400 + RomanToInt(s[2..]);
                    if (s[1] == 'M') return 900 + RomanToInt(s[2..]);
                }
                return 100 + RomanToInt(s[1..]);
            }

            if (s[0] == 'D')
            {
                return 500 + RomanToInt(s[1..]);
            }

            return 1000 + RomanToInt(s[1..]);
        }
    }
}
