using System;
using System.Collections.Generic;
using System.Text;

/*
 * 平衡二叉树

题目描述

输入一棵二叉树，判断该二叉树是否是平衡二叉树。
*/

namespace nowcoder {
    namespace IsBalanced_Solution {
        class Solution {
            const int BalanceDiffMax = 1;
            const int BalanceDiffMin = -1;
            public bool IsBalanced_Solution(TreeNode pRoot) {
                if (pRoot == null)
                    return true;

                var depthLeft = TreeDepth.Get(pRoot.left);
                var depthRight = TreeDepth.Get(pRoot.right);
                var diff = depthLeft - depthRight;
                if(diff> BalanceDiffMax || diff < BalanceDiffMin) {
                    return false;
                }

                return IsBalanced_Solution(pRoot.left) && IsBalanced_Solution(pRoot.right);
            }

            class TreeDepth {
                static TreeDepth Instance;
                public static int Get(TreeNode root) {
                    if (Instance == null) {
                        Instance = new TreeDepth();
                    }

                    return Instance.GetDepth(root);
                }
                public int GetDepth(TreeNode pRoot) {
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
}
