using System;
using System.Collections.Generic;
using System.Text;

/*
 * 链表中环的入口结点

题目描述

给一个链表，若其中包含环，请找出该链表的环的入口结点，否则，输出null。
*/

namespace nowcoder {
    namespace EntryNodeOfLoop {
        class Solution {
            public ListNode EntryNodeOfLoop(ListNode pHead) {
                var list = new System.Collections.Generic.List<ListNode>();
                ListNode result = null;
                var node = pHead;
                while (node.next != null) {
                    var next = node.next;
                    if (list.Contains(next)) {
                        result = next;
                        break;
                    }
                    list.Add(node);
                    node = node.next;
                }

                return result;
            }
        }
    }
}
