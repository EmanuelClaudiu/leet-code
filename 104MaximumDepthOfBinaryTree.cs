namespace LeetCode
{
    internal class _104MaximumDepthOfBinaryTree
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
            var tree = new TreeNode(3, new TreeNode(9), new TreeNode(20, new TreeNode(15), new TreeNode(7)));

            var sol = MaxDepth(tree);

            Console.WriteLine(sol);
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
