namespace LeetCode
{
    internal class _167TwoSumII
    {
        public void Run()
        {
            //int[] numbers = [2, 7, 11, 15];
            //int target = 9;

            //int[] numbers = [2, 3, 4];
            //int target = 6;

            int[] numbers = [-1, 0];
            int target = -1;

            var sol = TwoSum(numbers, target);
            Console.WriteLine($"{sol[0]} {sol[1]}");
        }

        public int[] TwoSum(int[] numbers, int target)
        {
            return Sauce(numbers, target, 0, numbers.Length - 1);
        }

        private int[] Sauce(int[] numbers, int target, int left, int right)
        {
            if (numbers.Length <= 1) return [];

            var sum = numbers[left] + numbers[right];

            if (sum == target) return [left + 1, right + 1];

            if (sum > target) return Sauce(numbers, target, left, right - 1);

            return Sauce(numbers, target, left + 1, right);
        }
    }
}
