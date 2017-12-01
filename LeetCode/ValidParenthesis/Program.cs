using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidParenthesis
{
    public class Solution
    {

        /// <summary>
        /// '(', ')', '{', '}', '[' and ']'
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool IsValid(string s)
        {
            Dictionary<char, int> matches = new Dictionary<char, int>();
            matches.Add('(', 1);
            matches.Add(')', -1);
            matches.Add('{', 2);
            matches.Add('}', -2);
            matches.Add('[', 3);
            matches.Add(']', -3);

            Stack<int> inputStack = new Stack<int>();

            foreach (char ch in s)
            {
                if (!matches.ContainsKey(ch)) return false;

                if (matches[ch] > 0) inputStack.Push(matches[ch]);
                else
                {
                    if (inputStack.Count == 0) return false;

                    int matchingvalue = inputStack.Peek();
                    if (matchingvalue + matches[ch] != 0) return false;
                    else inputStack.Pop();
                }
            }

            return inputStack.Count == 0;
        }

        static void Main(string[] args)
        {
            Solution sol = new Solution();
            bool result = sol.IsValid("()[]{}");

            result = sol.IsValid("()");
            result = sol.IsValid("()[}");
            result = sol.IsValid("");
        }
    }
}
