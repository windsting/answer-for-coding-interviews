using System;
using System.Collections.Generic;
using System.Text;

/*
 * 二进制中1的个数

题目描述

输入一个整数，输出该数二进制表示中1的个数。其中负数用补码表示。
*/

namespace nowcoder {
    namespace NumberOf1 {
        class Solution {
            public int NumberOf1(int n) {
                uint v = (uint)n;
                int c = 0;
                while (v != 0) {
                    v = v & (v - 1);
                    c++;
                }

                return c;
            }

            public static void Test() {
                var obj = new Solution();
                for (int i = -10; i < 50; i++) {
                    Console.WriteLine($"{obj.NumberOf1(i)} for {i}");
                }
            }
        }
    }
}
