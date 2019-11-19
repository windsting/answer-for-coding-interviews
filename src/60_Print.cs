using System;
using System.Collections.Generic;
using System.Text;

/*
 * 把二叉树打印成多行

题目描述

从上到下按层打印二叉树，同一层结点从左至右输出。每一层输出一行。
*/

namespace nowcoder {
    namespace Print {
        class Solution {
            public List<List<int>> Print(TreeNode pRoot) {
                List<List<int>> result = new List<List<int>>();
                Walk(pRoot, 0, (node, layer) => {
                    if (layer == result.Count) {
                        result.Add(new List<int>());
                    }
                    result[layer].Add(node.val);
                });
                return result;
            }

            void Walk(TreeNode node, int layer, System.Action<TreeNode, int> func) {
                if (node == null) {
                    return;
                }

                func(node, layer);
                Walk(node.left, layer + 1, func);
                Walk(node.right, layer + 1, func);
            }
        }
    }
}
