using System;
using System.Collections.Generic;
using System.Text;

/*
 * 二叉树中和为某一值的路径

题目描述

输入一颗二叉树的根节点和一个整数，打印出二叉树中结点值的和为输入整数的所有路径。
路径定义为从树的根结点开始往下一直到叶结点所经过的结点形成一条路径。
(注意: 在返回值的list中，数组长度大的数组靠前)
*/

namespace nowcoder {
    namespace FindPath {
        class Solution {
            public List<List<int>> FindPath(TreeNode root, int expectNumber) {
                List<TreeNode> path = new List<TreeNode>();
                List<List<int>> result = new List<List<int>>();
                if (root == null) {
                    return result;
                }
                walk(root, path, result, expectNumber);
                result.Sort((a, b) => b.Count - a.Count);

                return result;
            }

            void walk(TreeNode curRoot, List<TreeNode> path, List<List<int>> result, int expectNumber) {
                System.Func<int> sum = () => {
                    int s = 0;
                    foreach (var n in path) {
                        s += n.val;
                    }
                    return s;
                };

                System.Func<bool> isLeaf = () => {
                    return curRoot.left == null && curRoot.right == null;
                };

                path.Add(curRoot);

                if (isLeaf() && sum() == expectNumber) {
                    var curList = path.ConvertAll(n => n.val);
                    result.Add(curList);
                }
                if (curRoot.left != null) {
                    walk(curRoot.left, path, result, expectNumber);
                }
                if (curRoot.right != null) {
                    walk(curRoot.right, path, result, expectNumber);
                }

                path.Remove(curRoot);
            }

            public static void Test() {
                TestCase(Utility.GenTree(new long[] { 10, 5, 12, 4, 7 }), 22);
                TestCase(Utility.GenTree(new long[] { 10, 5, 12, 4, 7 }), 15);
            }

            static void TestCase(TreeNode input, int val) {
                var obj = new Solution();
                var result = obj.FindPath(input, val);
                Console.WriteLine($"{result}");
            }
        }
    }
}
