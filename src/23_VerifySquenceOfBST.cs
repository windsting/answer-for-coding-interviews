using System;
using System.Collections.Generic;
using System.Text;

/*
 * 二叉搜索树的后序遍历序列

题目描述

输入一个整数数组，判断该数组是不是某二叉搜索树的后序遍历的结果。
如果是则输出Yes,否则输出No。假设输入的数组的任意两个数字都互不相同。
*/

namespace nowcoder {
    namespace VerifySquenceOfBST {
        class Solution {
            public bool VerifySquenceOfBST(int[] sequence) {
                if(sequence.Length == 0) {
                    return false;
                }
                if (sequence.Length < 2) {
                    return true;
                }
                System.Array.Reverse(sequence);
                var portentialTree = buildTree(sequence, 0, sequence.Length);
                if (portentialTree != null) {
                    return true;
                }

                return false;
            }

            TreeNode buildTree(int[] sequence, int begin, int end) {
                var curValue = sequence[begin];
                TreeNode node = new TreeNode(curValue);
                if (begin + 1 == end) {
                    return node;
                }
                var isFirstArray = isFirstFunc(sequence[begin], sequence[begin + 1]);
                var firstArrayEnd = begin + 1;
                while (firstArrayEnd < end && isFirstArray(curValue, sequence[firstArrayEnd])) {
                    firstArrayEnd++;
                }

                if (firstArrayEnd > begin + 1) {
                    node.right = buildTree(sequence, begin + 1, firstArrayEnd);
                    if (node.right == null) {
                        return null;
                    }
                }

                if (firstArrayEnd + 1 >= end) {
                    return node;
                }

                var secondArrayEnd = firstArrayEnd;
                while (secondArrayEnd < end && isFirstArray(curValue, sequence[secondArrayEnd]) == false) {
                    secondArrayEnd++;
                }

                if (secondArrayEnd != end) {
                    return null;
                }

                node.left = buildTree(sequence, firstArrayEnd, end);
                if (node.left == null) {
                    return null;
                }

                return node;
            }

            System.Func<int, int, bool> isFirstFunc(int root, int right) {
                if (root < right) {
                    return (a, b) => a < b;
                }
                return (a, b) => a > b;
            }

            public static void Test() {
                TestCase(new int[] { 4, 8, 6, 12, 16, 14, 10 });
                TestCase(new int[] { 7, 4, 6, 5 });
            }

            static void TestCase(int[] input) {
                var obj = new Solution();
                var result = obj.VerifySquenceOfBST(input);
                Console.WriteLine($"{result}");
            }
        }
    }
}
