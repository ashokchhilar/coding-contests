using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeKSortedLists
{
    public class Solution
    {
        // Definition for singly-linked list.
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        /// <summary>
        /// Comparer for comparing two keys, handling equality as beeing greater
        /// Use this Comparer e.g. with SortedLists or SortedDictionaries, that don't allow duplicate keys
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        public class DuplicateKeyComparer<TKey>
                        :
                     IComparer<TKey> where TKey : IComparable
        {
            #region IComparer<TKey> Members

            public int Compare(TKey x, TKey y)
            {
                int result = x.CompareTo(y);

                if (result == 0)
                    return 1;   // Handle equality as beeing greater
                else
                    return result;
            }

            #endregion
        }

        public ListNode MergeKLists(ListNode[] lists)
        {
            SortedList<int, int> heap = new SortedList<int, int>(new DuplicateKeyComparer<int>());
            List<ListNode> l = new List<ListNode>(lists.Where(x => x!=null));

            for (int i = 0; i < l.Count; i++)
            {
                if (l[i] != null)
                {
                    heap.Add(l[i].val, i);
                }
            }

            //start merging
            ListNode mergedListhead = null;
            ListNode mergedListTail = null;

            while (l.Any(x=>x!=null))
            {
                var kvp = heap.First();
                ListNode node = new ListNode(kvp.Key);

                if (mergedListhead == null)
                {
                    mergedListhead = node;
                    mergedListTail = mergedListhead;
                }
                else
                {
                    mergedListTail.next = node;
                    mergedListTail = mergedListTail.next;
                }

                var list = l[kvp.Value];
                heap.RemoveAt(0);
                list = list.next;
                l[kvp.Value] = list;
                if (list != null)
                {
                    heap.Add(list.val, kvp.Value);
                }
            }

            return mergedListhead;
        }

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

        static void Main(string[] args)
        {
            Solution sol = new Solution();
            var l1 = GetLinkedList(3);
            var l2 = GetLinkedList(3);

            var result = sol.MergeKLists(new ListNode[] { l1, l2 });
            var result1 = sol.MergeKLists(new ListNode[] { new ListNode(0),new ListNode(1)});
            var result2 = sol.MergeKLists(new ListNode[] { null, null });
        }
    }
}
