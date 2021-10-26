using System;

namespace _198_Rob
{
    class Program
    {
        public class Solution
        {
            public int Rob(int[] nums)
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
            int[] nums = { 2, 7, 9, 3, 1 };
            Solution solution = new Solution();
            Console.WriteLine(solution.Rob(nums));
        }
    }
}
