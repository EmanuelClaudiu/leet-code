namespace LeetCode
{
    internal class _118PascalTriangle
    {
        public void Run()
        {
            var sol = Generate(5);

            var a = 1;
        }

        public IList<IList<int>> Generate(int numRows)
        {
            int[][] pascalTree = [];

            for (int levelSize = 1; levelSize <= numRows; levelSize++)
            {
                if (levelSize == 1)
                {
                    pascalTree = [.. pascalTree, [1]];
                    continue;
                }

                if (levelSize == 2)
                {
                    pascalTree = [.. pascalTree, [1, 1]];
                    continue;
                }

                var previousRow = pascalTree[levelSize - 2];
                int[] currentRow = [];


                for (int i = 0; i < levelSize; i++)
                {
                    if (i == 0)
                    {
                        currentRow = [.. currentRow, 1];
                        continue;
                    }

                    if (i == levelSize - 1)
                    {
                        currentRow = [.. currentRow, 1];
                        continue;
                    }

                    currentRow = [.. currentRow, previousRow[i - 1] + previousRow[i]];
                }

                pascalTree = [.. pascalTree, currentRow];
            }

            return pascalTree;
        }
    }
}
