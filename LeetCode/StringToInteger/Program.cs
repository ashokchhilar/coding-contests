using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringToInteger
{
    public class Solution
    {
        public int MyAtoi(string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return 0;

            int actualSignCounts = 0;
            if (str.Contains('-')) actualSignCounts++;
            if (str.Contains('+')) actualSignCounts++;
            if (actualSignCounts > 1) return 0;

            //remove all spaces
            str = str.Replace(" ", "");
            int sign = str.StartsWith("-") ? -1 : 1;
            str = str.Replace("-", "");
            str = str.Replace("+", "");

            int num = 0;
            foreach(char ch in str)
            {
                int diff = ch - '0';
                if (diff < 0 || diff > 9) return 0;
                num = num * 10 + ch - '0';
            }
            return num * sign;
        }

        static void Main(string[] args)
        {

            Solution sol = new Solution();
            int result = sol.MyAtoi("-29834");
            int result2 = sol.MyAtoi("+29834");
            int result3 = sol.MyAtoi("+-2");
        }
    }
}
