using System;
using System.Collections.Generic;
using System.Text;

/*
 * 按之字形顺序打印二叉树

题目描述

请实现一个函数按照之字形打印二叉树，即第一行按照从左到右的顺序打印，
第二层按照从右至左的顺序打印，第三行按照从左到右的顺序打印，其他行以此类推。
*/

namespace nowcoder {
    namespace PrintZ {
        class Solution {
            public List<List<int>> Print(TreeNode pRoot) {
                List<List<int>> result = new List<List<int>>();
                Walk(pRoot, 0, (node, layer) => {
                    if (layer == result.Count) {
                        result.Add(new List<int>());
                    }
                    result[layer].Add(node.val);
                });
                for(var i = 0; i < result.Count; ++i) {
                    if ((i & 1) == 1) {
                        result[i].Reverse();
                    }
                }
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
