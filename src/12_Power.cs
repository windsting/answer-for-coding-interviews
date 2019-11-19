using System;
using System.Collections.Generic;
using System.Text;

/*
 * 数值的整数次方

题目描述

给定一个double类型的浮点数base和int类型的整数exponent。求base的exponent次方。

保证base和exponent不同时为0
*/


//=======================================================
// 不通过
// 您的代码已保存
// 答案错误:您提交的程序没有通过所有的测试用例
// case通过率为0.00%

// 用例:
// 2,3

// 对应输出应该为:

// 8.00000

// 你的输出为:

// 8
//=======================================================

namespace nowcoder {
    namespace Power {
        class Solution {
            public double Power(double thebase, int exponent) {
                if (thebase == 0 && exponent == 0) {
                    throw new System.ArgumentException("thebase and exponent are both 0");
                }
                if (exponent == 0)
                    return 1;
                if (thebase == 0)
                    return 0;

                bool negExp = false;
                if (exponent < 0) {
                    negExp = true;
                    exponent = -exponent;
                }

                double val = 1.0;
                while (exponent > 0) {
                    exponent -= 1;
                    val = val * thebase;
                }

                if (negExp) {
                    val = 1.0 / val;
                }

                return val;
            }

            public static void Test() {
                TestCase(2, 3);
                TestCase(2, -3);
                TestCase(3, -2);
            }

            static double TestCase(double thebase, int exponent) {
                var obj = new Solution();
                var result = obj.Power(thebase, exponent);
                System.Console.WriteLine($"result: {result}, for thebase: {thebase}, exponent: {exponent}");
                return result;
            }
        }
    }
}

/*
 * These code passed check with **JavaScript(Node 6.11.4)** option
 * 
function Power(base, exponent) {
    if (base === 0) {
        return 0;
    }

    if (exponent === 0) {
        return 1;
    }

    var neg = false;
    if (exponent < 0) {
        neg = true;
        exponent = -exponent;
    }

    var val = 1;
    while (exponent > 0) {
        exponent -= 1;
        val = val * base;
    }

    if (neg) {
        return 1 / val;
    }

    return val;
}
module.exports = {
    Power : Power
};
*/
