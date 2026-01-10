using System.Net.WebSockets;
using System.Text;

namespace LeetCode
{
    internal class _101SymetricTree
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
            var left = new TreeNode(3, new TreeNode(4), new TreeNode(5, new TreeNode(8), new TreeNode(9)));
            var right = new TreeNode(3, new TreeNode(5, new TreeNode(9), new TreeNode(8)), new TreeNode(4));

            //var left = new TreeNode(2, null, new TreeNode(3));
            //var right = new TreeNode(2, null, new TreeNode(3));

            var root = new TreeNode(1, left, right);

            var solution = IsSymmetric(root);

            Console.WriteLine(solution ? "true" : "false");
        }

        public bool IsSymmetric(TreeNode root)
        {
            int[] visitedLeft = [];
            int[] visitedRight = [];

            if (root.left != null)
            {
                visitedLeft = Dfs(root.left);
            }

            if (root.right != null)
            {
                visitedRight = MirrorDfs(root.right);
            }

            if (visitedLeft.Length != visitedRight.Length)
            {
                return false;
            }

            for (int i = 0; i < visitedLeft.Length; i++)
            {
                if (visitedLeft[i] != visitedRight[i])
                {
                    return false;
                }
            }

            return true;
        }

        private int[] Dfs(TreeNode root)
        {
            int[] visited = [root.val];

            if (root.left != null)
            {
                visited = [..visited, ..Dfs(root.left)];
            }
            else
            {
                visited = [.. visited, -1];
            }

            if (root.right != null)
            {
                visited = [.. visited, .. Dfs(root.right)];
            }
            else
            {
                visited = [.. visited, -1];
            }

            return visited;
        }

        private int[] MirrorDfs(TreeNode root)
        {
            int[] visited = [root.val];

            if (root.right != null)
            {
                visited = [.. visited, .. MirrorDfs(root.right)];
            }
            else
            {
                visited = [.. visited, -1];
            }

            if (root.left != null)
            {
                visited = [.. visited, .. MirrorDfs(root.left)];
            }
            else
            {
                visited = [.. visited, -1];
            }

            return visited;
        }
    }
}
 
