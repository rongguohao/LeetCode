using System;

namespace Z_字形变换
{
    //将一个给定字符串 s 根据给定的行数 numRows ，以从上往下、从左到右进行 Z 字形排列。

    //比如输入字符串为 "PAYPALISHIRING" 行数为 3 时，排列如下：

    //P   A   H   N
    //A P L S I I G
    //Y   I   R
    //之后，你的输出需要从左往右逐行读取，产生出一个新的字符串，比如："PAHNAPLSIIGYIR"。

    //请你实现这个将字符串进行指定行数变换的函数：

    //string convert(string s, int numRows);


    //    示例 1：

    //输入：s = "PAYPALISHIRING", numRows = 3
    //输出："PAHNAPLSIIGYIR"
    //示例 2：
    //输入：s = "PAYPALISHIRING", numRows = 4
    //输出："PINALSIGYAHRPI"
    //解释：
    //P     I    N
    //A   L S  I G
    //Y A   H R
    //P     I
    //示例 3：

    //输入：s = "A", numRows = 1
    //输出："A"

    //来源：力扣（LeetCode）
    //链接：https://leetcode-cn.com/problems/zigzag-conversion
    //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Convert("PAYPALISHIRING", 3));
            Console.ReadKey();
        }

        static string Convert(string s, int numRows)
        {
            if (numRows <= 1) return s;
            string str = "";
            for (int i = 0; i < numRows; i++)
            {
                for (int j = i; j < s.Length; j++)
                {
                    if (j == i || ((j + i) % (numRows * 2 - 2) == 0) || ((j - i) % (numRows * 2 - 2) == 0))
                    {
                        str += s[j];
                    }
                }
            }

            return str;
        }

        //作者：lkj-6c
        //链接：https://leetcode-cn.com/problems/zigzag-conversion/solution/z-zi-xing-bian-huan-jing-jian-by-lkj-6c/
        //来源：力扣（LeetCode）
        //著作权归作者所有。商业转载请联系作者获得授权，非商业转载请注明出处。
    }
}
