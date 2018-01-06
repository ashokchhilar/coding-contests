using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstMissingPositive
{
    public class Solution
    {

        public void swap(int i, int j, int[] num)
        {
            int temp = num[i];
            num[i] = num[j];
            num[j] = temp;
        }

        public int FirstMissingPositive(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 1;

            int i = 0;
            while (i < nums.Length)
            {
                if (nums[i] <= nums.Length && nums[i] > 0 && nums[i] != i + 1 && nums[nums[i] - 1] != nums[i])
                {
                    swap(nums[i] - 1, i, nums);
                }
                else
                {
                    i++;
                }
            }
            int j = 0;

            while (j < nums.Length && nums[j] == j + 1) j++;
            return j + 1;
        }

        static void Main(string[] args)
        {
            Solution sol = new Solution();
            int result = sol.FirstMissingPositive(new int[] {1,1});
        }
    }
}
