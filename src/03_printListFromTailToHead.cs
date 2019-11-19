using System;
using System.Collections.Generic;
using System.Text;

/*
 * 从尾到头打印链表

题目描述

输入一个链表，按链表从尾到头的顺序返回一个ArrayList。
*/

namespace nowcoder {
    namespace printListFromTailToHead {
        class Solution {
            // 返回从尾到头的列表值序列
            public List<int> printListFromTailToHead(ListNode listNode) {
                var list = new List<int>();
                var node = listNode;
                while (node != null) {
                    list.Add(node.val);
                    node = node.next;
                }

                list.Reverse();
                return list;
            }
        }
    }
}
