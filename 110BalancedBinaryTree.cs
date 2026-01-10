namespace LeetCode
{
    internal class _110BalancedBinaryTree
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
            //var tree = new TreeNode(3, new TreeNode(9), new TreeNode(20, new TreeNode(15), new TreeNode(7)));
            //var tree = new TreeNode(1, new TreeNode(2, new TreeNode(3, new TreeNode(4), new TreeNode(4)), new TreeNode(3)), new TreeNode(2));
            //var tree = new TreeNode(1, new TreeNode(2, new TreeNode(3, new TreeNode(4))), new TreeNode(2, null, new TreeNode(3, null, new TreeNode(4))));

            var tree = new TreeNode(3, new TreeNode(9), new TreeNode(20, new TreeNode(15), new TreeNode(17)));

            var sol = IsBalanced(tree);

            Console.WriteLine(sol);
        }

        public bool IsBalanced(TreeNode root)
        {
            if (root == null) return true;

            var leftMaxDepth = MaxDepth(root.left);
            var rightMaxDepth = MaxDepth(root.right);

            if (Math.Abs(leftMaxDepth - rightMaxDepth) > 1)
            {
                return false;
            }

            var leftBalanced = root.left == null ? true : IsBalanced(root.left);
            var rightBalanced = root.right == null ? true : IsBalanced(root.right);

            return leftBalanced && rightBalanced;
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
