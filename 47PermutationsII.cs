namespace LeetCode
{
    internal class _47PermutationsII
    {
        private Dictionary<string, int[][]> _permutations = [];

        public void Run()
        {
            int[] list = [1, 1, 1];

            var sol = PermuteUnique(list);

            foreach (var perm in sol)
            {
                foreach (var elem in perm)
                {
                    Console.Write($"{elem} ");
                }
                Console.WriteLine();
            }
        }

        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            if (nums.Length == 0) return [];

            if (nums.Length == 1) return [[nums[0]]];

            var listStringRepresentation = Stringify(nums);

            if (_permutations.ContainsKey(listStringRepresentation)) return _permutations[listStringRepresentation];

            int[][] permutations = [];
            HashSet<string> permutationsStrings = [];

            for (int i = 0; i < nums.Length; i++)
            {
                var listLeft = nums.Take(i).ToArray();
                var listRight = nums.Skip(i + 1).ToArray();

                var permutationsFromRest = PermuteUnique([.. listLeft, .. listRight]);

                foreach (var perm in permutationsFromRest)
                {
                    int[] newPerm = [nums[i], .. perm];
                    var newPermStringRepresentation = Stringify(newPerm);

                    if (permutationsStrings.Contains(newPermStringRepresentation)) continue;

                    permutations = [.. permutations, [nums[i], .. perm]];
                    permutationsStrings.Add(newPermStringRepresentation);
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
