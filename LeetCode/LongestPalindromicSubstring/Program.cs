using System;

namespace LongestPalindromicSubstring
{
    public class Solution
    {
        public string preProcess(string s)
        {
            //Pre process the string to insert hashes
            if (string.IsNullOrEmpty(s)) return "^$";

            string ret = "^";
            for(int i=0; i<s.Length;i++)
            {
                ret += "#" + s[i];
            }
            ret += "#$";
            return ret;
        }


        //Finds the longest palindrome substring based on Manacher's Algorithm
        public string LongestPalindrome(string s)
        {
            //implement for odd numbered length strings
            int C=0, R=0;
            string T = preProcess(s);
            int[] P = new int[T.Length];
            for (int i = 0; i < T.Length; i++) P[i] = 0;

            for(int i=1; i<T.Length-1; i++)
            {
                int i_mirror = C - (i - C);
                P[i] = (R > i) ? min(P[i_mirror], R - i) : 0;

                while (T[i - P[i] - 1] == T[i + P[i] + 1]) P[i]++;

                if(i + P[i] > R)
                {
                    C = i;
                    R = i + P[i];
                }
            }

            int maxlen = 0;
            int startindex = 0;
            for(int i=0; i<P.Length;i++)
            {
                if(maxlen < P[i])
                {
                    maxlen = P[i];
                    startindex = i;
                }
            }

            //Extract the actual subarray
            return s.Substring((startindex - maxlen-1)/2, maxlen);
        }

        private int min(int v1, int v2)
        {
            if (v1 < v2) return v1;
            return v2;
        }

        static void Main(string[] args)
        {
            Solution sol = new Solution();

            string str = "abba";
            do
            {
                Console.WriteLine(sol.LongestPalindrome(str));
                str = Console.ReadLine();
            } while (str != "exit");
        }
    }
}
