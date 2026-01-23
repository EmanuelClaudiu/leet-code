namespace LeetCode
{
    internal class _75SortColors
    {
        private Dictionary<int, int> _colors = new Dictionary<int, int>
        {
            { 0, 0 },
            { 1, 0 },
            { 2, 0 }
        };

        public void Run()
        {
            int[] nums = [2, 0, 2, 1, 1, 0];

            SortColors(nums);

            for (int i = 0; i < nums.Length; i++)
            {
                Console.Write($"{nums[i]} ");
            }
            Console.WriteLine();
        }

        public void SortColors(int[] nums)
        {
            foreach (var color in nums)
            {
                _colors[color] += 1;
            }

            int index = 0;

            for (int i = 1; i <= _colors[0]; i++)
            {
                nums[index] = 0;
                index++;
            }

            for (int i = 1; i <= _colors[1]; i++)
            {
                nums[index] = 1;
                index++;
            }

            for (int i = 1; i <= _colors[2]; i++)
            {
                nums[index] = 2;
                index++;
            }
        }
    }
}
