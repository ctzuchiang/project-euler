namespace Solution.Easy._001_050
{
    public class E21_MergeTwoSortedLists
    {
        /// <summary>
        /// Merges the two lists.
        /// </summary>
        /// <param name="l1">The ListNode 1.</param>
        /// <param name="l2">The ListNode 2.</param>
        /// <returns></returns>
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode headNode = new ListNode(0) { next = l1 };
            ListNode curNode = headNode;

            ListNode p1 = l1;
            ListNode p2 = l2;
            while (p1 != null && p2 != null)
            {
                if (p1.val < p2.val)
                {
                    curNode.next = p1;
                    p1 = p1.next;
                }
                else
                {
                    curNode.next = p2;
                    p2 = p2.next;
                }
                curNode = curNode.next;
            }

            if (p1 != null)
            {
                curNode.next = p1;
            }

            if (p2 != null)
            {
                curNode.next = p2;
            }
            return headNode.next;
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

}
