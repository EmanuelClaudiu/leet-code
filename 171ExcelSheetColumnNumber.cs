namespace LeetCode
{
    internal class _171ExcelSheetColumnNumber
    {
        public void Run()
        {
            string columnTitle = "ZY";

            Console.WriteLine(TitleToNumber(columnTitle));
        }

        public int TitleToNumber(string columnTitle)
        {
            if (columnTitle.Length == 1) return ConvertToColumn(columnTitle[0]);

            if (columnTitle.Length == 2) return ConvertToColumn(columnTitle[1]) + (26 * ConvertToColumn(columnTitle[0]));

            return ConvertToColumn(columnTitle[^1]) + (26 * TitleToNumber(columnTitle[..^1]));
        }

        private int ConvertToColumn(char letter)
        {
            return (int)letter - 64;
        }
    }
}
