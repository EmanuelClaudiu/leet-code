namespace LeetCode
{
    internal class _38CountAndSay
    {
        public void Run()
        {
            int n = 4;

            var sol = CountAndSay(n);

            Console.WriteLine(sol);
        }

        public string CountAndSay(int n)
        {
            if (n == 1) return "1";

            if (n == 2) return "11";

            return RLE(CountAndSay(n - 1));
        }

        private string RLE(string sequence)
        {
            if (sequence == "") return "";

            var lastChar = sequence[sequence.Length - 1];
            var cnt = 0;

            do
            {
                cnt++;
                sequence = sequence[..^1];
            } while (sequence.Length > 0 && sequence[sequence.Length - 1] == lastChar);

            return RLE(sequence) + $"{cnt}{lastChar}";
        }
    }
}
