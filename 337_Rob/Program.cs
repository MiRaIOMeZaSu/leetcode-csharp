using System;
using System.Collections.Generic;

namespace _337_Rob
{
    class Program
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
        public class Solution
        {
            public int Rob(TreeNode root)
            {
                Dictionary<TreeNode, int[]> dp_table = new Dictionary<TreeNode, int[]>();
                int[] result = dp(root, dp_table);
                return Math.Max(result[0], result[1]);
            }
            public int[] dp(TreeNode root, Dictionary<TreeNode, int[]> dp_table)
            {
                if (root == null)
                {
                    return new int[] { 0, 0 };
                }
                if (dp_table.ContainsKey(root))
                {
                    return dp_table[root];
                }
                int[] left = dp(root.left, dp_table);
                int[] right = dp(root.right, dp_table);
                /*
                只进行了两次计算,是原来的
                int do_it = root.val + Rob(root.left != null ? root.left.left : null) + Rob(root.left != null ? root.left.right : null)
                                + Rob(root.right != null ? root.right.left : null) + Rob(root.right != null ? root.right.right : null);
                int dont = Rob(root.left) + Rob(root.right);
                方法耗时的三分之一.
                这里避免使用Dictionary的原因是:输入序列较长时,写入Dictionary和读取消耗的时间也会较大
                测试后: new memo运行时间124 ms,内存消耗28.5 MB,使用Dictionary运行时间108 ms,内存消耗27.2 MB,实际上内存占用和时间消耗都增加了
                */
                int do_it = root.val + left[0] + right[0];
                int dont = Math.Max(right[0], right[1]) + Math.Max(left[0], left[1]);
                int[] result = new int[] { dont, do_it };
                dp_table.Add(root, result);
                return result;
            }
        }
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(3);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);
            root.left.right = new TreeNode(3);
            root.right.right = new TreeNode(1);
            Solution solution = new Solution();

            Console.WriteLine(solution.Rob(root));
        }
    }
}
