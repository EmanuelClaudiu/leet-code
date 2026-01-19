namespace LeetCode
{
    internal class _322CoinChange
    {
        public void Run()
        {
            int[] coins = [1, 2147483647];
            int amount = 2;

            Console.WriteLine(CoinChange(coins, amount));
        }

        public int CoinChange(int[] coins, int amount)
        {
            int[] memo = new int[amount + 1];
            Array.Fill(memo, -2);

            return Process(coins, amount, memo);
        }

        public int Process(int[] coins, int amount, int[] memo)
        {
            if (amount == 0) return 0;
            if (amount < 0) return -1;

            if (memo[amount] != -2) return memo[amount];

            int minCoins = int.MaxValue;

            foreach (int coin in coins)
            {
                int result = Process(coins, amount - coin, memo);

                if (result >= 0)
                {
                    minCoins = Math.Min(minCoins, result + 1);
                }
            }

            memo[amount] = (minCoins == int.MaxValue) ? -1 : minCoins;
            return memo[amount];
        }
    }
}
