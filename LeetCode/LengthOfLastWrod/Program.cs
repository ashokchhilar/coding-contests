using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LengthOfLastWrod
{
    class Solution
    {
        public int LengthOfLastWord(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return 0;

            string[] pieces = s.Trim().Split(' ');
            if (pieces.Length <= 1) return 0;
            else
            {
                return pieces[pieces.Length - 1].Trim().Length;
            }
        }

        static void Main(string[] args)
        {
            Solution sol = new Solution();
            var len = sol.LengthOfLastWord("Hello World");
        }
    }
}
