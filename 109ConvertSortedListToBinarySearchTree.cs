namespace LeetCode
{
    internal class _109ConvertSortedListToBinarySearchTree
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

        public void Run()
        {
            var head = new ListNode(-10, new ListNode(-3, new ListNode(0, new ListNode(5, new ListNode(9)))));

            var sol = SortedListToBST(head);

            var a = 1;
        }

        public TreeNode SortedListToBST(ListNode head)
        {
            int[] sortedList = [];

            var currentListNode = head;
            while (currentListNode != null)
            {
                sortedList = [ .. sortedList, currentListNode.val ];
                currentListNode = currentListNode.next;
            }

            return SortedListToBST(sortedList);
        }

        public TreeNode SortedListToBST(int[] sortedList)
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

            return new TreeNode(sortedList[middleIndex], SortedListToBST(leftSublist), SortedListToBST(rightSublist));
        }
    }
}
