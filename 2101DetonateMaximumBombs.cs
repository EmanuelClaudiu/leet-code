namespace LeetCode
{
    internal class _2101DetonateMaximumBombs
    {
        private Dictionary<int, int[]> _vertices = [];

        public void Run()
        {
            int[][] bombs = [[2, 1, 3], [6, 1, 4]];
            //int[][] bombs = [[1, 1, 5], [10, 10, 5]];
            //int[][] bombs = [[1, 2, 3], [2, 3, 1], [3, 4, 2], [4, 5, 3], [5, 6, 4]];

            var sol = MaximumDetonation(bombs);

            Console.WriteLine(sol);
        }

        public int MaximumDetonation(int[][] bombs)
        {
            for (int i = 0; i < bombs.Length - 1; i++)
            {
                for (int j = i + 1; j < bombs.Length; j++)
                {
                    if (IsVertex(bombs[i], bombs[j]))
                    {
                        if (!_vertices.ContainsKey(i)) _vertices[i] = [];
                        _vertices[i] = [.. _vertices[i], j];
                    }
                    if (IsVertex(bombs[j], bombs[i]))
                    {
                        if (!_vertices.ContainsKey(j)) _vertices[j] = [];
                        _vertices[j] = [.. _vertices[j], i];
                    }
                }
            }

            var maxBombsDetonated = 1;

            for (int i = 0; i < bombs.Length; i++)
            {
                var detonated = DetonateFromStart(i);
                if (detonated > maxBombsDetonated) maxBombsDetonated = detonated;
            }

            return maxBombsDetonated;
        }

        private int DetonateFromStart(int root)
        {
            var detonateQueue = new Queue<int>();
            var alreadyDetonated = new HashSet<int>();
            detonateQueue.Enqueue(root);
            var detonated = 0;

            while (detonateQueue.Count != 0)
            {
                var currentBomb = detonateQueue.Dequeue();

                if (alreadyDetonated.Contains(currentBomb)) continue;

                detonated++;
                alreadyDetonated.Add(currentBomb);

                if (!_vertices.ContainsKey(currentBomb)) continue;

                foreach (var vertex in _vertices[currentBomb])
                {
                    detonateQueue.Enqueue(vertex);
                }
            }

            return detonated;
        }

        private bool IsVertex(int[] node1, int[] node2)
        {
            var squaredXDifference = Math.Pow(Math.Abs(node1[0] - node2[0]), 2);
            var squaredYDifference = Math.Pow(Math.Abs(node1[1] - node2[1]), 2);
            var squaredRadius = Math.Pow(node1[2], 2);

            return squaredXDifference + squaredYDifference <= squaredRadius;
        }
    }
}
