using System;
using System.Collections.Generic;
using System.Text;

/*
 * 替换空格

题目描述

请实现一个函数，将一个字符串中的每个空格替换成“%20”。
例如，当字符串为We Are Happy.则经过替换之后的字符串为We%20Are%20Happy。
*/

namespace nowcoder {
    namespace replaceSpace {
        class Solution {
            public string replaceSpace(string str) {
                var b = new System.Text.StringBuilder();
                foreach (var c in str) {
                    if (c == ' ') {
                        b.Append("%20");
                    } else {
                        b.Append(c);
                    }
                }
                return b.ToString();
            }
        }
    }
}
