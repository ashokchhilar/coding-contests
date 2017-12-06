using System;
using System.Collections.Generic;

namespace TrappingRainWater
{
    public class Solution
    {
        public int Trap(int[] height)
        {
            Stack<int> wallStack = new Stack<int>();

            int totalArea = 0;

            for(int i=0; i<height.Length; i++)
            {
                while(wallStack.Count != 0 && height[wallStack.Peek()] < height[i])
                {
                    var top = wallStack.Pop();
                    if (wallStack.Count == 0) break;

                    int boundingheight = Math.Min(height[wallStack.Peek()], height[i]) - height[top];
                    int boundingdistance = i - wallStack.Peek() - 1;
                    var area = boundingheight * boundingdistance;
                    totalArea += area;
                }
                wallStack.Push(i);
            }
            return totalArea;
        }


        public static void Main(string[] args)
        {
            int[] sample = new int[] {  };
            Solution sol = new Solution();
            var result = sol.Trap(sample);
        }
    }
}
