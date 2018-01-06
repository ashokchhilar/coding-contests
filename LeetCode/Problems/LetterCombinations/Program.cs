using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetterCombinations
{
    public class Solution
    {
        List<List<char>> allCombinations = new List<List<char>> { new List<char>{ },
            new List<char> { 'a','b','c'},
            new List<char> {'d','e','f' },
            new List<char> {'g','h','i'},
            new List<char> {'j','k','l' },
            new List<char> {'m','n','o' },
            new List<char> { 'p','q','r','s'},
            new List<char> {'t','u','v' },
            new List<char> {'w','x','y','z' } };

        /// <summary>
        /// Generate all possible combinations
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        public IList<string> LetterCombinations(string digits)
        {
            IList<string> listOfStrings = new List<string>();
            if (string.IsNullOrWhiteSpace(digits)) return listOfStrings;

            int[] nums = new int[digits.Length];

            listOfStrings.Add(GenerateString(nums, digits));

            while(nums[0] <= allCombinations[digits[0] - '1'].Count)
            {
                StringBuilder sb = new StringBuilder();
                int j = nums.Length - 1;
                while (j >=0 && nums[j] >= allCombinations[digits[j] - '1'].Count-1) j--;

                if (j < 0) return listOfStrings;
                else
                {
                    nums[j]++;
                    int k = j + 1;
                    while (k < nums.Length) nums[k++] = 0;
                    string str = GenerateString(nums, digits);
                    listOfStrings.Add(str);
                }
            }

            return listOfStrings;
        }

        private string GenerateString(int[] nums, string digits)
        {
            char[] s = new char[digits.Length];

            for(int i=0;i<nums.Length; i++)
            {
                s[i] = allCombinations[digits[i] - '1'][nums[i]];
            }
            return new string(s);
        }

        static void Main(string[] args)
        {
            Solution sol = new Solution();
            var result = sol.LetterCombinations("2");

        }
    }
}
