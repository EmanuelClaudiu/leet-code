namespace LeetCode
{
    internal class _79WordSearch
    {
        private Dictionary<char, int[][]> _positions = [];

        public void Run()
        {
            //char[][] board = [['A', 'B', 'C', 'E'], ['S', 'F', 'C', 'S'], ['A', 'D', 'E', 'E']];
            //string word = "ABCCED";

            //char[][] board = [['A', 'B', 'C', 'E'], ['S', 'F', 'C', 'S'], ['A', 'D', 'E', 'E']];
            //string word = "SEE";

            //char[][] board = [['A', 'B', 'C', 'E'], ['S', 'F', 'C', 'S'], ['A', 'D', 'E', 'E']];
            //string word = "ABCB";

            char[][] board = [['A']];
            string word = "AB";

            Console.WriteLine(Exist(board, word));
        }

        public bool Exist(char[][] board, string word)
        {
            int m = board.Length;
            int n = board[0].Length;

            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (!_positions.Keys.Contains(board[i][j])) _positions[board[i][j]] = [];

                    _positions[board[i][j]] = [.. _positions[board[i][j]], [i, j]];
                }
            }

            if (word.Length == 1)
            {
                return _positions.Keys.Contains(word[0]);
            }

            foreach (var letter in word)
            {
                if (!_positions.ContainsKey(letter)) return false;
            }

            return Process(board, word);
        }

        private bool Process(char[][] board, string word)
        {
            var firstLetter = word[0];

            if (!_positions.Keys.Contains(firstLetter)) return false;

            foreach (var position in _positions[firstLetter])
            {
                var visited = new HashSet<string>
                {
                    $"{position[0]}-{position[1]}"
                };
                if (Compute(board, word[1..], position, visited)) return true;
            }

            return false;
        }
        
        private bool Compute(char[][] board, string word, int[] currentPosition, HashSet<string> visitedPositions)
        {
            var currentLetter = board[currentPosition[0]][currentPosition[1]];
            var secondLetter = word[0];

            if (!_positions.Keys.Contains(secondLetter)) return false;

            foreach (var position in _positions[secondLetter])
            {
                if (visitedPositions.Contains($"{position[0]}-{position[1]}")) continue;

                if (Neighbors(currentPosition, position))
                {
                    if (word.Length == 1) return true;

                    var visited = new HashSet<string>(visitedPositions)
                    {
                        $"{position[0]}-{position[1]}"
                    };

                    if (Compute(board, word[1..], position, visited)) return true;
                }
            }

            return false;
        }

        private bool Neighbors(int[] positionA, int[] positionB)
        {
            if (positionA[0] == positionB[0])
            {
                return Math.Abs(positionA[1] - positionB[1]) == 1;
            }

            if (positionA[1] == positionB[1])
            {
                return Math.Abs(positionA[0] - positionB[0]) == 1;
            }

            return false;
        }
    }
}
