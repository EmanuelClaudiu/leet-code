namespace LeetCode
{
    internal class _62UniquePaths
    {
        private readonly Dictionary<string, int> _paths = [];

        public void Run()
        {
            int m = 51;
            int n = 9;

            Console.WriteLine(UniquePaths(m, n));
        }

        public int UniquePaths(int m, int n)
        {
            if (m == 1 && n == 1)
            {
                _paths.Add($"{m}-{n}", 1);
                return 1;
            }

            if (m == 0 || n == 0)
            {
                _paths.Add($"{m}-{n}", 0);
                return 0;
            }

            var pathsDownAlreadyCalculated = _paths.TryGetValue($"{m - 1}-{n}", out var uniquePathsDown);
            if (!pathsDownAlreadyCalculated)
            {
                uniquePathsDown = UniquePaths(m - 1, n);
            }

            var pathsRightAlreadyCalculated = _paths.TryGetValue($"{m}-{n - 1}", out var uniquePathsRight);
            if (!pathsRightAlreadyCalculated)
            {
                uniquePathsRight = UniquePaths(m, n - 1);
            }

            var uniquePathsFromHere = 0 + uniquePathsDown + uniquePathsRight;
            _paths.Add($"{m}-{n}", uniquePathsFromHere);

            return uniquePathsFromHere;
        }
    }
}
