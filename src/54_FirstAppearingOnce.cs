using System;
using System.Collections.Generic;
using System.Text;

/*
 * 字符流中第一个不重复的字符

题目描述

请实现一个函数用来找出字符流中第一个只出现一次的字符。
例如，当从字符流中只读出前两个字符"go"时，第一个只出现一次的字符是"g"。
当从该字符流中读出前六个字符“google"时，第一个只出现一次的字符是"l"。

输出描述:
如果当前字符流没有存在出现一次的字符，返回#字符。
*/

namespace nowcoder {
    namespace FirstAppearingOnce {
        class Solution {
            public char FirstAppearingOnce() {
                if (CurChar == NoResult) {
                    return ValueForNoResult;
                }

                return (char)CurChar;
            }

            public void Insert(char c) {
                var pos = CharPos[c];
                if (pos == NoWhere) {
                    pos = CharCounts.Count;
                    CharPos[c] = pos;
                    CharCounts.Add(Record.Create(c));
                } else {
                    CharCounts[pos].Add();
                }

                if (CurChar == NoResult || CurChar == c) {
                    UpdateCurChar();
                }
            }

            void UpdateCurChar() {
                CurChar = NoResult;
                foreach(var rec in CharCounts) {
                    if(rec.Count == 1) {
                        CurChar = rec.Ch;
                        break;
                    }
                }
            }

            // helper
            class Record {
                public char Ch { get; private set; }
                public int Count { get; private set; }
                public Record(char c) {
                    Ch = c;
                    Count = 1;
                }

                public int Add() {
                    Count++;
                    return Count;
                }

                public static Record Create(char c) {
                    return new Record(c);
                }

                public override string ToString() {
                    return $"[{Ch}] : {Count}";
                }
            }
            int[] CharPos = new int[char.MaxValue + 1];
            System.Collections.Generic.List<Record> CharCounts = new System.Collections.Generic.List<Record>();
            const int NoResult = -1;
            const int NoWhere = -1;
            const char ValueForNoResult = '#';
            int CurChar = NoResult;
            public Solution() {
                for (var i = 0; i < CharPos.Length; ++i) {
                    CharPos[i] = -1;
                }
            }

            // Test
            public static void Test() {
                TestCase("google");

                System.Console.ReadKey();
            }


            static void TestCase(string input) {
                var obj = new Solution();
                foreach(var c in input) {
                    obj.Insert(c);
                    var r = obj.FirstAppearingOnce();
                    System.Console.Write($"{r}");
                }
                System.Console.WriteLine("");
            }
        }
    }
}
