using System;
using System.Collections.Generic;
using System.Text;

/*
 * 翻转单词顺序列

题目描述

牛客最近来了一个新员工Fish，每天早晨总是会拿着一本英文杂志，写些句子在本子上。
同事Cat对Fish写的内容颇感兴趣，有一天他向Fish借来翻看，但却读不懂它的意思。
例如，“student.a am I”。后来才意识到，这家伙原来把句子单词的顺序翻转了，
正确的句子应该是“I am a student.”。
Cat对一一的翻转这些单词顺序可不在行，你能帮助他么？
*/

namespace nowcoder {
    namespace ReverseSentence {
        class Solution {
            public string ReverseSentence(string str) {
                if (str == null)
                    return str;
                var arr = str.Split(' ');
                System.Array.Reverse(arr);
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                var lastIndex = arr.Length - 1;
                for(var i = 0; i < arr.Length; ++i) {
                    sb.Append(arr[i]);
                    if (i != lastIndex) {
                        sb.Append(" ");
                    }
                }

                return sb.ToString();
            }

            public static void Test() {
                TestCase("student. a am I");

                System.Console.ReadKey();
            }


            static void TestCase(string input) {
                var start = System.DateTime.Now;
                var obj = new Solution();
                var result = obj.ReverseSentence(input);
                var elapse = (System.DateTime.Now - start).TotalMilliseconds;
                System.Console.WriteLine($"{result} -- with {elapse}ms");
            }
        }
    }
}
