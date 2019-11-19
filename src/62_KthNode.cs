using System;
using System.Collections.Generic;
using System.Text;

/*
 * 二叉搜索树的第k个结点

题目描述

给定一棵二叉搜索树，请找出其中的第k小的结点。
例如， （5，3，7，2，4，6，8）中，
按结点数值大小顺序第三小结点的值为4。
*/

namespace nowcoder {
    namespace KthNode {
        class Solution {
            public TreeNode KthNode(TreeNode pRoot, int k) {
                var list = new System.Collections.Generic.List<TreeNode>();
                Walk(pRoot, (node) => list.Add(node));
                var index = k - 1;
                if (index >= 0 && index < list.Count) {
                    return list[index];
                }

                return null;
            }

            void Walk(TreeNode node, System.Action<TreeNode> func) {
                if (node == null)
                    return;

                Walk(node.left, func);
                func(node);
                Walk(node.right, func);
            }
        }
    }
}
