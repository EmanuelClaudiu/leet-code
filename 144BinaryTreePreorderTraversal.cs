namespace LeetCode
{
    internal class _144BinaryTreePreorderTraversal
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
            //var tree = new TreeNode(1, null, new TreeNode(2, null, new TreeNode(3)));
            var tree = new TreeNode(1, new TreeNode(2, new TreeNode(4), new TreeNode(5)), new TreeNode(3, null, new TreeNode(6)));

            var visited = PreorderTraversal(tree);

            var a = 1;
        }

        public IList<int> PreorderTraversal(TreeNode root)
        {
            int[] visited = [];

            if (root == null)
            {
                return visited;
            }

            var rootValue = root.val;

            var left = root.left != null ? PreorderTraversal(root.left) : [];

            var right = root.right != null ? PreorderTraversal(root.right) : [];

            return [rootValue, .. left, .. right];
        }
    }
}
 
