using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    //Definition for singly-linked list.
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }

        public static ListNode GetLinkedList(int len)
        {
            ListNode head = new ListNode(len);
            for (int i = len - 1; i >= 1; i--)
            {
                ListNode node2 = new ListNode(i);
                node2.next = head;
                head = node2;
            }
            return head;
        }
    }
}
