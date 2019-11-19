using System;
using System.Text;

/*
 * 二叉搜索树与双向链表

题目描述

输入一棵二叉搜索树，将该二叉搜索树转换成一个排序的双向链表。
要求不能创建任何新的结点，只能调整树中结点指针的指向。
*/

namespace nowcoder {
    namespace Convert {
        class Solution {
            public TreeNode Convert(TreeNode pRootOfTree) {
                System.Collections.Generic.List<TreeNode> list = new System.Collections.Generic.List<TreeNode>();
                if (pRootOfTree == null) {
                    return null;
                }
                MidTree(pRootOfTree, n => list.Add(n));
                for(var i = 0; i < list.Count; ++i) {
                    var curNode = list[i];
                    curNode.left = i - 1 >= 0 ? list[i - 1] : null;
                    curNode.right = i + 1 < list.Count ? list[i + 1] : null;
                }

                return list[0];
            }

            public static void MidTree(TreeNode root, System.Action<TreeNode> func) {
                if (root == null) {
                    return;
                }
                MidTree(root.left, func);
                func(root);
                MidTree(root.right, func);
            }
        }
    }
}
