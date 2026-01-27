namespace LeetCode
{
    internal class _529Minesweeper
    {
        private HashSet<string> _updated = [];

        public void Run()
        {
            //char[][] board = [
            //    ['E', 'E', 'E', 'E', 'E'], 
            //    ['E', 'E', 'M', 'E', 'E'], 
            //    ['E', 'E', 'E', 'E', 'E'], 
            //    ['E', 'E', 'E', 'E', 'E']];
            //int[] click = [3, 0];

            char[][] board = [
                ['B', '1', 'E', '1', 'B'],
                ['B', '1', 'M', '1', 'B'],
                ['B', '1', '1', '1', 'B'],
                ['B', 'B', 'B', 'B', 'B']];
            int[] click = [1, 2];

            var sol = UpdateBoard(board, click);

            foreach (var row in sol)
            {
                foreach (var elem in row)
                {
                    Console.Write($"{elem} ");
                }
                Console.WriteLine();
            }
        }

        public char[][] UpdateBoard(char[][] board, int[] click)
        {
            if (IsBomb(board, click[0], click[1]))
            {
                board[click[0]][click[1]] = 'X';
                return board;
            }

            board = Update(board, click);

            return board;
        }

        private char[][] Update(char[][] board, int[] position)
        {
            var x = position[0];
            var y = position[1];
            if (_updated.Contains($"{x}-{y}")) return board;

            var rows = board.Length;
            var cols = board[0].Length;
            if (x < 0 || x >= rows || y < 0 || y >= cols) return board;

            var adjacentBombs = AdjacentBombs(board, x, y);
            _updated.Add($"{x}-{y}");

            if (adjacentBombs > 0)
            {
                board[x][y] = adjacentBombs.ToString()[0];
                return board;
            }

            board[x][y] = 'B';

            board = Update(board, [x - 1, y - 1]);
            board = Update(board, [x - 1, y]);
            board = Update(board, [x - 1, y + 1]);
            board = Update(board, [x, y - 1]);
            board = Update(board, [x, y + 1]);
            board = Update(board, [x + 1, y - 1]);
            board = Update(board, [x + 1, y]);
            board = Update(board, [x + 1, y + 1]);

            return board;
        }

        private int AdjacentBombs(char[][] board, int x, int y)
        {
            var adjacentBombs = 0;

            if (IsBomb(board, x - 1, y - 1)) adjacentBombs++;
            if (IsBomb(board, x - 1, y)) adjacentBombs++;
            if (IsBomb(board, x - 1, y + 1)) adjacentBombs++;
            if (IsBomb(board, x, y - 1)) adjacentBombs++;
            if (IsBomb(board, x, y + 1)) adjacentBombs++;
            if (IsBomb(board, x + 1, y - 1)) adjacentBombs++;
            if (IsBomb(board, x + 1, y)) adjacentBombs++;
            if (IsBomb(board, x + 1, y + 1)) adjacentBombs++;

            return adjacentBombs;
        }

        private bool IsBomb(char[][] board, int x, int y)
        {
            if (x < 0 || x >= board.Length) return false;
            if (y < 0 || y >= board[0].Length) return false;

            return board[x][y] == 'M';
        }
    }
}
