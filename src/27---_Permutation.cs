using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * 字符串的排列

题目描述

输入一个字符串, 按字典序打印出该字符串中字符的所有排列。
例如输入字符串abc,则打印出由字符a,b,c所能排列出来的所有字符串abc,acb,bac,bca,cab和cba。

输入描述:
输入一个字符串,长度不超过9(可能有字符重复),字符只包括大小写字母。
*/

namespace nowcoder {
    namespace Permutation {
        class Solution {
            public System.Collections.Generic.List<string> Permutation(string str) {
                System.Collections.Generic.SortedSet<string> lst = new System.Collections.Generic.SortedSet<string>();
                if (str.Length == 0) {
                    return lst.ToList();
                }
                if (str.Length == 1) {
                    lst.Add(str);
                    return lst.ToList();
                }
                System.Collections.Generic.List<int> pivotes = new System.Collections.Generic.List<int>();
                for (var i = 0; i < str.Length; ++i) {
                    Permutation(str, i, "", pivotes, lst);
                }
                return lst.ToList();
            }

            void Permutation(string str, int pivot, string path
                , System.Collections.Generic.List<int> pivotes
                , System.Collections.Generic.SortedSet<string> lst) {
                var pChar = str[pivot];
                if (path.Length + 1 == str.Length) {
                    lst.Add(path+pChar);
                    return;
                }
                pivotes.Add(pivot);
                for(int i = 0; i < str.Length; ++i) {
                    if (pivotes.Contains(i)) {
                        continue;
                    }
                    Permutation(str, i, path + pChar, pivotes, lst);
                }
                pivotes.RemoveAt(pivotes.Count - 1);
            }

            public static void Test() {
                //TestCase("ab");
                //TestCase("a");
                TestCase("abc");
            }

            static void TestCase(string input) {
                var obj = new Solution();
                var result = obj.Permutation(input);
                Console.WriteLine($"{result}");
            }
        }
    }
}
