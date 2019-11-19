using System;
using System.Collections.Generic;
using System.Text;

/*
 * 两个链表的第一个公共结点

题目描述

输入两个链表，找出它们的第一个公共结点。
*/

namespace nowcoder {
    namespace FindFirstCommonNode {
        class Solution {
            public ListNode FindFirstCommonNode(ListNode pHead1, ListNode pHead2) {
                if (pHead1 == null || pHead2 == null) {
                    return null;
                }

                var arr1 = ToArray(pHead1);
                var arr2 = ToArray(pHead2);
                var len1 = arr1.Length;
                var len2 = arr2.Length;
                var shortLen = System.Math.Min(arr1.Length, arr2.Length);
                for (var i = 1; i <= shortLen; ++i) {
                    if (arr1[len1 - i] != arr2[len2 - i]) {
                        return arr1[len1 - i].next;
                    }
                }

                return len1 < len2 ? pHead1 : pHead2;
            }

            ListNode[] ToArray(ListNode head) {
                var len = Length(head);
                var arr = new ListNode[len];
                var i = 0;
                while (head != null) {
                    arr[i] = head;
                    i++;
                    head = head.next;
                }

                return arr;
            }

            int Length(ListNode head) {
                int len = 0;
                while (head != null) {
                    len++;
                    head = head.next;
                }

                return len;
            }
        }
    }
}
