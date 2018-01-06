using System;
using System.Collections.Generic;

namespace _3Sum
{
    public class Solution
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> resultList = new List<IList<int>>();

            List<int> n = new List<int> (nums);
            n.Sort();

            //find all the combinations
            for(int i=0; i<n.Count; i++)
            {
                if (i > 0 && n[i] == n[i - 1]) continue;

                for(int j=i+1; j<n.Count-1; j++)
                {
                    if (j > i + 1 && n[j] == n[j - 1]) continue;

                    int toFind = -1*(n[i] + n[j]);
                    if (toFind < n[j]) break;

                    int searchResult = -1;
                    if (toFind == n[j] && n[j] == n[j + 1]) searchResult = j + 1;
                    else
                        searchResult = n.BinarySearch(toFind);

                    if(searchResult > j)
                    {
                        resultList.Add(new List<int>{n[i], n[j], n[searchResult]});
                    }
                }
            }

            return resultList;
        }

        static void Main(string[] args)
        {
            Solution sol = new Solution();
            var result = sol.ThreeSum(new int[] { -1, 0, 1, 2, -1, -4 });
            var result2 = sol.ThreeSum(new int[] {0,0,0 });
            var result3 = sol.ThreeSum(new int[] { 0, 0 });
            var result4 = sol.ThreeSum(new int[] { 0, 0, 10, 0 });
            var result5 = sol.ThreeSum(new int[] { -1, 0, 0, 1 });
        }
    }
}
