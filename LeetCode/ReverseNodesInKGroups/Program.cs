using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseNodesInKGroups
{
    /// <summary>
    /// 
    /// </summary>
    public class Solution
    {
        public Tuple<ListNode, ListNode> ReverseWholeGroup(ListNode head, ListNode last)
        {
            //Given this linked list: 1->2->3->4->5
            //For k = 2, you should return: 2->1->4->3->5
            //For k = 3, you should return: 3->2->1->4->5

            ListNode next = null;
            ListNode previous = null;

            ListNode iter = head;

            while (iter != last)
            {
                next = iter.next;
                iter.next = previous;
                previous = iter;
                iter = next;
            }

            head.next = last;

            return new Tuple<ListNode, ListNode>(previous, head);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="head"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public ListNode ReverseKGroup(ListNode head, int k)
        {
            ListNode iter = head;
            ListNode newhead = null;
            ListNode newLast = null;

            while (iter != null)
            {
                ListNode start = iter;
                bool flag = false;
                //move k units forward, reverse the k unit chunk - repeat
                for (int i = 0; i < k; i++)
                {
                    if (iter == null) { flag = true; break; }
                    iter = iter.next;
                }


                if (flag) break;
                //swap here
                Tuple<ListNode, ListNode> tuple = ReverseWholeGroup(start, iter);
                ListNode revHead = tuple.Item1;
                ListNode revLast = tuple.Item2;


                if (newhead == null)
                {
                    newhead = revHead;
                    newLast = revLast;
                }
                else
                {
                    newLast.next = revHead;
                    newLast = revLast;
                }
            }
            return newhead == null ? head : newhead;
        }

        public ListNode SwapPairs(ListNode head)
        {
            return ReverseKGroup(head, 2);
        }

        static void Main(string[] args)
        {
            var myList = ListNode.GetLinkedList(5);
            Solution sol = new Solution();

            var result = sol.ReverseKGroup(myList, 2);
        }
    }
}
