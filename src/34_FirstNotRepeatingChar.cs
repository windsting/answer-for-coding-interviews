using System;
using System.Collections.Generic;
using System.Text;

/*
 * 第一个只出现一次的字符

题目描述

在一个字符串(0<=字符串长度<=10000，全部由字母组成)中找到第一个只出现一次的字符,
并返回它的位置, 如果没有则返回 -1（需要区分大小写）.
*/

namespace nowcoder {
    namespace FirstNotRepeatingChar {
        class Solution {
            public int FirstNotRepeatingChar(string str) {
                System.Collections.Generic.Dictionary<char, System.Collections.Generic.List<int>> chars = 
                    new System.Collections.Generic.Dictionary<char, System.Collections.Generic.List<int>>();

                for(var i = 0;i<str.Length;++i) {
                    var ch = str[i];
                    System.Collections.Generic.List<int> lst = null;
                    chars.TryGetValue(ch, out lst);
                    if (lst == null) {
                        lst = new System.Collections.Generic.List<int>();
                        chars.Add(ch, lst);
                    }
                    lst.Add(i);
                }

                int pos = int.MaxValue;
                foreach(var pair in chars) {
                    var k = pair.Key;
                    var l = pair.Value;
                    if(l.Count==1 && l[0] < pos) {
                        pos = l[0];
                    }
                }

                if (pos == int.MaxValue) {
                    return -1;
                }

                return pos;
            }
        }
    }
}
