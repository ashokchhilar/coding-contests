using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateParenthesis
{
    public class Solution
    {
        public void GenerateParenthesis(int open, int close, int n, string str, List<string> listOfString)
        {
            if(open == close && open == n)
            {
                listOfString.Add(str);
            }

            if (open < n)
            {
                GenerateParenthesis(open + 1, close, n, str + "(", listOfString);

                if (open > close)
                    GenerateParenthesis(open, close + 1, n, str + ")", listOfString);
            }
            else if (open == n && close < n)
            {
                GenerateParenthesis(open, close + 1, n, str + ")",listOfString);
            }
        }

        public IList<string> GenerateParenthesis(int n)
        {
            List<string> listOfString = new List<string>();
            GenerateParenthesis(0, 0, n, "", listOfString);

            return listOfString;
        }

        static void Main(string[] args)
        {
            Solution sol = new Solution();
            var result = sol.GenerateParenthesis(3);
        }
    }
}
