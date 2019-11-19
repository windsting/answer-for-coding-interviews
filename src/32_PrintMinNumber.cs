//using System;
//using System.Collections.Generic;
//using System.Text;

/*
 * 把数组排成最小的数

题目描述

输入一个正整数数组，把数组里所有数字拼接起来排成一个数，打印能拼接出的所有数字中最小的一个。
例如输入数组{3，32，321}，则打印出这三个数字能排成的最小数字为321323。
*/

namespace nowcoder {
    namespace PrintMinNumber {
        class Solution {
            class NumInfo {
                public int Num { get; private set; }
                public int[] Digits { get; private set; }
                public int MaxDigit { get; private set; }
                public int MinDigit { get; private set; }
                public NumInfo(int n) {
                    Num = n;
                    Init();
                }

                void Init() {
                    System.Collections.Generic.List<int> digits = new System.Collections.Generic.List<int>();
                    var n = Num;
                    MaxDigit = 0;
                    MinDigit = 9;
                    while(n > 0) {
                        var digit = n % scale;
                        digits.Add(digit);
                        n = n / scale;
                        if(MaxDigit < digit) {
                            MaxDigit = digit;
                        }
                        if(MinDigit > digit) {
                            MinDigit = digit;
                        }
                    }

                    digits.Reverse();
                    Digits = digits.ToArray();
                }

                const int scale = 10;
                public override string ToString() {
                    return Num.ToString();
                }

                public static int Less(NumInfo a, NumInfo b) {
                    var i = 0;
                    var ad = a.Digits;
                    var bd = b.Digits;
                    var len = System.Math.Max(ad.Length, bd.Length);
                    while (i < len) {
                        var av = ad[i % ad.Length];
                        var bv = bd[i % bd.Length];
                        if (av != bv) {
                            return av - bv;
                        }
                        ++i;
                    }

                    return 0;
                }
            }
            public string PrintMinNumber(int[] numbers) {
                System.Collections.Generic.List<NumInfo> infos = new System.Collections.Generic.List<NumInfo>();
                foreach(var n in numbers) {
                    infos.Add(new NumInfo(n));
                }

                infos.Sort(NumInfo.Less);
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                foreach(var info in infos) {
                    sb.AppendFormat("{0}", info.Num);
                }

                return sb.ToString();
            }

            public static void Test() {
                //TestCase(new int[] { 3, 32, 321 });
                TestCase(new int[] { 3334, 3, 3333332 });
            }

            static void TestCase(int[] input) {
                var obj = new Solution();
                var result = obj.PrintMinNumber(input);
                System.Console.WriteLine($"{result}");
            }
        }
    }
}
