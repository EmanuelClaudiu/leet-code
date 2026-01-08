namespace LeetCode
{
    internal class _37SudokuSolver
    {
        char[][][] _solutions = [];

        public void Run()
        {
            //char[][] board =
            //    [['5','3','.','.','7','.','.','.','.']
            //    ,['6','.','.','1','9','5','.','.','.']
            //    ,['.','9','8','.','.','.','.','6','.']
            //    ,['8','.','.','.','6','.','.','.','3']
            //    ,['4','.','.','8','.','3','.','.','1']
            //    ,['7','.','.','.','2','.','.','.','6']
            //    ,['.','6','.','.','.','.','2','8','.']
            //    ,['.','.','.','4','1','9','.','.','5']
            //    ,['.','.','.','.','8','.','.','7','9']];

            char[][] board =
                [['.','.','.','.','.','.','.','3','1']
                ,['1','6','.','.','3','4','.','9','5']
                ,['.','.','8','.','.','9','4','6','.']
                ,['.','.','.','9','.','6','.','7','8']
                ,['8','.','.','.','.','.','.','.','.']
                ,['7','.','.','.','5','.','.','.','3']
                ,['.','.','.','.','6','8','7','2','.']
                ,['.','.','.','.','.','2','5','.','.']
                ,['2','5','4','.','.','.','3','.','.']];

            SolveSudoku(board);

            var a = 1;
        }

        public void SolveSudoku(char[][] board)
        {
            Solutionize(board);

            if (_solutions.Length != 0)
            {
                board = _solutions[0];

                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        Console.Write($"{board[i][j]} ");
                    }
                    Console.WriteLine();
                }
            }
        }

        public void Solutionize(char[][] board)
        {
            var firstEmptyCellCoordinates = GetFirstEmptyCellCoordinates(board);

            if (firstEmptyCellCoordinates.Length == 0)
            {
                if (IsValidSudoku(board))
                {
                    _solutions = [.. _solutions, DeepCopyList(board)];
                }

                return;
            }

            int elemX = firstEmptyCellCoordinates[0], elemY = firstEmptyCellCoordinates[1];

            char[][][] solutions = [];

            for (int i = 1; i <= 9; i++)
            {
                char numberToTry = (char)('0' + i);

                board[elemX][elemY] = (char)('0' + i);

                if (IsValidSudoku(board))
                {
                    Solutionize(board);
                }

                board[elemX][elemY] = '.';
            }
        }

        private int[] GetFirstEmptyCellCoordinates(char[][] board)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i][j] == '.')
                    {
                        return [i, j];
                    }
                }
            }

            return [];
        }

        private bool IsValidSudoku(char[][] board)
        {
            var rowDict = GetEmptyNineByNineList();
            var colDict = GetEmptyNineByNineList();
            var squareDict = GetEmptyNineByNineList();

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i][j] == '.') continue;

                    var number = (int)char.GetNumericValue(board[i][j]) - 1;
                    var squareIndex = GetSquareIndex(i, j);

                    if (rowDict[i][number] == 1) return false;
                    if (colDict[j][number] == 1) return false;
                    if (squareDict[squareIndex][number] == 1) return false;

                    rowDict[i][number] = 1;
                    colDict[j][number] = 1;
                    squareDict[squareIndex][number] = 1;
                }
            }

            return true;
        }

        private int GetSquareIndex(int row, int col)
        {
            if (row <= 2 && col <= 2) return 0;
            if (row <= 2 && col <= 5) return 1;
            if (row <= 2 && col <= 8) return 2;

            if (row <= 5 && col <= 2) return 3;
            if (row <= 5 && col <= 5) return 4;
            if (row <= 5 && col <= 8) return 5;

            if (col <= 2) return 6;
            if (col <= 5) return 7;
            return 8;
        }

        private int[][] GetEmptyNineByNineList()
        {
            int[][] list =
            [
                [0, 0, 0, 0, 0, 0, 0, 0, 0],
                [0, 0, 0, 0, 0, 0, 0, 0, 0],
                [0, 0, 0, 0, 0, 0, 0, 0, 0],
                [0, 0, 0, 0, 0, 0, 0, 0, 0],
                [0, 0, 0, 0, 0, 0, 0, 0, 0],
                [0, 0, 0, 0, 0, 0, 0, 0, 0],
                [0, 0, 0, 0, 0, 0, 0, 0, 0],
                [0, 0, 0, 0, 0, 0, 0, 0, 0],
                [0, 0, 0, 0, 0, 0, 0, 0, 0],
            ];
            return list;
        }

        public char[][] DeepCopyList(char[][] sourceBoard)
        {
            int rows = sourceBoard.Length;

            char[][] newBoard = new char[rows][];

            for (int i = 0; i < rows; i++)
            {
                int cols = sourceBoard[i].Length;

                newBoard[i] = new char[cols];

                for (int j = 0; j < cols; j++)
                {
                    newBoard[i][j] = sourceBoard[i][j];
                }
            }

            return newBoard;
        }
    }
}
