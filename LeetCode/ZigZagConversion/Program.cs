namespace ZigZagConversion
{
    public class Solution
    {
        public string Convert(string s, int numRows)
        {
            if (string.IsNullOrEmpty(s) || numRows == 1) return s;

            int[] pattern = new int[s.Length+1];
            pattern[0] = -1;
            int counter = 0;

            int RepeatingUnit = numRows + numRows - 2;

            for(int i=1;i<=numRows; i++)
            {
                int next = i;
                for(int j=0; RepeatingUnit*j+2 -i <= s.Length; j++)
                {
                    next = RepeatingUnit * j + 2 - i;
                    if (next > 0 && next <= s.Length)
                        if (pattern[counter] != next) pattern[++counter] = next;

                    next = RepeatingUnit * j + i;
                    if (next > 0 && next <= s.Length)
                        if (pattern[counter] != next) pattern[++counter] = next;
                }
            }

            string ret = "";
            for(int i=1; i<= s.Length; i++)
            {
                ret += s[pattern[i] - 1];
            }

            return ret;
        }



        static void Main(string[] args)
        {
            Solution sol = new Solution();
            string output = sol.Convert("PAYPALISHIRING", 3);
        }
    }
}
