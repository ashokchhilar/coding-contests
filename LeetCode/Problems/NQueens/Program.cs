using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQueens
{
    public class Solution
    {
        public int[] horizontal { get; set; }
        public int[] slantright { get; set; }
        public int[] slantleft { get; set; }

        public void Initialize(int n)
        {
            horizontal = new int[n];
            slantleft = new int[n + n - 1];
            slantright = new int[n + n - 1];
        }


        public IList<string> printarray(int[] arr)
        {
            IList<string> stringlist = new List<string>();

            for (int i = 0; i < arr.Length; i++)
            {
                StringBuilder sb = new StringBuilder(arr.Length).Insert(0,".", arr.Length-1);
                sb.Insert(arr[i], 'Q');
                stringlist.Add(sb.ToString());
            }
            return stringlist;
        }

        public void SolveNQueen(int layer, int n, int[] solution, IList<IList<string>> sol)
        {
            if (layer == n)
            {
                sol.Add(printarray(solution));
                return;
            }

            for(int i=0; i<n; i++)
            {
                if(horizontal[i] == 0 && slantright[i+layer] == 0 && slantleft[n-i-1 + layer] == 0)
                {
                    horizontal[i] = 1;
                    slantright[i + layer] = 1;
                    slantleft[n - i - 1 + layer] = 1;
                    solution[layer] = i;

                    SolveNQueen(layer + 1, n, solution, sol);

                    horizontal[i] = 0;
                    slantright[i + layer] = 0;
                    slantleft[n - i - 1 + layer] = 0;
                }
            }
        }

        public IList<IList<string>> SolveNQueens(int n)
        {
            IList<IList<string>> finalSolution = new List<IList<string>>();
            if (n < 1)
            {
                finalSolution.Add(new List<string>());
                return finalSolution;
            }
            Initialize(n);
            int[] solved = new int[n];
            SolveNQueen(0, n, solved, finalSolution);
            return finalSolution;
        }

        static void Main(string[] args)
        {
            Solution sol = new Solution();

            var final = sol.SolveNQueens(0);

        }
    }
}
