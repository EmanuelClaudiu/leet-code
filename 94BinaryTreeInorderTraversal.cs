namespace LeetCode
{
    internal class _94BinaryTreeInorderTraversal
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
            var tree = new TreeNode(1, new TreeNode(2, new TreeNode(4), new TreeNode(5, new TreeNode(6), new TreeNode(7))), new TreeNode(3, null, new TreeNode(8, new TreeNode(9))));

            var visited = InorderTraversal(tree);

            var a = 1;
        }

        public IList<int> InorderTraversal(TreeNode root)
        {
            int[] visited = [];

            if (root == null)
            {
                return visited;
            }

            var rootValue = root.val;

            var left = root.left != null ? InorderTraversal(root.left) : [];

            var right = root.right != null ? InorderTraversal(root.right) : [];

            return [.. left, rootValue, .. right];
        }
    }
}
