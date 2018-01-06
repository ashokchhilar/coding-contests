using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permutations_II
{
    public class Solution
    {
        public bool NextPermutation(List<int> a)
        {
            int start = 0, end = a.Count - 1;

            //find the first from last that is smaller than end
            for (int i = a.Count - 2; i >= 0; i--)
            {
                if (a[i] < a[i + 1])
                {
                    end = i + 1;
                    int min = end;

                    //Find the minimum element that is still greater than current one
                    //Since control is here, it will always find such value.
                    while (end < a.Count)
                    {
                        if (a[end] < a[min] && a[end] > a[i]) min = end;
                        end++;
                    }

                    //swap the end and sort the middle
                    //287365 => 128563 => 128536
                    start = i; end = min;

                    int temp = a[end];
                    a[end] = a[start];
                    a[start] = temp;

                    //sort from i+1 onwards
                    a.Sort(start + 1, a.Count - start - 1, Comparer<int>.Default);
                    return true;
                }
            }
            return false;
        }

        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            IList<IList<int>> allPermutations = new List<IList<int>>();
            if (nums == null || nums.Count() == 0) return allPermutations;

            List<int> a = new List<int>(nums);
            a.Sort();
            allPermutations.Add(new List<int>(a));

            while(NextPermutation(a))
            {
                allPermutations.Add(new List<int>(a));
            }

            return allPermutations;
        }

        static void Main(string[] args)
        {
            int[] nums = new int[3] { 1,1,2 };
            Solution sol = new Solution();
            var result = sol.PermuteUnique(nums);
        }
    }
}
