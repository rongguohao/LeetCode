using System;

namespace 寻找两个正序数组的中位数
{
    //    给定两个大小分别为 m 和 n 的正序（从小到大）数组 nums1 和 nums2。请你找出并返回这两个正序数组的 中位数 。

    //示例 1：

    //输入：nums1 = [1,3], nums2 = [2]
    //    输出：2.00000
    //解释：合并数组 = [1,2,3] ，中位数 2
    //示例 2：

    //输入：nums1 = [1,2], nums2 = [3,4]
    //    输出：2.50000
    //解释：合并数组 = [1,2,3,4] ，中位数(2 + 3) / 2 = 2.5
    //示例 3：

    //输入：nums1 = [0,0], nums2 = [0,0]
    //    输出：0.00000
    //示例 4：

    //输入：nums1 = [], nums2 = [1]
    //    输出：1.00000
    //示例 5：

    //输入：nums1 = [2], nums2 = []
    //    输出：2.00000

    //提示：

    //nums1.length == m
    //nums2.length == n
    //0 <= m <= 1000
    //0 <= n <= 1000
    //1 <= m + n <= 2000
    //-106 <= nums1[i], nums2[i] <= 106

    //进阶：你能设计一个时间复杂度为 O(log (m+n)) 的算法解决此问题吗？
    //https://leetcode-cn.com/problems/median-of-two-sorted-arrays/solution/leetcode-4-median-of-two-sorted-arrays-xun-zhao-li/
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.ReadKey();
        }


        static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int n = nums1.Length;
            int m = nums2.Length;
            int len = n + m;
            int kPre = (len + 1) / 2;
            int k = (len + 2) / 2;
            if (len % 2 == 0)
                return (GetKth(nums1, 0, n - 1, nums2, 0, m - 1, kPre) + GetKth(nums1, 0, n - 1, nums2, 0, m - 1, k)) * 0.5;
            else
                return GetKth(nums1, 0, n - 1, nums2, 0, m - 1, k);
        }

        static int GetKth(int[] nums1, int start1, int end1, int[] nums2, int start2, int end2, int k)
        {
            int len1 = end1 - start1 + 1;
            int len2 = end2 - start2 + 1;
            //让 len1 的长度小于 len2，这样就能保证如果有数组空了，一定是 len1 
            if (len1 > len2) return GetKth(nums2, start2, end2, nums1, start1, end1, k);
            if (len1 == 0) return nums2[start2 + k - 1];
            if (k == 1) return Math.Min(nums1[start1], nums2[start2]);
            int i = start1 + Math.Min(len1, k / 2) - 1;
            int j = start2 + Math.Min(len2, k / 2) - 1;
            if (nums1[i] > nums2[j])
                return GetKth(nums1, start1, end1, nums2, j + 1, end2, k - (j - start2 + 1));
            else
                return GetKth(nums1, i + 1, end1, nums2, start2, end2, k - (i - start1 + 1));
        }
    }
}
