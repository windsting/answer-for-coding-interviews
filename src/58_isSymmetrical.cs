using System;
using System.Collections.Generic;
using System.Text;

/*
 * 对称的二叉树

题目描述

请实现一个函数，用来判断一颗二叉树是不是对称的。
注意，如果一个二叉树同此二叉树的镜像是同样的，定义其为对称的。
*/

namespace nowcoder {
    namespace isSymmetrical {
        class Solution {
            public bool isSymmetrical(TreeNode pRoot) {
                if (pRoot == null) {
                    return true;
                }
                return isMirror(pRoot.left, pRoot.right);
            }

            bool isMirror(TreeNode left, TreeNode right) {
                if (left == null && right == null) {
                    return true;
                }

                if (left == null || right == null) {
                    return false;
                }

                if (left.val != right.val) {
                    return false;
                }

                return isMirror(left.left, right.right) && isMirror(left.right, right.left);
            }
        }
    }
}
