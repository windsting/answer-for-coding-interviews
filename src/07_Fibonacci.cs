using System;
using System.Collections.Generic;
using System.Text;

/*
 * 斐波那契数列

题目描述

大家都知道斐波那契数列，现在要求输入一个整数n，请你输出斐波那契数列的第n项（从0开始，第0项为0）。
n<=39
*/

namespace nowcoder {
    namespace Fibonacci {
        class Solution {
            public int Fibonacci(int n) {
                if (n == 0) {
                    return 0;
                }
                if (n == 1) {
                    return 1;
                }

                return Fibonacci(n - 1) + Fibonacci(n - 2);
            }

            public static void Test() {
                var obj = new Solution();
                for (int i = 0; i <= 39; i++) {
                    Console.WriteLine($"Fibonacci({i}):\t{obj.Fibonacci(i)}");
                }
            }
        }
    }
}
