using System;
using System.Collections.Generic;
using System.Text;

/*
 * 滑动窗口的最大值

题目描述

给定一个数组和滑动窗口的大小，找出所有滑动窗口里数值的最大值。
例如，如果输入数组{2,3,4,2,6,2,5,1}及滑动窗口的大小3，
那么一共存在6个滑动窗口，他们的最大值分别为{4,4,6,6,6,5}；
针对数组{2,3,4,2,6,2,5,1}的滑动窗口有以下6个： 
    {[2,3,4],2,6,2,5,1}， 
    {2,[3,4,2],6,2,5,1}， 
    {2,3,[4,2,6],2,5,1}， 
    {2,3,4,[2,6,2],5,1}， 
    {2,3,4,2,[6,2,5],1}， 
    {2,3,4,2,6,[2,5,1]}。
*/

namespace nowcoder {
    namespace maxInWindows {
        class Solution {
            public int[] maxInWindows(int[] num, int size) {
                System.Collections.Generic.List<int> values = new System.Collections.Generic.List<int>();
                if (size > 0) {
                    for (var i = 0; i <= num.Length - size; ++i) {
                        values.Add(maxInWindow(num, i, size));
                    }
                }

                return values.ToArray();
            }

            int maxInWindow(int[] num, int start, int size) {
                var max = int.MinValue;
                for(int i = 0; i < size; ++i) {
                    var val = num[start + i];
                    if (val > max) {
                        max = val;
                    }
                }

                return max;
            }

            // Test
            public static void Test() {
                TestCase(new int[] { 2, 3, 4, 2, 6, 2, 5, 1 }, 3);
                //TestCase(TreeLinkNode.Create(new int[] { 8, 6, 10, 5, 7, 9, 11 }, 7));

                System.Console.ReadKey();
            }


            static void TestCase(int[] input, int size) {
                var start = System.DateTime.Now;
                var obj = new Solution();
                var result = obj.maxInWindows(input, size);
                var elapse = (System.DateTime.Now - start).TotalMilliseconds;
                System.Console.WriteLine($"{result} -- with {elapse}ms");
            }
        }
    }
}
