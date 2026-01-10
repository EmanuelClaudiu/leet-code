using System.Collections;

namespace LeetCode
{
    internal class _1TwoSum
    {
        public void Run()
        {
            int[] nums = [3, 3];

            int target = 6;

            SolutionPrint(nums, target);
        }

        public int[] Solution(int[] nums, int target)
        {
            var frequencyMatrix = new Dictionary<int, int[]>(nums.Length);

            for (int i = 0; i < nums.Length; i++)
            {
                var alreadyInFrequencyMatrix = frequencyMatrix.ContainsKey(nums[i]);

                if (!alreadyInFrequencyMatrix)
                {
                    frequencyMatrix[nums[i]] = [i];
                } 
                else
                {
                    frequencyMatrix[nums[i]] = [..frequencyMatrix[nums[i]], i];
                }
            }

            for (int i = 0; i < nums.Length; i++)
            {
                var neededForSum = target - nums[i];
                var hasNeededNumber = frequencyMatrix.TryGetValue(neededForSum, out var neededForSumIndexes);

                if (!hasNeededNumber)
                {
                    continue;
                }

                if (neededForSum == nums[i])
                {
                    if (neededForSumIndexes.Length == 1)
                    {
                        continue;
                    }
                    return frequencyMatrix[neededForSum];
                }

                return [i, frequencyMatrix[neededForSum][0]];
            }

            return [];
        }

        public void SolutionPrint(int[] nums, int target)
        {
            var solution = Solution(nums, target);
            
            if (solution.Length < 2)
            {
                Console.WriteLine("No pair found in array :(");
            }

            Console.WriteLine($"Found in array! Numbers [{solution[0]}, {solution[1]}] sum to {target}");
        }
    }
}
