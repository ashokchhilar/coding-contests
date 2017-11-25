using System;
using System.Collections.Generic;

namespace TwoSum
{
    public class Solution
    {
        public int[] TwoSum(int[] nums, int target)
        {

            Dictionary<int, int> myDictionary = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!myDictionary.ContainsKey(nums[i]))
                    myDictionary.Add(nums[i], i);
                else
                {
                    if (target == 2 * nums[i])
                    {
                        return new[] { myDictionary[nums[i]], i };
                    }
                    else
                    {
                        //throw new ArgumentException();
                    }
                }
            }

            foreach (var kvp in myDictionary)
            {
                if (myDictionary.ContainsKey(target - kvp.Key) && myDictionary[target - kvp.Key] != kvp.Value)
                {
                    return new[] { kvp.Value, myDictionary[target - kvp.Key] };
                }
            }

            throw new ArgumentException("Solution Not found");
        }

        static void Main(string[] args)
        {
        }
    }
}
