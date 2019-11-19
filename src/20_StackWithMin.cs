using System;
using System.Text;

/*
 * 包含min函数的栈

题目描述

定义栈的数据结构，请在该类型中实现一个
能够得到栈中所含最小元素的min函数（时间复杂度应为O（1））。
*/

namespace nowcoder {
    namespace StackWithMin {
        class Solution {
            System.Collections.Generic.List<int> lst = new System.Collections.Generic.List<int>();
            public void push(int node) {
                lst.Add(node);
            }
            public void pop() {
                lst.RemoveAt(lst.Count - 1);
            }
            public int top() {
                return lst[lst.Count - 1];
            }
            public int min() {
                int val = int.MaxValue;
                foreach (var v in lst) {
                    if (v < val) {
                        val = v;
                    }
                }

                return val;
            }
        }
    }
}
