using System.Collections.Generic;
using System.Text;

/*
 * 合并两个排序的链表

题目描述

输入两个单调递增的链表，输出两个链表合成后的链表，
当然我们需要合成后的链表满足单调不减规则。
*/

namespace nowcoder {
    namespace Merge {
        class Solution {
            public ListNode Merge(ListNode pHead1, ListNode pHead2) {
                if (pHead1 == null) {
                    return pHead2;
                }

                if (pHead2 == null) {
                    return pHead1;
                }

                ListNode newHead = null;
                var iter = newHead;
                System.Action<ListNode> append = (node) => {
                    if (iter == null) {
                        iter = node;
                        newHead = node;
                    } else {
                        iter.next = node;
                        iter = iter.next;
                    }
                };
                while (pHead1 != null && pHead2 != null) {
                    if (pHead1.val < pHead2.val) {
                        append(pHead1);
                        pHead1 = pHead1.next;
                    } else {
                        append(pHead2);
                        pHead2 = pHead2.next;
                    }
                }

                if (pHead1 != null) {
                    iter.next = pHead1;
                }

                if (pHead2 != null) {
                    iter.next = pHead2;
                }

                return newHead;
            }

            public static void Test() {
                var obj = new Solution();
                var list1 = ListNode.Gen(new int[] { 1, 3, 5 });
                var list2 = ListNode.Gen(new int[] { 2, 4, 6 });
                var newHead = obj.Merge(list1, list2);
                System.Console.WriteLine("done");
            }
        }
    }
}
