using System;
using System.Collections.Generic;
using System.Text;

namespace nowcoder {
    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int x) {
            val = x;
        }

        public ListNode Append(int v) {
            next = new ListNode(v);
            return next;
        }

        public override string ToString() {
            return $"{val}";
        }

        public static ListNode Gen(int[] array) {
            ListNode list = null;
            var iter = list;
            foreach (var v in array) {
                if (list == null) {
                    list = new ListNode(v);
                    iter = list;
                } else {
                    iter = iter.Append(v);
                }
            }

            return list;
        }
    }


    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) {
            val = x;
        }

        public override string ToString() {
            return $"{val}";
        }

        public const long EmptyNodeValue = long.MaxValue;
        public static void Test() {
            var root = Utility.GenTree(new long[] { 8, 6, 10, 5, 7, 9, 11 });
            Console.WriteLine($"done: {root.val}");
        }
    }

    class Utility {
        public static TreeNode GenTree(long[] values) {
            TreeNode root = null;
            var levelCount = 1;
            List<TreeNode> lastLevel = new List<TreeNode>();
            List<TreeNode> curLevel = new List<TreeNode>();
            while (levelCount < values.Length) {
                lastLevel = curLevel;
                curLevel = new List<TreeNode>();
                var levelIndexStart = levelCount - 1;
                for (int i = 0; i < levelCount; ++i) {
                    TreeNode node = null;
                    var valueIndex = levelIndexStart + i;
                    if (valueIndex >= values.Length) {
                        break;
                    }
                    var value = values[valueIndex];
                    if (value != TreeNode.EmptyNodeValue) {
                        node = new TreeNode((int)value);
                    }
                    curLevel.Add(node);

                    if (root == null) {
                        root = node;
                        break;
                    }

                    var parentIndex = i >> 1;
                    var parent = lastLevel[parentIndex];
                    if (parent != null) {
                        var isLeft = (i & 1) == 0;
                        if (isLeft) {
                            parent.left = node;
                        } else {
                            parent.right = node;
                        }
                    }

                }

                levelCount = levelCount << 1;
            }

            return root;
        }

        public static void PreTree(TreeNode root, Action<TreeNode> func) {
            if (root == null) {
                return;
            }
            func(root);
            func(root.left);
            func(root.right);
        }

        public static void MidTree(TreeNode root, Action<TreeNode> func) {
            if (root == null) {
                return;
            }
            func(root.left);
            func(root);
            func(root.right);
        }

        public static void PostTree(TreeNode root, Action<TreeNode> func) {
            if (root == null) {
                return;
            }
            func(root.left);
            func(root.right);
            func(root);
        }

        public static void PrintElapse<T>(string id, Func<T> func) {
            var start = DateTime.Now;
            var value = func();
            var end = DateTime.Now;
            var elapse = end - start;
            Console.WriteLine($"{value} -- with {elapse.TotalMilliseconds}ms");
        }

        public static int[] Clone(int[] src) {
            var dst = new int[src.Length];
            Array.Copy(src, dst, src.Length);
            return dst;
        }
    }
}

