using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestValidParenthesis
{
    public class Solution
    {
        public int LongestValidParentheses(string s)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(-1);
            int max = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    stack.Push(i);
                }
                else
                {
                    stack.Pop();
                    if (stack.Count == 0) stack.Push(i);
                    else
                    {
                        int len = i - stack.Peek();
                        if (len > max) max = len;
                    }
                }
            }
            return max;
        }

        static void Main(string[] args)
        {
            string p = "((())()";
            Solution sol = new Solution();
            int result = sol.LongestValidParentheses(p);
        }
    }
}
