using System;
using System.Collections.Generic;
using System.Text;

/*
 * 删除链表中重复的结点

题目描述

在一个排序的链表中，存在重复的结点，请删除该链表中重复的结点，重复的结点不保留，返回链表头指针。 
例如，链表1->2->3->3->4->4->5 处理后为 1->2->5
 */

namespace nowcoder {
    namespace deleteDuplication {
        class Solution {
            public ListNode deleteDuplication(ListNode pHead) {
                if (pHead == null) {
                    return pHead;
                }

                var values = new System.Collections.Generic.HashSet<int>();
                var dupValues = new System.Collections.Generic.HashSet<int>();
                var node = pHead;
                values.Add(node.val);
                while (node.next != null) {
                    if (values.Contains(node.next.val)) {
                        dupValues.Add(node.next.val);
                    }

                    values.Add(node.next.val);

                    node = node.next;
                }

                var temp = new ListNode(1);
                temp.next = pHead;
                node = temp;
                while (node.next != null) {
                    if (dupValues.Contains(node.next.val)) {
                        node.next = node.next.next;
                    } else {
                        node = node.next;
                    }
                }

                return temp.next;
            }
        }
    }
}
