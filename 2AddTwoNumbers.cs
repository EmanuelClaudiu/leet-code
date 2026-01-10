namespace LeetCode
{
    internal class _2AddTwoNumbers
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

        public void Run()
        {
            //var l1 = new ListNode(2, new ListNode(4, new ListNode(3, null)));
            //var l2 = new ListNode(5, new ListNode(6, new ListNode(4, null)));

            //var l1 = new ListNode(0, null);
            //var l2 = new ListNode(0, null);

            var l1 = new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, null)))))));
            var l2 = new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, null))));

            var l3 = AddTwoNumbers(l1, l2);

            var solution = l3;
        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            // we go as long there's elements in both lists
            // at each step sum the numbers, keep last digit, keep remainder
            // remainder is 0 at beginning
            // keep track of head of new list

            var remainder = 0;
            ListNode beginningNode = null;

            ListNode currentNode = null;

            while (l1 != null || l2 != null)
            {
                var l1_value = l1 != null ? l1.val : 0;
                var l2_value = l2 != null ? l2.val : 0;

                var sum = l1_value + l2_value;
                sum += remainder;
                remainder = 0;
                var digitToAdd = sum % 10;
                
                sum = sum / 10;
                remainder += sum;

                ListNode nodeToAdd = new ListNode(digitToAdd);

                if (beginningNode == null)
                {
                    beginningNode = nodeToAdd;
                    currentNode = nodeToAdd;
                }
                else
                {
                    currentNode.next = nodeToAdd;
                    currentNode = nodeToAdd;
                }

                if (l1 != null)
                {
                    l1 = l1.next;
                }
                if (l2 != null)
                {
                    l2 = l2.next;
                }
            }

            if (remainder != 0)
            {
                var nodeToAdd = new ListNode(remainder);
                currentNode.next = nodeToAdd;
            }

            return beginningNode;
        }
    }
}
