using System;
using System.Collections.Generic;

namespace RegularExpressionMatching
{
    public class Solution
    {
        public bool IsMatch(string s, string p)
        {
            bool?[,] match = new bool?[p.Length+1, s.Length+1];

            return recursiveSolution(0, 0, p, s, match);
        }

        public bool recursiveSolution(int i, int j, string P, string T, bool?[,] match)
        {
            if (i == P.Length && j == T.Length)
            {
                match[i, j] = true;
                return true;
            }

            if (i <= P.Length && j <= T.Length && match[i, j].HasValue) return match[i, j].Value;

            if (i >= P.Length) return false;
            if (j > T.Length) return false;

            if(P[i] == '*')
            {
                int k = j;
                if (recursiveSolution(i + 1, k, P, T, match)) { match[i, j] = true; return true; }

                while (k < T.Length && (T[k++] == P[i-1] || P[i-1] == '.'))
                {
                    if (recursiveSolution(i + 1, k, P, T, match)) { match[i, j] = true; return true; }
                }
            }
            else
            {
                //its a string
                if (j < T.Length)
                {
                    if ((T[j] == P[i] || P[i] == '.') && recursiveSolution(i + 1, j + 1, P, T, match)) { match[i, j] = true; return true; }
                }

                if (i+1 < P.Length && P[i + 1] == '*')
                    return recursiveSolution(i + 1, j, P, T, match);
            }
            match[i, j] = false;
            return false;
        }


        static void Main(string[] args)
        {
            Solution sol = new Solution();
            var match = sol.IsMatch("aa", "a");//→ false
            var match2 = sol.IsMatch("aa", "aa") ;//→ true
            var match3 = sol.IsMatch("aaa", "aa") ;//→ false
            var match4 = sol.IsMatch("aa", "a*") ;//→ true
            var match5 = sol.IsMatch("aa", ".*") ;//→ true
            var match6 = sol.IsMatch("ab", ".*") ;//→ true
            var match7 = sol.IsMatch("aab", "c*a*b") ;//→ true
            var match8 = sol.IsMatch("a", "ab*");//→ true
            var match9 = sol.IsMatch("bbbba", ".*a*a"); //true
            var match10 = sol.IsMatch("ab", ".*.."); //true
            var match11 = sol.IsMatch("aaaaaaaaaaaaab", "a*a*a*a*a*a*a*a*a*a*c");
        }
    }
}
