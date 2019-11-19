using System;
using System.Collections.Generic;
using System.Text;

/*
 * 从上往下打印二叉树

题目描述

从上往下打印出二叉树的每个节点，同层节点从左至右打印。
*/

namespace nowcoder {
    namespace PrintFromTopToBottom {
        class Solution {
            public List<int> PrintFromTopToBottom(TreeNode root) {
                if (root == null) {
                    return new List<int>();
                }
                List<TreeNode> nodes = new List<TreeNode>();
                nodes.Add(root);
                var addIndex = 0;
                while(addIndex < nodes.Count) {
                    var curNode = nodes[addIndex];
                    if (curNode.left != null) {
                        nodes.Add(curNode.left);
                    }
                    if (curNode.right != null) {
                        nodes.Add(curNode.right);
                    }
                    addIndex++;
                }
                var result = nodes.ConvertAll(n => n.val);
                return result;
            }

            public static void Test() {
                var tree1 = Utility.GenTree(new long[] { 10, 6, 14, 4, 8, 12, 16 });
                TestCase(tree1);
            }

            static void TestCase(TreeNode root) {
                var obj = new Solution();
                var lst = obj.PrintFromTopToBottom(root);
                Console.WriteLine($"{lst.Count}");
            }
        }
    }
}
