using System;
using System.Collections.Generic;
using System.Text;

/*
 * 链表中倒数第k个结点

题目描述

输入一个链表，输出该链表中倒数第k个结点。
*/

namespace nowcoder {
    namespace FindKthToTail {
        class Solution {
            public ListNode FindKthToTail(ListNode head, int k) {
                ListNode result = null;
                if (k <= 0) {
                    return result;
                }
                ListNode iter = head;
                int i = 0;
                while (iter != null) {
                    iter = iter.next;
                    i++;
                    if (i == k) {
                        result = head;
                    }
                    if (i > k) {
                        result = result.next;
                    }
                }
                return result;
            }



            public static void Test() {
                var obj = new Solution();
                var list = ListNode.Gen(new int[] { 1, 2, 3, 4, 5 });
                int[] array = new int[] { 0, 1, 2, 3, 4, 5, 6, 7 };
                var iter = list;
                while (iter != null) {
                    Console.Write($"{iter.val}, ");
                    iter = iter.next;
                }
                Console.Write($"\n");
                foreach (var i in array) {
                    Console.WriteLine($"{obj.FindKthToTail(list, i)} for {i}");
                }
            }
        }
    }
}
