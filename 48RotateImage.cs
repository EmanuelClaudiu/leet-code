namespace LeetCode
{
    internal class _48RotateImage
    {
        public void Run()
        {
            //int[][] matrix = [[5, 1, 9, 11], [2, 4, 8, 10], [13, 3, 6, 7], [15, 14, 12, 16]];
            int[][] matrix = [[1, 2, 3], [4, 5, 6], [7, 8, 9]];

            Rotate(matrix);

            foreach (var row in matrix)
            {
                foreach (var elem in row)
                {
                    Console.Write($"{elem} ");
                }
                Console.WriteLine();
            }
        }

        public void Rotate(int[][] matrix)
        {
            int n = matrix.Length - 1;
            var topRow = 0;
            var bottomRow = n;
            var leftCol = 0;
            var rightCol = n;

            while (topRow < bottomRow && leftCol < rightCol)
            {
                int[] topArray = [];
                int[] bottomArray = [];
                int[] leftArray = [];
                int[] rightArray = [];

                for (int i = leftCol; i <= rightCol; i++)
                {
                    topArray = [.. topArray, int.Parse(matrix[topRow][i].ToString())];
                }
                for (int i = leftCol; i <= rightCol; i++)
                {
                    bottomArray = [.. bottomArray, int.Parse(matrix[bottomRow][i].ToString())];
                }

                for (int i = topRow; i <= bottomRow; i++)
                {
                    leftArray = [.. leftArray, int.Parse(matrix[i][leftCol].ToString())];
                }
                for (int i = topRow; i <= bottomRow; i++)
                {
                    rightArray = [.. rightArray, int.Parse(matrix[i][rightCol].ToString())];
                }

                for (int i = leftCol, cnt = leftArray.Length - 1; i <= rightCol; i++, cnt--)
                {
                    matrix[topRow][i] = leftArray[cnt];
                }
                for (int i = leftCol, cnt = rightArray.Length - 1; i <= rightCol; i++, cnt--)
                {
                    matrix[bottomRow][i] = rightArray[cnt];
                }

                for (int i = topRow, cnt = 0; i <= bottomRow; i++, cnt++)
                {
                    matrix[i][leftCol] = bottomArray[cnt];
                }
                for (int i = topRow, cnt = 0; i <= bottomRow; i++, cnt++)
                {
                    matrix[i][rightCol] = topArray[cnt];
                }

                topRow++;
                bottomRow--;
                leftCol++;
                rightCol--;
            }
        }
    }
}
