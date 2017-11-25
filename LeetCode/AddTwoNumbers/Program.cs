namespace AddTwoNumbers
{
    //Definition for singly-linked list.
    public class ListNode
    {
          public int val;
          public ListNode next;
          public ListNode(int x) { val = x; }
     }

    public class Solution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode head = null;
            ListNode result = head;
            int sum = 0;
            int carry = 0;
            while (l1 != null || l2 != null || carry != 0)
            {
                sum = (l1 != null ? l1.val : 0) + (l2 != null ? l2.val : 0) + carry;
                carry = sum / 10;
                sum = sum % 10;

                if (result == null)
                {
                    result = new ListNode(sum);
                    head = result;
                }
                else
                {
                    ListNode node = new ListNode(sum);
                    result.next = node;
                    result = result.next;
                }
                l1 = l1 != null ? l1.next : null;
                l2 = l2 != null ? l2.next : null;
            }

            return head;
        }

        public static void Main()
        {
            Solution sol = new Solution();
        }
    }
}
