using System;
using System.Collections.Generic;
using System.Text;

/*
 * 反转链表

题目描述

输入一个链表，反转链表后，输出新链表的表头。
*/

namespace nowcoder {
    namespace ReverseList {
        class Solution {
            public ListNode ReverseList(ListNode pHead) {
                if (pHead == null) {
                    return pHead;
                }
                var newHead = Reverse(pHead.next, pHead);
                pHead.next = null;
                return newHead;
            }

            public ListNode Reverse(ListNode curNode, ListNode lastNode) {
                if (curNode == null) {
                    return lastNode;
                }
                var next = curNode.next;
                curNode.next = lastNode;
                return Reverse(next, curNode);
            }

            public static void Test() {
                var obj = new Solution();
                var list = ListNode.Gen(new int[] { 1, 2, 3, 4, 5 });
                var newHead = obj.ReverseList(list);
                Console.WriteLine("donw");
            }
        }
    }
}
