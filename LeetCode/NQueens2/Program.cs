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

        public int NumberOfSolutions { get; set; }

        public void Initialize(int n)
        {
            horizontal = new int[n];
            slantleft = new int[n + n - 1];
            slantright = new int[n + n - 1];
            NumberOfSolutions = 0;
        }

        public void SolveNQueen(int layer, int n)
        {
            if (layer == n)
            {
                this.NumberOfSolutions++;
                return;
            }

            for (int i = 0; i < n; i++)
            {
                if (horizontal[i] == 0 && slantright[i + layer] == 0 && slantleft[n - i - 1 + layer] == 0)
                {
                    horizontal[i] = 1;
                    slantright[i + layer] = 1;
                    slantleft[n - i - 1 + layer] = 1;

                    SolveNQueen(layer + 1, n);

                    horizontal[i] = 0;
                    slantright[i + layer] = 0;
                    slantleft[n - i - 1 + layer] = 0;
                }
            }
        }

        public int TotalNQueens(int n)
        {
            if (n < 1)
            {
                return NumberOfSolutions;
            }
            Initialize(n);
            SolveNQueen(0, n);
            return NumberOfSolutions;
        }

        static void Main(string[] args)
        {
            Solution sol = new Solution();
            var final = sol.TotalNQueens(4);

        }
    }
}
