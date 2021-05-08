﻿using System;
using System.Linq;

namespace 整数反转
{
    //给你一个 32 位的有符号整数 x ，返回将 x 中的数字部分反转后的结果。

    //如果反转后整数超过 32 位的有符号整数的范围[−231, 231 − 1] ，就返回 0。

    //假设环境不允许存储 64 位整数（有符号或无符号）。
 

    //示例 1：

    //输入：x = 123
    //输出：321
    //示例 2：

    //输入：x = -123
    //输出：-321
    //示例 3：

    //输入：x = 120
    //输出：21
    //示例 4：

    //输入：x = 0
    //输出：0

    //来源：力扣（LeetCode）
    //链接：https://leetcode-cn.com/problems/reverse-integer
    //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }


        static int Reverse1(int x)
        {
            int rev = 0;
            while (x != 0)
            {
                if (rev < int.MinValue / 10 || rev > int.MaxValue / 10)
                {
                    return 0;
                }
                int digit = x % 10;
                x /= 10;
                rev = rev * 10 + digit;
            }
            return rev;
        }

        //作者：LeetCode-Solution
        //链接：https://leetcode-cn.com/problems/reverse-integer/solution/zheng-shu-fan-zhuan-by-leetcode-solution-bccn/
        //来源：力扣（LeetCode）
        //著作权归作者所有。商业转载请联系作者获得授权，非商业转载请注明出处。

        static int Reverse2(int x)
        {
            string s = x > 0 ? x.ToString() : (-x).ToString();
            s = new string(s.Reverse().ToArray());
            int res = 0;
            if (!int.TryParse(s, out res))
                return 0;
            return x > 0 ? res : -res;
        }

        //作者：zcy-r
        //链接：https://leetcode-cn.com/problems/reverse-integer/solution/yong-inttryparsepan-duan-yi-chu-by-zcy-r-29hw/
        //来源：力扣（LeetCode）
        //著作权归作者所有。商业转载请联系作者获得授权，非商业转载请注明出处。
    }
}
