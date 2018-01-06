using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotateImage
{
    public class Solution
    {
        public int map(int x, int extendedlen)
        {
            return (x + extendedlen / 2) / 2;
        }

        public void Rotate(int[,] matrix)
        {
            int len = matrix.GetLength(0);
            int extended = 2 * len - 1;

            //Rotation

            for (int i = -(extended) / 2; i <= 0; i++)
                for (int j = (extended) / 2; j > 0; j--)
                {
                    int a = i + extended / 2;
                    int b = j + extended / 2;
                    if (a % 2 == 1 || b % 2 == 1) continue;

                    int temp = matrix[map(i, extended), map(j, extended)];
                    matrix[map(i, extended), map(j, extended)] = matrix[map(-j, extended), map(i, extended)];
                    matrix[map(-j, extended), map(i, extended)] = matrix[map(-i, extended), map(-j, extended)];
                    matrix[map(-i, extended), map(-j, extended)] = matrix[map(j, extended), map(-i, extended)];
                    matrix[map(j, extended), map(-i, extended)] = temp;
                    // X,Y => Y, -X
                    // Y,-X    =>  -X, -Y
                    //-X,-Y   =>  -Y,X
                    //-Y,X => X,Y
                }
        }

        static void Main(string[] args)
        {
            int[,] matrix = new int[3, 3]
            {
                { 1, 2, 3 },
                { 4, 5, 6},
                { 7, 8, 9 }
            };

            int[,] mx = new int[4, 4]
            {
              { 5, 1, 9, 11 },
              { 2, 4, 8, 10},
              { 13, 3, 6, 7},
              { 15, 14, 12, 16}
            };

            Solution sol = new Solution();
            sol.Rotate(matrix);

            sol.Rotate(mx);
        }
    }
}
