using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1
{
    public class Solution
    {
        public int[] AnagramMappings(int[] A, int[] B)
        {
            Dictionary<int, List<int>> mapping = new Dictionary<int, List<int>>();

            for (int i = 0; i < B.Length; i++)
            {
                if (mapping.ContainsKey(B[i]))
                {
                    mapping[B[i]].Add(i);
                }
                else
                {
                    mapping.Add(B[i], new List<int>() { i });
                }
            }

            int[] map = new int[A.Length];
            for (int i = 0; i < A.Length; i++)
            {
                var lst = mapping[A[i]];
                map[i] = lst[0];
                lst.RemoveAt(0);
                if (lst.Count == 0) mapping.Remove(A[i]);
                else { mapping[A[i]] = lst; }
            }

            return map;
        }

        static void Main()
        {

        }
    }
}
