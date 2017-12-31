using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReachANumber
{
    public class Solution
    {
        public int ReachNumber(int target)
        {
            if (target < 0) target = target * -1;

            int i = 1;
            while (((i * (i + 1)) / 2 - target) < 0 || ((i * (i + 1)) / 2 - target) % 2 != 0) i++;
            return i;
        }

        static void Main(string[] args)
        {
            Solution sol = new Solution();
            var result = sol.ReachNumber(-3);
            var result2 = sol.ReachNumber(3);
        }
    }
}
