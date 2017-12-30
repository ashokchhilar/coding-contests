using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargestNumberGreaterThanTwiceOthers
{
    class Solution
    {
        public int DominantIndex(int[] nums)
        {
            if (nums == null && nums.Length < 1) return -1;

            if (nums.Length == 1) return 0;

            int max = nums[1];
            int secondMax = nums[0];
            int maxIndex = 1;

            if(max < secondMax)
            {
                max = nums[0];
                secondMax = nums[1];
                maxIndex = 0;
            }

            for(int i=2; i<nums.Length; i++)
            {
                if (max < nums[i])
                {
                    secondMax = max;
                    max = nums[i];
                    maxIndex = i;
                }
                else if (secondMax < nums[i]) secondMax = nums[i];
            }

            if (max >= 2 * secondMax) return maxIndex;
            return -1;
        }

        static void Main(string[] args)
        {
            int[] nums = new int []{ 0 };

            Solution sol = new Solution();
            var result = sol.DominantIndex(nums);

        }
    }
}
