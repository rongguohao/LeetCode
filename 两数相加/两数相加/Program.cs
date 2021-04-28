using System;

namespace 两数相加
{
    // 给出两个 非空 的链表用来表示两个非负的整数。其中，它们各自的位数是按照 逆序 的方式存储的，并且它们的每个节点只能存储 一位 数字。
    //
    // 如果，我们将这两个数相加起来，则会返回一个新的链表来表示它们的和。
    //
    // 您可以假设除了数字 0 之外，这两个数都不会以 0 开头。
    //
    // 示例：
    //
    // 输入：(2 -> 4 -> 3) + (5 -> 6 -> 4)
    // 输出：7 -> 0 -> 8
    // 原因：342 + 465 = 807
    //
    // 来源：力扣（LeetCode）
    // 链接：https://leetcode-cn.com/problems/add-two-numbers
    class Program
    {
        static void Main(string[] args)
        {
            var l1 = generateList(new int[] { 1, 5, 7 });
            var l2 = generateList(new int[] { 9, 8, 2, 9 });
            printList(l1);
            printList(l2);
            Solution s = new Solution();
            var sum = s.AddTwoNumbers(l1, l2);
            printList(sum);
        }

        static ListNode generateList(int[] vals)
        {
            ListNode res = null;
            ListNode last = null;
            foreach (var val in vals)
            {
                if (res is null)
                {
                    res = new ListNode(val);
                    last = res;
                }
                else
                {
                    last.next = new ListNode(val);
                    last = last.next;
                }
            }
            return res;
        }

        static void printList(ListNode l)
        {
            while (l != null)
            {
                Console.Write($"{l.val}, ");
                l = l.next;
            }
            Console.WriteLine("");
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    public class Solution
    {
        /// <summary>
        /// 迭代法
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            int val = 0;
            ListNode prenode = new ListNode(0);
            ListNode lastnode = prenode;
            while (l1 != null || l2 != null || val != 0)
            {
                val = val + (l1 == null ? 0 : l1.val) + (l2 == null ? 0 : l2.val);
                lastnode.next = new ListNode(val % 10);
                lastnode = lastnode.next;
                val = val / 10;
                l1 = l1 == null ? null : l1.next;
                l2 = l2 == null ? null : l2.next;
            }
            return prenode.next; // 去除头节点，返回头节点后面所有节点
        }

        ///// <summary>
        ///// 计算两个链表相加结果：递归法
        ///// </summary>
        ///// <param name="l1">链表1</param>
        ///// <param name="l2">链表2</param>
        ///// <param name="num">进位<param>
        ///// <returns>相加结果逆序链表</returns>
        //public ListNode AddTwoNumbers(ListNode l1, ListNode l2, int num = 0)
        //{
        //    /*递归边界：两个链表均为空*/
        //    if (l1 == null && l2 == null)
        //    {
        //        if (num != 0) return new ListNode(num);
        //        else return default;
        //    }

        //    /*计算两链表当前节点值相加之和：节点1值+节点2值+进位值*/
        //    int midValue = (l1?.val ?? 0) + (l2?.val ?? 0) + num;

        //    /*创建节点储存相加之和非进位部分*/
        //    ListNode listNode = new ListNode(midValue % 10);

        //    /*两链表指针右移，继续计算。*/
        //    listNode.next = AddTwoNumbers(l1?.next, l2?.next, midValue / 10);

        //    return listNode;
        //}
    }
}