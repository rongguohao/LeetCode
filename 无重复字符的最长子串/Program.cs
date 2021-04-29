using System;
using System.Collections.Generic;

namespace 无重复字符的最长子串
{
    //给定一个字符串，请你找出其中不含有重复字符的 最长子串 的长度。

    //示例 1:

    //输入: s = "abcabcbb"
    //输出: 3 
    //解释: 因为无重复字符的最长子串是 "abc"，所以其长度为 3。
    //示例 2:

    //输入: s = "bbbbb"
    //输出: 1
    //解释: 因为无重复字符的最长子串是 "b"，所以其长度为 1。
    //示例 3:

    //输入: s = "pwwkew"
    //输出: 3
    //解释: 因为无重复字符的最长子串是 "wke"，所以其长度为 3。
    //     请注意，你的答案必须是 子串 的长度，"pwke" 是一个子序列，不是子串。
    //示例 4:

    //输入: s = ""
    //输出: 0
    //https://leetcode-cn.com/problems/longest-substring-without-repeating-characters/
    class Program
    {
        static void Main(string[] args)
        {
            string demo = "0123456";
            Console.WriteLine(demo[3]);
            Console.WriteLine(Math.Max(5, 1)); //返回两个中 较大的一个

            while (true)
            {
                var input = Console.ReadLine();

                Console.WriteLine(LengthOfLongestSubstring(input));
            }
        }



        public static int LengthOfLongestSubstring(string s)
        {
            HashSet<char> letter = new HashSet<char>();// 哈希集合，记录每个字符是否出现过
            int left = 0, right = 0;//初始化左右指针，指向字符串首位字符
            int length = s.Length;
            int count = 0, max = 0;//count记录每次指针移动后的子串长度
            while (right < length)
            {
                if (!letter.Contains(s[right]))//右指针字符未重复
                {
                    letter.Add(s[right]);//将该字符添加进集合
                    right++;//右指针继续右移
                    count++;
                }
                else//右指针字符重复，左指针开始右移，直到不含重复字符（即左指针移动到重复字符(左)的右边一位）
                {
                    letter.Remove(s[left]);//去除集合中当前左指针字符
                    left++;//左指针右移
                    count--;
                }
                max = Math.Max(max, count); //返回两个中 较大的一个
            }
            return max;
        }
    }
}
