using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchForRange
{
    public class Solution
    {
        /// <summary>
        /// Arrange lo and high to match range
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] SearchRange(int[] nums, int target)
        {
            int lo = 0;
            int hi = nums.Length - 1;

            while (lo <= hi)
            {
                if (nums[lo] == target && nums[hi] == target) return new int[] { lo, hi };
                int mid = (hi - lo) / 2 + lo;

                if(nums[mid] == target)
                {
                    int midCopy = mid;
                    //search lower and higher
                    while (mid > lo && nums[lo]!=target)
                    {
                        var mid2 = (mid - lo) / 2 + lo;
                        if (nums[mid2] != target) lo = mid2 + 1;
                        else mid = mid2;
                    }

                    mid = midCopy;
                    while(mid<hi && nums[hi] != target)
                    {
                        var mid2 = (hi - mid) / 2 + mid;
                        if (mid == mid2) hi--;

                        else if (nums[mid2] != target) hi = mid2 - 1;
                        else mid = mid2;
                    }

                    return new int[] { lo, hi };
                }

                if (target > nums[mid]) lo = mid + 1;
                else hi = mid - 1;
            }

            return new int[] { -1, -1 };
        }

        static void Main(string[] args)
        {
            Solution sol = new Solution();
            int[] nums = new int[] {1,2,3,8,8,8,9,9,10};

            var result = sol.SearchRange(nums, 8);
        }
    }
}
