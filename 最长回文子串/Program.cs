using System;

namespace 最长回文子串
{
    //给你一个字符串 s，找到 s 中最长的回文子串。



    //示例 1：

    //输入：s = "babad"    
    //输出："bab"
    //解释："aba" 同样是符合题意的答案。
    //示例 2：

    //输入：s = "cbbd"
    //输出："bb"
    //示例 3：

    //输入：s = "a"
    //输出："a"
    //示例 4：

    //输入：s = "ac"
    //输出："a"
    //https://leetcode-cn.com/problems/longest-palindromic-substring/solution/leetcode-5-longest-palindromic-substring-zui-chang/

    //回文串（palindromic string）是指这个字符串无论从左读还是从右读，所读的顺序是一样的；简而言之，回文串是左右对称的。所谓最长回文子串问题，是指对于一个给定的母串
    class Program
    {
        static void Main(string[] args)
        {
            LongestPalindrome("bacabad");
            Console.ReadKey();
        }

        //穷举法
        //时间复杂度: 判断是否为回文串的复杂度为O(n)，longestPalindrome有双层for循环，因此总的复杂度为为O(n^3)
        //空间复杂度：O(1)
        static string LongestPalindrome(string s)
        {
            string result = "";
            int n = s.Length;
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    // 检查 s[i]到s[j]是否是回文串，如果是，且长度大于result长度，就更新它
                    int p = i, q = j;
                    bool isPalindromic = true;
                    while (p < q)
                    {
                        var a = s[p++];
                        var b = s[q--];
                        if (a != b)
                        {
                            isPalindromic = false;
                            break;
                        }
                    }
                    if (isPalindromic)
                    {
                        int len = j - i + 1;
                        if (len > result.Length)
                        {
                            result = s.Substring(i, len);
                        }
                    }

                }
            }
            return result;
        }
    }
}
