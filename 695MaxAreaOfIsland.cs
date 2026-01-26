namespace LeetCode
{
    internal class _695MaxAreaOfIsland
    {
        private int[][] _marked = [];
        private Dictionary<int, int> _markedCount = [];
        private int _maxSize = 0;

        public void Run()
        {
            int[][] grid = [
                [0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0],
                [0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0],
                [0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0],
                [0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 1, 0, 0],
                [0, 1, 0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 0],
                [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0],
                [0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0],
                [0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0]];

            var sol = MaxAreaOfIsland(grid);

            Console.WriteLine(sol);
        }

        public int MaxAreaOfIsland(int[][] grid)
        {
            var numberOfIslands = 0;

            int rows = grid.Length;
            int cols = grid[0].Length;

            _marked = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                _marked[i] = [];

                for (int j = 0; j < cols; j++)
                {
                    _marked[i] = [.. _marked[i], 0];
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        if (_marked[i][j] != 0) continue;

                        numberOfIslands++;
                        _markedCount[numberOfIslands] = 0;
                        MarkIsland(i, j, rows, cols, numberOfIslands, grid);
                    }
                }
            }

            return _maxSize;
        }

        private void MarkIsland(int x, int y, int rows, int cols, int step, int[][] grid)
        {
            if (x < 0 || x >= rows) return;
            if (y < 0 || y >= cols) return;

            if (grid[x][y] == 0) return;

            if (_marked[x][y] != 0) return;

            _marked[x][y] = step;
            _markedCount[step]++;

            if (_markedCount[step] > _maxSize) _maxSize = _markedCount[step];

            MarkIsland(x, y + 1, rows, cols, step, grid);
            MarkIsland(x, y - 1, rows, cols, step, grid);
            MarkIsland(x + 1, y, rows, cols, step, grid);
            MarkIsland(x - 1, y, rows, cols, step, grid);
        }
    }
}
