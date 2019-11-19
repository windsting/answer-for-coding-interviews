using System;
using System.Collections.Generic;
using System.Text;

/*
 * 二叉树的深度

题目描述

输入一棵二叉树，求该树的深度。

从根结点到叶结点依次经过的结点（含根、叶结点）形成树的一条路径，
最长路径的长度为树的深度。
*/

namespace nowcoder {
    namespace TreeDepth {
        class Solution {
            public int TreeDepth(TreeNode pRoot) {
                MaxDepth = 0;
                WalkDepth = 0;
                WalkTree(pRoot);

                return MaxDepth;
            }

            int MaxDepth = int.MinValue;
            int WalkDepth = 0;
            void WalkTree(TreeNode root) {
                if (root == null) {
                    return;
                }

                WalkDepth += 1;
                if (WalkDepth > MaxDepth) {
                    MaxDepth = WalkDepth;
                }

                WalkTree(root.left);
                WalkTree(root.right);

                WalkDepth -= 1;
            }
        }
    }
}
