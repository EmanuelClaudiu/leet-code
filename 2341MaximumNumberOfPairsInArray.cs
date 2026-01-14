namespace LeetCode
{
    internal class _2341MaximumNumberOfPairsInArray
    {
        private Dictionary<int, int> _occurences = [];
        private int _duplicates = 0;

        public void Run()
        {
            int[] nums = [1, 3, 2, 1, 3, 2, 2];

            var sol = NumberOfPairs(nums);

            foreach (var num in sol)
            {
                Console.Write($"{num} ");
            }
            Console.WriteLine();
        }

        public int[] NumberOfPairs(int[] nums)
        {
            var leftover = ProcessOutDuplicates(nums);

            return [_duplicates, leftover.Length];
        }

        private int[] ProcessOutDuplicates(int[] nums)
        {
            _occurences = [];

            for (int i = 0; i < nums.Length; i++)
            {
                if (_occurences.Keys.Contains(nums[i]))
                {
                    _duplicates++;
                    var duplicateIndex = _occurences[nums[i]];
                    _occurences.Remove(nums[i]);

                    var arrayUntilDuplicate = SubArray(nums, 0, duplicateIndex);
                    var arrayFromDuplicateToCurrent = SubArray(nums, duplicateIndex + 1, i - duplicateIndex - 1);
                    var arrayFromCurrentToEnd = SubArray(nums, i + 1, nums.Length - i - 1);

                    return ProcessOutDuplicates([.. arrayUntilDuplicate, .. arrayFromDuplicateToCurrent, .. arrayFromCurrentToEnd]);
                }

                _occurences.Add(nums[i], i);
            }

            return nums;
        }

        private int[] SubArray(int[] data, int index, int length)
        {
            int[] result = new int[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }
    }
}
