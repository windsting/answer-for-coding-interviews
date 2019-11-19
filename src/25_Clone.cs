using System;
using System.Collections.Generic;
using System.Text;

/*
 * 复杂链表的复制

题目描述

输入一个复杂链表（每个节点中有节点值，以及两个指针，
一个指向下一个节点，另一个特殊指针指向任意一个节点），
返回结果为复制后复杂链表的head。
（注意，输出结果中请不要返回参数中的节点引用，否则判题程序会直接返回空）
*/

namespace nowcoder {
    namespace Clone {
        public class RandomListNode {
            public int label;
            public RandomListNode next, random;
            public RandomListNode(int x) {
                this.label = x;
            }
        }

        class Solution {
            public RandomListNode Clone(RandomListNode pHead) {
                RandomListNode newHead = null;
                if (pHead == null) {
                    return newHead;
                }
                var orgIndex = pHead;
                var lastNode = newHead;
                while (orgIndex != null) {
                    var node = new RandomListNode(orgIndex.label);
                    if (lastNode == null) {
                        lastNode = node;
                        newHead = lastNode;
                    } else {
                        lastNode.next = node;
                        lastNode = node;
                    }

                    orgIndex = orgIndex.next;
                }

                orgIndex = pHead;
                var newIndex = newHead;
                while (orgIndex != null) {
                    if (orgIndex.random != null) {
                        newIndex.random = FindNode(newHead, orgIndex.random.label);
                    }

                    orgIndex = orgIndex.next;
                    newIndex = newIndex.next;
                }
                return newHead;
            }

            RandomListNode FindNode(RandomListNode head, int label) {
                var cursor = head;
                while (cursor != null) {
                    if (cursor.label == label) {
                        return cursor;
                    }
                    cursor = cursor.next;
                }

                return null;
            }
        }
    }
}
