namespace LeetCode
{
    internal class _2194CellsInARangeOnAnExcelSheet
    {
        public void Run()
        {
            string s = "A1:F1";

            var sol = CellsInRange(s);

            foreach (var elem in sol)
            {
                Console.Write($"{elem} ");
            }
            Console.WriteLine();
        }

        public IList<string> CellsInRange(string s)
        {
            var letter1 = s[0];
            var letter2 = s[3];

            var digit1 = s[1];
            var digit2 = s[4];

            return Process(letter1, letter2, GetInteger(digit1), GetInteger(digit2));
        }

        private IList<string> Process(char currentLetter, char endLetter, int intervalStart, int intervalEnd)
        {
            string[] codes = [];

            for (int i = intervalStart; i <= intervalEnd; i++)
            {
                codes = [.. codes, $"{currentLetter}{i}"];
            }

            if (currentLetter == endLetter) return [.. codes];

            return [.. codes, .. Process((char)((int)currentLetter + 1), endLetter, intervalStart, intervalEnd)];
        }

        private int GetInteger(char digit)
        {
            return (int)digit - 48;
        }
    }
}
