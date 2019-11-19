using System;
using System.Collections.Generic;
using System.Text;

/*
 * 剪绳子

题目描述

给你一根长度为n的绳子，请把绳子剪成m段（m、n都是整数，n>1并且m>1），
每段绳子的长度记为k[0],k[1],...,k[m]。
请问k[0]xk[1]x...xk[m]可能的最大乘积是多少？
例如，当绳子的长度是8时，我们把它剪成长度分别为2、3、3的三段，此时得到的最大乘积是18。

输入描述:
输入一个数n，意义见题面。（2 <= n <= 60）

输出描述:
输出答案。

示例1

输入
8

输出
18
*/

namespace nowcoder {
    namespace cutRope {
        class Solution {
            public int cutRope(int number) {
                int maxProd = 0;
                int[] segments = new int[number];
                int maxSeg = 0;
                for (var i = 2; i <= number; ++i) {
                    var mean = number / i;
                    var remain = number % i;
                    int prod = 1;
                    for (int j = 0; j < i; ++j) {
                        int v = mean;
                        if (j < remain) {
                            v += 1;
                        }
                        prod *= v;
                    }
                    if (prod > maxProd) {
                        maxProd = prod;
                        maxSeg = i;
                    }

                }
                return maxProd;
            }

            // Test
            public static void Test() {
                TestCase(8);
                TestCase(2);

                System.Console.ReadKey();
            }


            static void TestCase(int input) {
                var start = System.DateTime.Now;
                var obj = new Solution();
                var result = obj.cutRope(input);
                var elapse = (System.DateTime.Now - start).TotalMilliseconds;
                System.Console.WriteLine($"{result} -- with {elapse}ms");
            }
        }
    }
}
