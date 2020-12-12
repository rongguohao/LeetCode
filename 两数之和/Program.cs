using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace 两数之和
{
    //给定一个整数数组 nums 和一个目标值 target，请你在该数组中找出和为目标值的那 两个 整数，并返回他们的数组下标。

    //你可以假设每种输入只会对应一个答案。但是，数组中同一个元素不能使用两遍。

    //示例:

    //给定 nums = [2, 7, 11, 15], target = 9

    //因为 nums[0] + nums[1] = 2 + 7 = 9
    //所以返回[0, 1]

    //来源：力扣（LeetCode）
    //链接：https://leetcode-cn.com/problems/two-sum

    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = {2, 7, 11, 15};
            int target = 9;
            Console.WriteLine(string.Join(',',TwoSum1(nums, target)));
            Console.ReadKey();
        }

        static int[] TwoSum1(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        return new int[] {i, j};
                    }
                }
            }

            return new int[] {0, 0};
        }
        
        //对于方法一的时间复杂度 O(n^2) 不太满意，我们需要一种更有效的方法来检查数组中是否存在目标元素。如果存在，我们需要找出它的索引。保持数组中每个元素与其索引相互对应的最好方法是 哈希表。
        static int[] TwoSum2(int[] nums, int target)
        {
            Dictionary<int, int> kvs = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                //需要对重复值进行判断；因为结果的唯一，所以若有重复值，且答案中包含了重复值的话，说明必有 重复值*2==target; 否则直接忽略重复值即可
                if (kvs.ContainsKey(nums[i]))
                {
                    if (nums[i] * 2 == target)
                    {
                        return new int[] { i, kvs[nums[i]] };
                    }
                }
                else
                {
                    kvs.Add(nums[i], i);
                }
            }
            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (kvs.ContainsKey(complement) && kvs[complement] != i)
                {
                    return new int[] { i, kvs[complement] };
                }
            }
            return new int[] { 0, 0 };
        }
        
        
        //事实证明，我们可以一次完成。在进行迭代并将元素插入到表中的同时，我们还会回过头来检查表中是否已经存在当前元素所对应的目标元素。如果它存在，那我们已经找到了对应解，并立即将其返回。
        static int[] TwoSum3(int[] nums, int target)
        {
            Dictionary<int, int> kvs = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (kvs.ContainsKey(complement) && kvs[complement] != i)
                {
                    return new int[] { i, kvs[complement] };
                }
                //需要对重复值进行判断,若结果包含了重复值，则已经被上面给return了；所以此处对于重复值直接忽略
                if (!kvs.ContainsKey(nums[i]))
                {
                    kvs.Add(nums[i], i);
                }
            }
            return new int[] { 0, 0 };
        }
    }
}