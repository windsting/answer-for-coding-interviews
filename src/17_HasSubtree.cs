
/*
 * 树的子结构

题目描述

输入两棵二叉树A，B，判断B是不是A的子结构。（ps：我们约定空树不是任意一个树的子结构）
*/

namespace nowcoder {
    namespace HasSubtree {
        class Solution {
            public bool HasSubtree(TreeNode pRoot1, TreeNode pRoot2) {
                if (pRoot2 == null || pRoot1 == null) {
                    return false;
                }

                if (pRoot1.val == pRoot2.val) {
                    if (pRoot2.left == null && pRoot2.right == null) {
                        return true;
                    }

                    System.Func<bool> hasRight = () => {
                        return HasSubtree(pRoot1.left, pRoot2.right) || HasSubtree(pRoot1.right, pRoot2.right);
                    };

                    if (pRoot2.left == null) {
                        return hasRight();
                    }

                    System.Func<bool> hasLeft = () => {
                        return HasSubtree(pRoot1.left, pRoot2.left) || HasSubtree(pRoot1.right, pRoot2.left);
                    };

                    if (pRoot2.right == null) {
                        return hasLeft();
                    }

                    return hasLeft() && hasRight();
                }

                return HasSubtree(pRoot1.left, pRoot2) || HasSubtree(pRoot1.right, pRoot2);
            }

            static void PrintNode(TreeNode node) {
                System.Console.WriteLine("{0}", node == null ? "#" : node.val.ToString());
            }

            public static void Test() {
                var _ = TreeNode.EmptyNodeValue;
                TestCase(new long[] { 8, 8, 7, 9, 2, _, _, _, _, 4, 7 }, new long[] { 8, 9, 2 });
                TestCase(new long[] { 8, 8, 7, 9, 3, _, _, _, _, 4, 7 }, new long[] { 8, 9, 2 });
            }

            static void TestCase(long[] a, long[] b) {
                var obj = new Solution();
                var tree1 = Utility.GenTree(a);
                var tree2 = Utility.GenTree(b);
                var has = obj.HasSubtree(tree1, tree2);
                System.Console.WriteLine($"done: {has}");
            }
        }
    }
}
