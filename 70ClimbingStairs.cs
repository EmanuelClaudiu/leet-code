namespace LeetCode
{
    internal class _70ClimbingStairs
    {
        int[] _numberOfStairs;

        public void Run()
        {

        }

        public int ClimbStairs(int n)
        {
            _numberOfStairs = new int[n + 1];

            return Fibonacci(n);
        }

        private int Fibonacci(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            if (n == 2) return 2;

            if (_numberOfStairs[n] != 0) return _numberOfStairs[n];

            var value = Fibonacci(n - 1) + Fibonacci(n - 2);
            _numberOfStairs[n] = value;
            return value;
        }
    }
}
