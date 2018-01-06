namespace FindMedianSortedArrays
{
    public class Solution
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int i = 0, j = 0;
            double sum = 0;
            int iter = 0;
            int totalLength = (nums1.Length + nums2.Length);
            bool even = totalLength % 2 == 0;

            while(iter <= totalLength/2)
            {
                int first = i < nums1.Length ? nums1[i] : int.MaxValue;
                int second = j < nums2.Length ? nums2[j] : int.MaxValue;

                int accepted = 0;
                if (first < second) {
                    accepted = first;
                    i++;
                }
                else {
                    j++;
                    accepted = second;
                }

                if (even && (iter == (totalLength - 1) / 2 || iter == totalLength / 2))
                    sum += accepted;
                else if (!even && iter == totalLength / 2) return accepted;
                iter++;
            }

            return sum / 2;
        }

        static void Main(string[] args)
        {
            int[] nums1 = new int[] { 1};
            int[] nums2 = new int[] { 2, 3 };

            Solution sol = new Solution();
            double median = sol.FindMedianSortedArrays(nums1, nums2);
        }
    }
}
