﻿using System;
using System.Collections.Generic;
using System.Text;

/*
 * 左旋转字符串

题目描述

汇编语言中有一种移位指令叫做循环左移（ROL），现在有个简单的任务，
就是用字符串模拟这个指令的运算结果。对于一个给定的字符序列S，
请你把其循环左移K位后的序列输出。

例如，字符序列
    S=”abcXYZdef”
,要求输出循环左移3位后的结果，即
    “XYZdefabc”。
是不是很简单？OK，搞定它！
*/

namespace nowcoder {
    namespace LeftRotateString {
        class Solution {
            public string LeftRotateString(string str, int n) {
                if (str.Length == 0 || str.Length == 1)
                    return str;
                var step = n % str.Length;
                var result = str.Substring(step);
                result = result + str.Substring(0, step);
                return result;
            }

            public static void Test() {
                TestCase("abcXYZdef", 12);

                System.Console.ReadKey();
            }


            static void TestCase(string input, int n) {
                var start = System.DateTime.Now;
                var obj = new Solution();
                var result = obj.LeftRotateString(input, n);
                var elapse = (System.DateTime.Now - start).TotalMilliseconds;
                System.Console.WriteLine($"{result} -- with {elapse}ms");
            }
        }
    }
}
