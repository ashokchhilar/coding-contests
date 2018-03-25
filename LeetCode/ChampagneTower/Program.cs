using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampagneTower
{
    public class Fraction
    {
        public int numerator { get; private set; }
        public int denominator { get; private set; }

        public Fraction(int n, int d)
        {
            numerator = n;
            denominator = d;
        }

        public static Fraction operator +(Fraction c1, Fraction c2)
        {
            return new Fraction(c1.numerator*c2.denominator + c2.numerator*c1.denominator, c1.denominator*c2.denominator);
        }
    }

    public class Solution
    {
        public double ChampagneTower(int poured, int query_row, int query_glass)
        {
            double[,] flow = new double[102, 102];
            flow[0, 0] = poured;

            for(int i=0; i<=query_row; i++)
            {
                for(int j = 0; j<=i; j++)
                {
                    double halfFlow = (flow[i, j] - 1) / 2;
                    halfFlow = halfFlow > 0 ? halfFlow : 0;

                    flow[i + 1, j] += halfFlow;
                    flow[i + 1, j+1] += halfFlow;
                }
            }

            return flow[query_row, query_glass] > 1 ? 1 : flow[query_row, query_glass];
        }
    static void Main(string[] args)
        {
            Solution sol = new Solution();
            var result = sol.ChampagneTower(poured: 2, query_glass: 1, query_row: 1);
        }
    }
}
