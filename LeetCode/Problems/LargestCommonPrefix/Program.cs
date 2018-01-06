using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargestCommonPrefix
{
    public class Solution
    {
        public string LongestCommonPrefix(string[] strs)
        {
            if (strs == null || strs.Length == 0) return "";

            int minLen = strs.Min(x => x.Length);

            //what can we do to the string
            int i = 0;
            while (i < minLen)
            {
                char ch = strs.First()[i];
                if (strs.Any(x => x[i] != ch))
                {
                    break;
                }
                else i++;
            }

            return strs.First().Substring(0, i);
        }

        static void Main(string[] args)
        {
            string output = new Solution().LongestCommonPrefix(new string[] { "", "" });
        }
    }
}
