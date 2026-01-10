namespace LeetCode
{
    internal class _108ConvertSortedArrayToBinarySearchTree
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

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

        public TreeNode SortedArrayToBST(int[] sortedList)
        {
            if (sortedList.Length == 0)
            {
                return null;
            }

            if (sortedList.Length == 1)
            {
                return new TreeNode(sortedList[0]);
            }

            if (sortedList.Length == 2)
            {
                return new TreeNode(sortedList[1], new TreeNode(sortedList[0]), null);
            }

            var middleIndex = sortedList.Length / 2;

            int[] leftSublist = [];
            int[] rightSublist = [];

            for (int i = 0; i < middleIndex; i++)
            {
                leftSublist = [.. leftSublist, sortedList[i]];
            }

            for (int i = middleIndex + 1; i < sortedList.Length; i++)
            {
                rightSublist = [.. rightSublist, sortedList[i]];
            }

            return new TreeNode(sortedList[middleIndex], SortedArrayToBST(leftSublist), SortedArrayToBST(rightSublist));
        }
    }
}
