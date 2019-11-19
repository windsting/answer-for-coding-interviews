using System;
using System.Collections.Generic;
using System.Text;

/*
 * 数据流中的中位数

题目描述

如何得到一个数据流中的中位数？如果从数据流中读出奇数个数值，
那么中位数就是所有数值排序之后位于中间的数值。如果从数据流中读出偶数个数值，
那么中位数就是所有数值排序之后中间两个数的平均值。

我们使用Insert()方法读取数据流，
使用GetMedian()方法获取当前读取数据的中位数。
*/

namespace nowcoder {
    namespace GetMedian {
        class Solution {
            System.Collections.Generic.List<int> Values;
            public void Insert(int num) {
                if(Values == null) {
                    Values = new System.Collections.Generic.List<int>();
                }

                for(var i = 0; i < Values.Count; ++i) {
                    if (Values[i] >= num) {
                        Values.Insert(i, num);
                        return;
                    }
                }

                Values.Add(num);
            }

            public double GetMedian() {
                var count = Values.Count;
                if (count == 0) {
                    return 0;
                }
                if ((count & 1) == 1) {
                    return Values[count >> 1];
                }

                var index = count >> 1;
                return (Values[index] + Values[index - 1]) * 1.0 / 2;
            }

            // Test
            public static void Test() {
                TestCase(new int[] { 5, 2, 3, 4, 1, 6, 7, 0, 8 });
                //TestCase(TreeLinkNode.Create(new int[] { 8, 6, 10, 5, 7, 9, 11 }, 7));

                System.Console.ReadKey();
            }


            static void TestCase(int[] input) {
                var start = System.DateTime.Now;
                var obj = new Solution();
                var result = new List<double>();
                foreach(var v in input) {
                    obj.Insert(v);
                    result.Add(obj.GetMedian());
                }
                var elapse = (System.DateTime.Now - start).TotalMilliseconds;
                System.Console.WriteLine($"{result} -- with {elapse}ms");
            }
        }
    }
}
