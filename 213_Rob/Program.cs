using System;

namespace _213_Rob
{
    class Program
    {
        public class Solution
        {
            public int Rob(int[] nums)
            {
                int size = nums.Length;
                if (size == 1)
                {
                    return nums[0];
                }
                int a = dp(nums[0..(size - 1)]);
                int b = dp(nums[1..size]);
                return Math.Max(a, b);
            }
            public int dp(int[] nums)
            {
                // *与股票问题不同,此题考虑剩下的区间中的最优值
                int size = nums.Length;
                if (size == 0)
                {
                    return 0;
                }
                // [start..]区间中的值
                int do_it = nums[size - 1];
                int dont = 0;
                int temp;
                for (int i = size - 2; i >= 0; i--)
                {
                    temp = do_it;
                    do_it = dont + nums[i];
                    dont = dont > temp ? dont : temp;
                    // Console.WriteLine("when i={0}", i);
                    // Console.WriteLine(String.Format("do_it:{0}", do_it));
                    // Console.WriteLine(String.Format("dont:{0}", dont));
                }
                return Math.Max(do_it, dont);
            }
        }
        static void Main(string[] args)
        {
            int[] nums = { 3 };
            Solution solution = new Solution();
            Console.WriteLine(solution.Rob(nums));
        }
    }
}
