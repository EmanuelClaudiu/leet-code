namespace LeetCode
{
    internal class _2196CreateBinaryTreeFromDescriptions
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        public void Run()
        {
            int[][] descriptions = [[20, 15, 1], [20, 17, 0], [50, 20, 1], [50, 80, 0], [80, 19, 1]];

            var sol = CreateBinaryTree(descriptions);
        }

        private int[] _leftChildren = new int[100001];
        private int[] _rightChildren = new int[100001];
        private int[] _parentNodes = new int[100001];
        private HashSet<int> _nodes = new HashSet<int>();

        private Queue<TreeNode> _visitQueue = new Queue<TreeNode>();

        public TreeNode CreateBinaryTree(int[][] descriptions)
        {
            foreach (var desc in descriptions)
            {
                if (!_nodes.Contains(desc[0]))
                {
                    _nodes.Add(desc[0]);
                }

                if (!_nodes.Contains(desc[1]))
                {
                    _nodes.Add(desc[1]);
                }

                if (desc[2] == 1)
                {
                    _leftChildren[desc[0]] = desc[1];
                    _parentNodes[desc[1]] = desc[0];
                }

                if (desc[2] == 0)
                {
                    _rightChildren[desc[0]] = desc[1];
                    _parentNodes[desc[1]] = desc[0];
                }
            }

            int rootValue = 0;
            foreach (var node in _nodes)
            {
                if (_parentNodes[node] == 0)
                {
                    rootValue = node;
                }
            }

            var root = new TreeNode(rootValue);
            _visitQueue.Enqueue(root);
            BfsVisit();

            return root;
        }

        public void BfsVisit()
        {
            if (_visitQueue.Count == 0) return;

            var currentNode = _visitQueue.Dequeue();

            var leftChildNode = _leftChildren[currentNode.val] != 0 ? new TreeNode(_leftChildren[currentNode.val]) : null;
            var rightChildNode = _rightChildren[currentNode.val] != 0 ? new TreeNode(_rightChildren[currentNode.val]) : null;

            currentNode.left = leftChildNode;
            currentNode.right = rightChildNode;

            if (leftChildNode != null)
            {
                _visitQueue.Enqueue(leftChildNode);
            }

            if (rightChildNode != null)
            {
                _visitQueue.Enqueue(rightChildNode);
            }

            BfsVisit();
        }
    }
}
