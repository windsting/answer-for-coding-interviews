using System;
using System.Collections.Generic;
using System.Text;

/*
 * 不用加减乘除做加法

题目描述

写一个函数，求两个整数之和，要求在函数体内不得使用+、-、*、/四则运算符号。
*/

namespace nowcoder {
    namespace Add {
        class Solution {
            public int Add(int num1, int num2) {
                int result = 0;
                bool carry = false;
                for(var i = 0; i < 32; ++i) {
                    var bit1 = getBit(num1, i);
                    var bit2 = getBit(num2, i);
                    bool bitCur = false;
                    if (carry) {
                        bitCur = (bit1 == bit2);
                        carry = (bit1 == 1 || bit2 == 1);
                    } else {
                        bitCur = (bit1 != bit2);
                        carry = (bit1 == 1 && bit2 == 1);
                    }

                    if (bitCur)
                        result = setBit(result, i);
                }

                return result;
            }

            int getBit(int num, int pos) {
                var mask = 1 << pos;
                if ((num & mask) == mask)
                    return 1;
                return 0;
            }

            int setBit(int num, int pos) {
                var mask = 1 << pos;
                return num | mask;
            }

            public static void Test() {
                TestCase(5, 3);

                System.Console.ReadKey();
            }


            static void TestCase(int n, int m) {
                var start = System.DateTime.Now;
                var obj = new Solution();
                var result = obj.Add(n, m);
                var elapse = (System.DateTime.Now - start).TotalMilliseconds;
                System.Console.WriteLine($"{result} -- with {elapse}ms");
            }
        }
    }
}
