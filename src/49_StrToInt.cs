using System;
using System.Collections.Generic;
using System.Text;

/*
 * 把字符串转换成整数

题目描述

将一个字符串转换成一个整数，要求不能使用字符串转换整数的库函数。 
数值为0或者字符串不是一个合法的数值则返回0

输入描述:
输入一个字符串,包括数字字母符号,可以为空

输出描述:
如果是合法的数值表达则返回该数字，否则返回0

示例1

输入
+2147483647
    1a33
输出
2147483647
    0
*/

namespace nowcoder {
    namespace StrToInt {
        class Solution {
            const int InvalidInput = 0;
            public int StrToInt(string str) {
                const int scale = 10;
                long val = 0;
                int sign = 1;
                str = str.Trim();
                if (str.Length == 0) {
                    return InvalidInput;
                }

                var firstCh = str[0];
                if(firstCh == '+') {
                    sign = 1;
                    str = str.Substring(1);
                }

                if(firstCh == '-') {
                    sign = -1;
                    str = str.Substring(1);
                }

                if (str.Length == 0) {
                    return InvalidInput;
                }

                for (int i = 0; i < str.Length; ++i) {
                    var ch = str[i];
                    if(ch < '0' || ch > '9') {
                        return InvalidInput;
                    }

                    val = val * scale + (ch - '0');
                }

                val = val * sign;

                if(val > int.MaxValue || val < int.MinValue) {
                    return InvalidInput;
                }

                return (int)val;
            }

            public static void Test() {
                //TestCase("+2147483647");
                //TestCase("-2147483648");
                //TestCase("    1a33");
                //TestCase("123");
                TestCase("+");

                System.Console.ReadKey();
            }


            static void TestCase(string input) {
                var start = System.DateTime.Now;
                var obj = new Solution();
                var result = obj.StrToInt(input);
                var elapse = (System.DateTime.Now - start).TotalMilliseconds;
                System.Console.WriteLine($"{result} -- with {elapse}ms");
            }
        }
    }
}
