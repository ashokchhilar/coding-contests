using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchInRotatedSortedArray
{
    public class Solution
    {
        public int Search(int[] nums, int target)
        {
            int start = 0;
            int end = nums.Length - 1;

            while(start <= end)
            {
                int half = (end - start) / 2 + start;
                if (nums[half] == target) return half;
                if (nums[start] == target) return start;
                if (nums[end] == target) return end;

                else if (nums[start] > nums[half]) //rotation is in first half & second half is purely an increasing sequence
                {
                    if (target < nums[half] || target >= nums[start])
                    {
                        end = half - 1;
                    }
                    else start = half + 1;
                }
                else if (nums[end] < nums[half]) //rotation is in second half
                {
                    if (target <= nums[end] || target > nums[half])
                    {
                        start = half + 1;
                    }
                    else end = half - 1;
                }
                else //there is no rotation
                {
                    if (target < nums[half]) end = half - 1;
                    else start = half + 1;
                }
            }

            return -1;
        }

        static void Main(string[] args)
        {
            Solution sol = new Solution();
            int[] nums = new int[] { 4, 5, 6, 6, 7, 0, 1, 2 };

            int result = sol.Search(nums, 6);
            result = sol.Search(nums, 1);
            result = sol.Search(nums, 3);
        }
    }
}
