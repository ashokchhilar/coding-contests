using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Sum
{
    public class Solution
    {
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            IList<IList<int>> resultList = new List<IList<int>>();

            List<int> n = new List<int>(nums);
            n.Sort();

            //find all the combinations
            for (int i = 0; i < n.Count; i++)
            {
                if (i > 0 && n[i] == n[i - 1]) continue;

                for (int j = i + 1; j < n.Count; j++)
                {
                    if (j > i + 1 && n[j] == n[j - 1]) continue;

                    for (int k = j + 1; k < n.Count - 1; k++)
                    {
                        if (k > j + 1 && n[k] == n[k - 1]) continue;

                        int toFind = target - (n[i] + n[j] + n[k]);
                        if (toFind < n[k]) break;

                        int searchResult = -1;
                        if (toFind == n[k] && n[k] == n[k + 1]) searchResult = k + 1;
                        else
                            searchResult = n.BinarySearch(toFind);

                        if (searchResult > k)
                        {
                            resultList.Add(new List<int> { n[i], n[j], n[k], n[searchResult] });
                        }
                    }
                }
            }

            return resultList;
        }

        static void Main(string[] args)
        {
            Solution sol = new Solution();
            var result = sol.FourSum(new int[] { -1, 0, 1, 2, -1, -4 },0);
            var result2 = sol.FourSum(new int[] { 0, 0, 0 }, 0);
            var result3 = sol.FourSum(new int[] { 0, 0 }, 0);
            var result4 = sol.FourSum(new int[] { 1, 0, -1, 0, -2, 2 }, 2);
            var result5 = sol.FourSum(new int[] { -1, 0, 0, 1 }, 0);
        }
    }
}
