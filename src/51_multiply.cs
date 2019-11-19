using System;
using System.Collections.Generic;
using System.Text;

/*
 * 构建乘积数组

题目描述

给定一个数组A[0, 1,..., n - 1], 请构建一个数组B[0, 1,..., n - 1], 
其中B中的元素B[i] = A[0] * A[1] *...* A[i - 1] * A[i + 1] *...* A[n - 1]。
不能使用除法。
*/

namespace nowcoder {
    namespace multiply {
        class Solution {
            public int[] multiply(int[] A) {
                var arr = new int[A.Length];
                var val = 1;
                for (int i = 0; i < A.Length; ++i) {
                    arr[i] = val;
                    val = val * A[i];
                }
                val = 1;
                for(int i = A.Length - 1; i >= 0; --i) {
                    arr[i] = arr[i] * val;
                    val = val * A[i];
                }
                return arr;
            }

            public static void Test() {
                TestCase(new int[] { 1, 2, 3, 4, 5 });

                System.Console.ReadKey();
            }


            static void TestCase(int[] input) {
                var start = System.DateTime.Now;
                var obj = new Solution();
                var result = obj.multiply(input);
                var elapse = (System.DateTime.Now - start).TotalMilliseconds;
                System.Console.WriteLine($"{result} -- with {elapse}ms");
            }
        }
    }
}
