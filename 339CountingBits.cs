namespace LeetCode
{
    internal class _339CountingBits
    {
        public void Run()
        {
            int n = 4;

            var sol = CountBits(n);
            foreach (var elem in sol)
            {
                Console.Write($"{elem} ");
            }
        }

        public int[] CountBits(int n)
        {
            int[] bits = [];

            bits = [ .. bits, 0];
            bits = [ .. bits, 1];
            bits = [ .. bits, 1];
            bits = [ .. bits, 2];

            if (n >= bits.Length)
            {
                bits = Process(n, bits, 4, 2);
            }

            return bits[0..(n + 1)];
        }

        private int[] Process(int n, int[] bits, int startIndex, int currentPower)
        {
            var lastMultiple = (int)Math.Pow(2, currentPower - 1);
            var currentMultiple = (int)Math.Pow(2, currentPower);

            for (int i = startIndex; i < startIndex + lastMultiple; i++)
            {
                bits = [ ..bits, bits[i - lastMultiple]];

                if (i == n) return bits;
            }

            for (int i = startIndex + lastMultiple; i < startIndex + currentMultiple; i++)
            {
                bits = [ .. bits, bits[i - currentMultiple] + 1];

                if (i == n) return bits;
            }

            return Process(n, bits, startIndex + currentMultiple, currentPower + 1);
        }
    }
}
