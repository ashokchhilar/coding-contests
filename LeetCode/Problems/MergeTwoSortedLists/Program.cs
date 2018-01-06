using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeTwoSortedLists
{

    // Definition for singly-linked list.
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    public class Solution
    {

        public int getMin(int a, int b) { return a < b ? a : b; }

        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode head = null;
            ListNode tail = head;

            while (l1 != null || l2 != null)
            {
                int num1 = l1 != null ? l1.val : int.MaxValue;
                int num2 = l2 != null ? l2.val : int.MaxValue;

                int min = getMin(num1, num2);
                if (min == num1) l1 = l1.next;
                else l2 = l2.next;

                ListNode node = new ListNode(min);
                if(head == null)
                {
                    head = node;
                    tail = head;
                }
                else
                {
                    tail.next = node;
                    tail = tail.next;
                }
            }

            return head;
        }

        static void Main(string[] args)
        {
            Solution sol = new Solution();
            ListNode n1 = new ListNode(1);
            ListNode n2 = new ListNode(2);

            var output = sol.MergeTwoLists(n1, n2);
        }
    }
}
