namespace LeetCode
{
    internal class _200NumberOfIslands
    {
        private int[][] _marked = [];

        public void Run()
        {
            //char[][] grid = [
            //  ['1','1','1','1','0'],
            //  ['1','1','0','1','0'],
            //  ['1','1','0','0','0'],
            //  ['0','0','0','0','0']];

            //char[][] grid = [
            //  ['1','1','0','0','0'],
            //  ['1','1','0','0','0'],
            //  ['0','0','1','0','0'],
            //  ['0','0','0','1','1']];

            char[][] grid = [
                ['1', '0', '1', '1', '1'], 
                ['1', '0', '1', '0', '1'], 
                ['1', '1', '1', '0', '1']];

            var sol = NumIslands(grid);
            Console.WriteLine(sol);
        }

        public int NumIslands(char[][] grid)
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
                    if (grid[i][j] == '1')
                    {
                        if (_marked[i][j] != 0) continue;

                        numberOfIslands++;
                        MarkIsland(i, j, rows, cols, numberOfIslands, grid);
                    }
                }
            }

            return numberOfIslands;
        }

        private void MarkIsland(int x, int y, int rows, int cols, int step, char[][] grid)
        {
            if (x < 0 || x >= rows) return;
            if (y < 0 || y >= cols) return;

            if (grid[x][y] == '0') return;

            if (_marked[x][y] != 0) return;

            _marked[x][y] = step;

            MarkIsland(x, y + 1, rows, cols, step, grid);
            MarkIsland(x, y - 1, rows, cols, step, grid);
            MarkIsland(x + 1, y, rows, cols, step, grid);
            MarkIsland(x - 1, y, rows, cols, step, grid);
        }
    }
}
