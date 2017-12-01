namespace RemoveDuplicatesFromSortedArray
{
    public class Solution
    {

        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0) return 0;
            int len = 1;
            for(int i=1; i<nums.Length; i++)
            {
                if (nums[i] == nums[i - 1]) continue;
                nums[len++] = nums[i];
            }

            return len;
        }

        static void Main(string[] args)
        {
            Solution sol = new Solution();
            var result = sol.RemoveDuplicates(new int[] { 1, 1 });
            var result2 = sol.RemoveDuplicates(new int[] { 1, 2, 3 });
            var result3 = sol.RemoveDuplicates(new int[] { 1 });

            int[] num = new int[] { 1, 1, 2, 3, 3, 4, 5, 5 };
            var result4 = sol.RemoveDuplicates(num);
        }
    }
}
