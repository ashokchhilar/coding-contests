using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountAndSay
{
    public class Solution
    {
        public string GenerateCountString(string str)
        {
            int count = 1;
            StringBuilder sb = new StringBuilder();

            for(int i=1;i<str.Length; i++)
            {
                if (str[i] == str[i - 1]) count++;
                else
                {
                    sb.Append(count.ToString() + str[i - 1]);
                    count = 1;
                }
            }

            sb.Append(count.ToString() + str[str.Length - 1]);
            return sb.ToString();
        }

        public string CountAndSay(int n)
        {
            string start = "1";
            for(int i=1; i<n;i++)
            {
                start = GenerateCountString(start);
            }

            return start;
        }

        static void Main(string[] args)
        {
            Solution sol = new Solution();
            var res = sol.CountAndSay(10);
        }
    }
}
