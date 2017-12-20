using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumSumSubArray
{
    public class Solution
    {
        public int MaxSubArray(int[] nums)
        {
            if (nums == null || nums.Count() == 0) return 0;

            int maxsum = nums[0];
            int sum = 0;
            for(int i=0;i<nums.Length;i++)
            {
                if(sum+nums[i] < 0)
                {
                    sum = 0;
                    if (maxsum < nums[i]) maxsum = nums[i];
                }
                else
                {
                    sum += nums[i];
                    if (maxsum < sum) maxsum = sum;
                }
            }

            return maxsum;
        }

        public static void Main(string[] args)
        {
            Solution sol = new Solution();
            int[] nums = new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            int max = sol.MaxSubArray(nums);
        }
    }
}
