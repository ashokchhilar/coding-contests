using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PourWater
{
    public class Solution
    {
        public bool SearchAndUpdateMinIndex(int[] heights, int K, int increment)
        {
            int min = heights[K];
            int minIndex = K;
            int i = K;

            while (i + increment >= 0 
                && i + increment < heights.Length 
                && heights[i + increment] <= heights[i])
            {
                i = i + increment;
                if (heights[i] < min)
                {
                    min = heights[i];
                    minIndex = i;
                }
            }

            if (minIndex != K) heights[minIndex]++;
            return minIndex!=K;
        }

        public int[] PourWater(int[] heights, int V, int K)
        {
            while(V-- > 0)
            {
                int j = K;
                int minIndex = K;

                //search left of K
                if (!SearchAndUpdateMinIndex(heights, K, -1))
                {
                    if(!SearchAndUpdateMinIndex(heights,K,1))
                    {
                        heights[K]++;
                    }
                }
            }

            return heights;
        }

        static void Main(string[] args)
        {
            Solution sol = new Solution();
            //var result = sol.PourWater(new int[] { 1, 2, 3, 4 }, 2, 2);
            var result = sol.PourWater(new int[] { 2, 1, 1, 2, 1, 2, 2 }, 4, 3);
        }
    }
}
