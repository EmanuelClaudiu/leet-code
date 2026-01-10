namespace LeetCode
{
    internal class _543DiameterOfBinaryTree
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

        private int _maxDiameter = -1;

        public void Run()
        {
            //var tree = new TreeNode(1, new TreeNode(2, new TreeNode(4), new TreeNode(5)), new TreeNode(3));
            var tree = new TreeNode(4, new TreeNode(2, new TreeNode(3), new TreeNode(1, new TreeNode(5))));

            var sol = DiameterOfBinaryTree(tree);

            Console.WriteLine(sol);
        }

        public int DiameterOfBinaryTree(TreeNode root)
        {
            Visit(root);

            return _maxDiameter;
        }

        public void Visit(TreeNode node)
        {
            if (node == null)
            {
                return;
            }

            var diameterOfNode = DiameterOfNode(node);

            if (diameterOfNode >= _maxDiameter)
            {
                _maxDiameter = diameterOfNode;
            }

            Visit(node.left);
            Visit(node.right);
        }

        public int DiameterOfNode(TreeNode root)
        {
            if (root == null) return 0;

            var deepestLeft = MaxDepth(root.left);
            var deepestRight = MaxDepth(root.right);

            return deepestLeft + deepestRight;
        }

        public int MaxDepth(TreeNode root)
        {
            if (root == null) return 0;

            var leftDepth = root.left == null ? 0 : MaxDepth(root.left);

            var rightDepth = root.right == null ? 0 : MaxDepth(root.right);

            return 1 + Math.Max(leftDepth, rightDepth);
        }
    }
}
