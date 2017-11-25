using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestSubstringWithoutRepeatingCharacters
{
    public class Solution
    {
        public int LengthOfLongestSubstring(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;

            int[] characters = new int[512];
            for (int i = 0; i < characters.Length; i++) characters[i] = -1;

            int strt = 0;
            characters[s[0]] = 0;
            int maxLength = 1;

            for (int i = 1; i < s.Length; i++)
            {
                if (characters[s[i]] == -1)
                {
                    characters[s[i]] = i;
                }
                else
                {
                    if (maxLength < i - strt)
                    {
                        maxLength = i - strt;
                    }

                    while (strt <= characters[s[i]])
                    {
                        characters[s[strt++]] = -1;
                    }
                    characters[s[i]] = i;
                }
            }
            if (maxLength < s.Length - strt) maxLength = s.Length - strt;

            return maxLength;
        }

        static void Main(string[] args)
        {
            Solution s = new Solution();
            string line = Console.ReadLine();

            int maxlen = s.LengthOfLongestSubstring(line);
        }
    }
}
