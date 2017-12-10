using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchInsertPosition
{
    public class Solution
    {
        /// <summary>
        /// Find the insert postion of target in sorted array if not found, else index of found location
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int SearchInsert(int[] nums, int target)
        {
            int lo = 0;
            int hi = nums != null ? nums.Length - 1 : -1;

            while(lo <= hi)
            {
                int mid = (hi - lo) / 2 + lo;
                if (target == nums[mid]) return mid;

                else if (target > nums[mid])
                {
                    lo = mid + 1;
                }
                else hi = mid - 1;

                if(lo > hi)
                {
                    if (target > nums[mid]) return mid + 1;
                    else return mid;
                }
            }
            return 0; //this should never happen
        }

        static void Main(string[] args)
        {
            int[] a = new int[] { 1, 3 };

            Solution sol = new Solution();
            var rs1 = sol.SearchInsert(a, 5);
            var rs2 = sol.SearchInsert(a, 2);
            var rs3 = sol.SearchInsert(a, 7);
            var rs4 = sol.SearchInsert(a, 0);


        }
    }
}
