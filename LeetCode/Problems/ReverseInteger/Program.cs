namespace ReverseInteger
{
    public class Solution
    {
        public int Reverse(int x)
        {
            int sign = x > 0 ? 1 : -1;
            x = x * sign;

            int rev = 0;
            while(x > 0)
            {
                if (rev > (int.MaxValue - x % 10)/10) return 0;
                rev = rev * 10 + x % 10;
                x = x / 10;
            }
            return sign * rev;
        }

        static void Main(string[] args)
        {
            Solution sol = new Solution();
            int input = 1534236469;
            int rev = sol.Reverse(input);
        }
    }
}
