
/*
 * 重建二叉树

题目描述

输入某二叉树的前序遍历和中序遍历的结果，请重建出该二叉树。
假设输入的前序遍历和中序遍历的结果中都不含重复的数字。
例如输入前序遍历序列
{1,2,4,7,3,5,6,8}
和中序遍历序列
{4,7,2,1,5,3,8,6}
，则重建二叉树并返回。
*/

namespace nowcoder {
    namespace reConstructBinaryTree {
        class Solution {
            public TreeNode reConstructBinaryTree(int[] pre, int[] tin) {
                if (pre.Length == 0) {
                    return null;
                }
                var rootVal = pre[0];
                var index = System.Array.IndexOf(tin, rootVal);
                if (index < 0) {
                    throw new System.ArgumentException($"root value:{rootVal} not found in {nameof(tin)}");
                }

                var tinLeft = Left(tin, index);
                var tinRight = Right(tin, index);

                var leftLen = tinLeft.Length;
                var preLeft = PreLeft(pre, leftLen);
                var preRight = PreRight(pre, leftLen);

                TreeNode root = new TreeNode(rootVal);
                root.left = reConstructBinaryTree(preLeft, tinLeft);
                root.right = reConstructBinaryTree(preRight, tinRight);

                return root;
            }

            public static int[] SubArray(int[] array, int index, int length) {
                int[] sub = new int[length];
                System.Array.Copy(array, index, sub, 0, length);
                return sub;
            }

            public static int[] Left(int[] array, int index) {
                return SubArray(array, 0, index);
            }

            public static int[] Right(int[] array, int index) {
                return SubArray(array, index + 1, array.Length - index - 1);
            }

            public static int[] PreLeft(int[] array, int leftLen) {
                return SubArray(array, 1, leftLen);
            }

            public static int[] PreRight(int[] array, int leftLen) {
                return SubArray(array, 1 + leftLen, array.Length - leftLen - 1);
            }


            // Test
            static void testSubArray() {
                var array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                var index = 4;
                var left = Left(array, index);
                var right = Right(array, index);
                System.Console.WriteLine("done");
            }

            static void testPreSplit() {
                var pre = new int[] { 1, 2, 4, 7, 3, 5, 6, 8 };
                var tin = new int[] { 4, 7, 2, 1, 5, 3, 8, 6 };
                int leftLen = 3;
                var left = PreLeft(pre, leftLen);
                var right = PreRight(pre, leftLen);
                System.Console.WriteLine("done");
            }
        }
    }
}
