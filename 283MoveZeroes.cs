namespace LeetCode
{
    internal class _283MoveZeroes
    {
        public void Run()
        {
            int[] array = [0, 1, 0, 3, 12];
            Solution(array);

            var a = 1;
        }

        public void Solution(int[] nums)
        {
            var zeroCounter = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    zeroCounter++;
                    continue;
                }

                (nums[i - zeroCounter], nums[i]) = (nums[i], nums[i - zeroCounter]);
            }
        }
    }
}
