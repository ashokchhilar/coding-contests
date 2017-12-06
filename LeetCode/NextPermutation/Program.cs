using System.Collections.Generic;

namespace NextPermutation
{
    public class Solution
    {

        public void NextPermutation(List<int> a)
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
                    break;
                }
            }

            int temp = a[end];
            a[end] = a[start];
            a[start] = temp;

            //sort from i+1 onwards
            a.Sort(start + 1, a.Count - start - 1, Comparer<int>.Default);
        }

        public void NextPermutation(int[] nums)
        {
            if (nums == null || nums.Length == 0) return;
            List<int> a = new List<int>(nums);

            for (int i = 0; i < nums.Length; i++)
                nums[i] = a[i];
        }

        static void Main(string[] args)
        {
            int[] array = new int[3] { 1,2,3 };
            Solution sol = new Solution();

            int count = 10;
            while (count-- > 0)
            {
                sol.NextPermutation(array);
            }
            sol.NextPermutation(array);
        }
    }
}
