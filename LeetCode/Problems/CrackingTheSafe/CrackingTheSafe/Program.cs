using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheSafe
{
    public class Solution
    {
        HashSet<string> seen = new HashSet<string>();
        StringBuilder ans = new StringBuilder();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public string CrackSafe(int n, int k)
        {
            //Create initial string of zeros of length n
            String start = new string('0', n);
            seen.Add(start);
            dfs(start.Substring(1), k);
            ans.Append(start);
            return ans.ToString();
        }

        public void dfs(string start, int k)
        {
            for (int i = 0; i < k; i++)
            {
                string neo = start + i;
                if (!seen.Contains(neo))
                {
                    seen.Add(neo);
                    dfs(neo.Substring(1), k);
                    ans.Append(i);
                }
            }
        }

        static void Main(string[] args)
        {
            Solution sol = new Solution();
            string result = sol.CrackSafe(2, 2);
        }
    }
}
