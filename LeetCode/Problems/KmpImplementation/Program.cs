using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KmpImplementation
{

    public class KMP
    {
        public int[] PreprocessString(string pattern)
        {
            //Example:
            // AAABAAAABAACDEAAAAAFGAAAB
            // 0120123345600012333001234

            int[] P = new int[pattern.Length];

            int len = 0;
            int i = 1;
            P[0] = 0;   //P[0] is always zero

            while (i < pattern.Length)
            {
                if (pattern[i] == pattern[len])
                {
                    P[i] = len + 1;
                    i++;
                    len++;
                }
                else
                {
                    if (len != 0) len = P[len - 1];
                    else i++;
                }
            }
            return P;
        }

        public int StrStr(string text, string pattern)
        {
            if (text == null || pattern == null) return -1;
            if (pattern == string.Empty) return 0;

            int[] P = PreprocessString(pattern);

            int i = 0;
            int p = 0;
            while(i < text.Length)
            {
                if (p == P.Length)
                    return i - P.Length;

                if(text[i] == pattern[p])
                {
                    i++;
                    p++;
                }
                else
                {
                    if (p > 0)
                        p = P[p - 1];
                    else i++;
                }
            }

            if (p == P.Length) return i - p;
            return -1;
        }

    }



    class Program
    {
        public static string printIntArray(int[] array)
        {
            StringBuilder sb = new StringBuilder();

            foreach (int n in array)
                sb.Append(n);

            return sb.ToString();
        }

        static void Main(string[] args)
        {
            //Example:
            // AAABAAABAACDEAAAAAFGAAAB
            // 012012345600012333001234
            KMP kmp = new KMP();

            string pattern = "AAABAAA";
            var result = kmp.PreprocessString(pattern);
            string rs = printIntArray(result);


            int match = kmp.StrStr("AAACAAAAAAABAAA", pattern);
        }
    }
}
