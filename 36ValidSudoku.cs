namespace LeetCode
{
    internal class _36ValidSudoku
    {
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
                [['8','3','.','.','7','.','.','.','.']
                ,['6','.','.','1','9','5','.','.','.']
                ,['.','9','8','.','.','.','.','6','.']
                ,['8','.','.','.','6','.','.','.','3']
                ,['4','.','.','8','.','3','.','.','1']
                ,['7','.','.','.','2','.','.','.','6']
                ,['.','6','.','.','.','.','2','8','.']
                ,['.','.','.','4','1','9','.','.','5']
                ,['.','.','.','.','8','.','.','7','9']];

            var sol = IsValidSudoku(board);

            Console.WriteLine(sol);
        }

        public bool IsValidSudoku(char[][] board)
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
    }
}
