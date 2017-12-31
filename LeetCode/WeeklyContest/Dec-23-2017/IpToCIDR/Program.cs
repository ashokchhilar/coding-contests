using System;
using System.Collections.Generic;

namespace IpToCIDR
{
    class Solution
    {

        /// <summary>
        /// Last Significant bit
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int LastSignificantBit(Int64 n)
        {
            int i = 1;
            int pow = 1;

            while((n & i) == 0)
            {
                i = i << 1;
                pow++;
            }

            return pow;
        }


        /// <summary>
        /// Nearest power of 2 lower than or equal to n
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int NearestPower(Int64 n)
        {
            int i = 1;
            int pow = 0;

            while( i <= n)
            {
                i = i << 1;
                pow++;
            }

            return pow;
        }

        public Int64 ConvertToLong(string ip)
        {
            string[] pieces = ip.Split('.');
            return (Int64.Parse(pieces[0]) << 24) + (Int64.Parse(pieces[1]) << 16) + (Int64.Parse(pieces[2]) << 8) + (Int64.Parse(pieces[3]));
        }

        public string ConvertToIp(Int64 num)
        {
            string str = (num % 256).ToString();
            num = num >> 8;

            while (num > 0)
            {
                long t = num % 256;
                num = num >> 8;
                str = t.ToString()+"." + str;
            }
            return str;
        }

        public IList<string> IpToCIDR(string ip, int range)
        {
            Int64 num = ConvertToLong(ip);
            IList<string> strlist = new List<string>();

            int count = 0;
            while(count < range)
            {
                int bitsmoved = Math.Min(LastSignificantBit(num), NearestPower(range-count));
                int covered = 1 << (bitsmoved-1);
                if (covered > (range - count))
                {
                    covered = range - count;
                }
                strlist.Add("" + ConvertToIp(num) + "/" + (32 - bitsmoved + 1));

                count = count + covered;
                num += covered;
            }

            return strlist;
        }

        static void Main(string[] args)
        {
            Solution sol = new Solution();
            var result = sol.IpToCIDR("0.171.255.5", 422);
            Int64 num = sol.ConvertToLong("1.0.0.0");
        }
    }
}
