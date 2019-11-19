//using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

/*
 * 序列化二叉树

题目描述

请实现两个函数，分别用来序列化和反序列化二叉树

二叉树的序列化是指：把一棵二叉树按照某种遍历方式的结果以某种格式保存为字符串，
从而使得内存中建立起来的二叉树可以持久保存。序列化可以基于先序、中序、后序、层序
的二叉树遍历方式来进行修改，序列化的结果是一个字符串，序列化时通过 
某种符号表示空节点（#），以 ！ 表示一个结点值的结束（value!）。

二叉树的反序列化是指：根据某种遍历顺序得到的序列化字符串结果str，重构二叉树。
*/

namespace nowcoder {
    namespace Serialize {
        class Solution {
            const char splitter = ',';
            public string Serialize(TreeNode root) {
                var pre = SerializeOrder(root, WalkPre);
                var mid = SerializeOrder(root, WalkMid);
                return $"{pre}{splitter}{mid}{splitter}";
            }
            public TreeNode Deserialize(string str) {
                var ordres = str.Split($"{splitter}{splitter}");
                var preStr = ordres[0];
                var midStr = ordres[1];

                var pre = DeserializeOrder(preStr);
                var mid = DeserializeOrder(midStr);
                if (pre == null || mid == null) {
                    return null;
                }
                return CreateTree(pre, mid);
            }

            TreeNode CreateTree(int[] pre, int[] mid) {
                if (pre.Length == 0) {
                    return null;
                }

                var node = new TreeNode(pre[0]);
                var index = System.Array.IndexOf(mid, node.val);
                var leftMid = SubArray(mid, index);
                var rightMid = SubArray(mid, index + 1, mid.Length - index - 1);
                var leftPre = SubArray(pre, 1, leftMid.Length);
                var rightPre = SubArray(pre, 1 + leftMid.Length, rightMid.Length);
                node.left = CreateTree(leftPre, leftMid);
                node.right = CreateTree(rightPre, rightMid);

                return node;
            }

            int[] SubArray(int[] array, int len) {
                var result = new int[len];
                System.Array.Copy(array, result, len);
                return result;
            }

            int[] SubArray(int[] array, int start, int len) {
                var result = new int[len];
                System.Array.Copy(array, start, result,0, len);
                return result;
            }

            int[] DeserializeOrder(string str) {
                if (string.IsNullOrEmpty(str)) {
                    return null;
                }
                var values = str.Split(splitter);
                var arr = new int[values.Length];
                for(var i = 0; i < values.Length; ++i) {
                    var valueStr = values[i];
                    arr[i] = int.Parse(valueStr);
                }

                return arr;
            }

            string SerializeOrder(TreeNode root, System.Action<TreeNode, System.Action<TreeNode>> order) {
                System.Text.StringBuilder builder = new System.Text.StringBuilder();
                order(root, (node) => {
                    builder.Append($"{node.val}{splitter}");
                });

                var temp = builder.ToString();
                return temp;
            }

            void WalkPre(TreeNode node, System.Action<TreeNode> func) {
                if (node == null) {
                    return;
                }

                func(node);
                WalkPre(node.left, func);
                WalkPre(node.right, func);
            }

            void WalkMid(TreeNode node, System.Action<TreeNode> func) {
                if (node == null) {
                    return;
                }

                WalkMid(node.left, func);
                func(node);
                WalkMid(node.right, func);
            }


            // test
            public static void Test() {
                var _ = TreeNode.EmptyNodeValue;
                //TestCase(Utility.GenTree(new long[] { 5,4,TreeNode.EmptyNodeValue,3, TreeNode.EmptyNodeValue, 2 }));
                //TestCase(Utility.GenTree(new long[] { 8,3,9,2,_,6,12,1,7,_,_,19,_,17,13 }));
                TestCase(Utility.GenTree(new long[] {  }));

                System.Console.ReadKey();
            }


            static void TestCase(TreeNode input) {
                var start = System.DateTime.Now;
                var obj = new Solution();
                var resultSerialize = obj.Serialize(input);
                var result = obj.Deserialize(resultSerialize);
                var elapse = (System.DateTime.Now - start).TotalMilliseconds;
                System.Console.WriteLine($"{resultSerialize} -- with {elapse}ms");
            }
        }
    }
}
