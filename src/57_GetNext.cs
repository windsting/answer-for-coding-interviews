using System;
using System.Collections.Generic;
using System.Text;

/*
 * 二叉树的下一个结点

题目描述

给定一个二叉树和其中的一个结点，请找出中序遍历顺序的下一个结点并且返回。
注意，树中的结点不仅包含左右子结点，同时包含指向父结点的指针。
*/

namespace nowcoder {
    namespace GetNext {
        public class TreeLinkNode {
            public int val;
            public TreeLinkNode left;
            public TreeLinkNode right;
            public TreeLinkNode next;
            public TreeLinkNode(int x) {
                val = x;
            }

            TreeLinkNode Insert(int value) {
                TreeLinkNode nextTry = null;
                if(value > val) {
                    if (right == null) {
                        right = new TreeLinkNode(value);
                        right.next = this;
                        return right;
                    } else {
                        nextTry = right;
                    }
                }

                if(value < val) {
                    if(left == null) {
                        left = new TreeLinkNode(value);
                        left.next = this;
                        return left;
                    } else {
                        nextTry = left;
                    }
                }

                return nextTry.Insert(value);
            }

            TreeLinkNode GetRoot(TreeLinkNode node) {
                if(node.next == null) {
                    return node;
                }

                return GetRoot(node.next);
            }

            public override string ToString() {
                var l = left == null ? "null" : $"{left.val}";
                var r = right == null ? "null" : $"{right.val}";
                var n = next == null ? "null" : $"{next.val}";
                
                return $"[{l}] <- [{val}({n})] -> [{r}]";
            }

            public static TreeLinkNode Create(int[] arr, int targetVal) {
                TreeLinkNode target = null;
                var head = new TreeLinkNode(arr[0]);
                if(head.val == targetVal) {
                    target = head;
                }
                for(var i = 1; i < arr.Length; ++i) {
                    var node = head.Insert(arr[i]);
                    if (node.val == targetVal) {
                        target = node;
                    }
                }

                return target;
            }
        }
        class Solution {
            public TreeLinkNode GetNext(TreeLinkNode pNode) {
                if (pNode == null) {
                    throw new System.ArgumentNullException(nameof(pNode));
                }

                TreeLinkNode result = null;
                var root = GetRoot(pNode);
                GetNext(root, (node) => {
                    if (node.val > pNode.val) {
                        if (result == null) {
                            result = node;
                        }
                        if(result != null && result.val > node.val) {
                            result = node;
                        }
                    }

                });

                return result;
            }

            void GetNext(TreeLinkNode node, System.Action<TreeLinkNode> func) {
                if (node == null)
                    return;
                GetNext(node.left, func);
                func(node);
                GetNext(node.right, func);
            }

            static TreeLinkNode GetRoot(TreeLinkNode node) {
                if (node.next == null) {
                    return node;
                }

                return GetRoot(node.next);
            }


            public static void Test() {
                TestCase(TreeLinkNode.Create(new int[] { 8, 6, 10, 5, 7, 9, 11 }, 8));
                //TestCase(TreeLinkNode.Create(new int[] { 8, 6, 10, 5, 7, 9, 11 }, 7));

                System.Console.ReadKey();
            }


            static void TestCase(TreeLinkNode input) {
                var start = System.DateTime.Now;
                var obj = new Solution();
                var result = obj.GetNext(input);
                var elapse = (System.DateTime.Now - start).TotalMilliseconds;
                System.Console.WriteLine($"{result} -- with {elapse}ms");
            }
        }
    }
}
