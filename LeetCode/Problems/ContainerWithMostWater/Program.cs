namespace ContainerWithMostWater
{
    public class Solution
    {
        public int MaxArea(int[] height)
        {
            int max = 0, l = 0, r = height.Length - 1;
            while(l<r)
            {
                var minHeight = min(height[l], height[r]);
                var area = minHeight * (r - l);

                if (max < area) max = area;

                if (minHeight == height[l]) l++;
                else r--;
            }
            return max;
        }

        public int min(int a, int b)
        {
            return a < b ? a : b;
        }

        static void Main(string[] args)
        {
            int[] input = new int[] { 1, 2, 1 };
            var result = new Solution().MaxArea(input);
        }
    }
}
