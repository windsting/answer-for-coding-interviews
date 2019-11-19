using System;
using System.Collections.Generic;
using System.Text;

/*
 * 表示数值的字符串

题目描述

请实现一个函数用来判断字符串是否表示数值（包括整数和小数）。
例如，字符串"+100","5e2","-123","3.1416"和"-1E-16"都表示数值。 
但是"12e","1a3.14","1.2.3","+-5"和"12e+4.3"都不是。
*/

namespace nowcoder {
    namespace isNumeric {
        class Solution {
            public bool isNumeric(char[] str) {
                var sStr = new string(str);
                return isInteger(sStr) || isFloat(sStr) || isScientificNote(sStr);
            }

            bool isDigits(string str) {
                foreach (var c in str) {
                    if (c < '0' || c > '9') {
                        return false;
                    }
                }

                return true;
            }

            bool isInteger(string str) {
                if (str.Length == 0) {
                    return false;
                }

                const int NoSign = 0;
                int sign = NoSign;
                var strWithoutSign = str;
                if (str[0] == '-') {
                    sign = -1;
                    strWithoutSign = str.Substring(1);
                }
                if (str[0] == '+') {
                    sign = 1;
                    strWithoutSign = str.Substring(1);
                }

                if (sign != NoSign && strWithoutSign.Length == 0) {
                    return false;
                }

                if (isDigits(strWithoutSign) == false)
                    return false;

                return true;
            }

            bool isFloat(string str) {
                var parts = str.Split('.');
                if (parts.Length != 2) {
                    return false;
                }

                var left = parts[0];
                var right = parts[1];
                if (right.Length == 0 || isDigits(right) == false) {
                    return false;
                }

                if (left.Length == 0 || isInteger(left) || left == "-" || left == "+") {
                    return true;
                }

                return false;
            }

            bool isScientificNote(string str) {
                var strLow = str.ToLower();
                var parts = strLow.Split('e');
                if (parts.Length != 2) {
                    return false;
                }

                var left = parts[0];
                var right = parts[1];
                if ((isFloat(left) || isInteger(left)) && isInteger(right))
                    return true;

                return false;
            }


            // Test
            class Case {
                public string Str { get; set; }
                public bool Result { get; set; }

                public Case(string s, bool r) {
                    Str = s;
                    Result = r;
                }

                public static bool ArrayEqual(char[] a, char[] b) {
                    if (a.Length != b.Length)
                        return false;
                    for (var i = 0; i < a.Length; ++i) {
                        if (a[i] != b[i])
                            return false;
                    }

                    return true;
                }

                public bool IsSame(char[] str) {
                    var strMy = Str.ToCharArray();
                    if (ArrayEqual(str, strMy) == false)
                        return false;
                    return true;
                }

                public static Case Create(string s, bool r) {
                    return new Case(s, r);
                }
            }
            static Case[] Cases = new Case[] {
                Case.Create("-.123", true),
                Case.Create("3.1416", true),
            };

            public static void Test() {
                foreach (var c in Cases) {
                    TestCase(c.Str, c.Result);
                }
                System.Console.ReadKey();
            }

            static void TestCase(string str, bool expected) {
                var obj = new Solution();
                var result = obj.isNumeric(str.ToCharArray());
                var mark = result == expected ? " " : "x";
                System.Console.WriteLine($"[{mark}] str:[{str}] is numeric are {result}, should be: [{expected}]");
            }

        }
    }
}
