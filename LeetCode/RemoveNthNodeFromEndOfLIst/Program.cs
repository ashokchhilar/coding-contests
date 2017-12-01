//https://leetcode.com/problems/remove-nth-node-from-end-of-list/description/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveNthNodeFromEndOfLIst
{
    // Definition for singly-linked list.
    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    public class Solution
    {
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode firstPtr = head;
            ListNode secondPtr = null;

            for(int i=0;i<n;i++)
            {
                firstPtr = firstPtr != null ? firstPtr.next : null;
            }

            if(firstPtr == null)    //special case when the element to be removed is head itself
            {
                head = head.next;
                return head;
            }

            secondPtr = head;

            while(firstPtr.next!=null)
            {
                firstPtr = firstPtr.next;
                secondPtr = secondPtr.next;
            }

            //remove node at secondptr
            secondPtr.next = secondPtr.next.next;

            return head;
        }

        public static ListNode GetLinkedList(int len)
        {
            ListNode head = new ListNode(len);
            for (int i = len-1; i >= 1; i--)
            {
                ListNode node2 = new ListNode(i);
                node2.next = head;
                head = node2;
            }
            return head;
        }

        public static void Main(string[] args)
        {


            Solution sol = new Solution();

            ListNode head = GetLinkedList(5);
            var list = sol.RemoveNthFromEnd(head, 2);

            head = GetLinkedList(1);
            var list2 = sol.RemoveNthFromEnd(head, 1);

        }
    }
}
