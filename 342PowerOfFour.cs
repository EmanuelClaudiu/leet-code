namespace LeetCode
{
    internal class _342PowerOfFour
    {
        public void Run()
        {
            int n = 5;

            Console.WriteLine(IsPowerOfFour(n));
        }

        public bool IsPowerOfFour(int n)
        {
            return Math.Log2(n) % 2 == 0;
        }
    }
}
