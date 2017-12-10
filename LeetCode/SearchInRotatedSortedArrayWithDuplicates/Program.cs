using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchInRotatedSortedArrayWithDuplicates
{
    public class Solution
    {

        public bool Search(int[] nums, int target, int start, int end)
        {
            if (start > end) return false;

            int half = (end - start) / 2 + start;
            if (target == nums[half]) return true;

            if (nums[start] == nums[end])//can't determine the rotation point, search both paths
            {
                return Search(nums, target, start, half - 1) || Search(nums, target, half + 1, end);
            }

            while (start <= end)
            {
                half = (end - start) / 2 + start;
                if (nums[half] == target) return true;
                if (nums[start] == target) return true;
                if (nums[end] == target) return true;

                if (nums[start] == nums[half] && nums[half] == nums[end]) { start++; end--; }

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

            return false;
        }

        public bool Search(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0) return false;
            return Search(nums, target, 0, nums.Length - 1);
        }

        static void Main(string[] args)
        {
            Solution sol = new Solution();
            int[] nums = new int[] { 1 };

            bool result = sol.Search(nums, 3);
            result = sol.Search(nums, 1);
            result = sol.Search(nums, 3);
        }
    }
}
