namespace LeetCode
{
    internal class _46Permutations
    {
        private Dictionary<string, int[][]> _permutations = new Dictionary<string, int[][]>();

        public void Run()
        {
            int[] list = [1, 1, 1];

            var sol = Permute(list);

            foreach(var perm in sol)
            {
                foreach(var elem in perm)
                {
                    Console.Write($"{elem} ");
                }
                Console.WriteLine();
            }
        }

        public IList<IList<int>> Permute(int[] nums)
        {
            if (nums.Length == 0) return [];

            if (nums.Length == 1) return [[nums[0]]];

            var listStringRepresentation = Stringify(nums);

            if (_permutations.ContainsKey(listStringRepresentation)) return _permutations[listStringRepresentation];

            int[][] permutations = [];

            for (int i = 0; i < nums.Length; i++)
            {
                var listLeft = nums.Take(i).ToArray();
                var listRight = nums.Skip(i + 1).ToArray();

                var permutationsFromRest = Permute([.. listLeft, .. listRight]);

                foreach (var perm in permutationsFromRest)
                {
                    permutations = [.. permutations, [nums[i], .. perm]];
                }
            }

            _permutations[listStringRepresentation] = permutations;

            return permutations;
        }

        private string Stringify(int[] nums)
        {
            string toReturn = "";

            for (int i = 0; i < nums.Length; i++)
            {
                toReturn += $"{nums[i]},";
            }

            return toReturn;
        }
    }
}
