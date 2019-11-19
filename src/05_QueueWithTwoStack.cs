
/*
 * 用两个栈实现队列

题目描述

用两个栈来实现一个队列，完成队列的Push和Pop操作。 队列中的元素为int类型。
*/

namespace nowcoder {
    namespace QueueWithTwoStack {
        class Solution {
            System.Collections.Generic.Stack<int> a = new System.Collections.Generic.Stack<int>();
            System.Collections.Generic.Stack<int> b = new System.Collections.Generic.Stack<int>();
            public void push(int node) {
                while (b.Count > 0) {
                    a.Push(b.Pop());
                }
                a.Push(node);
            }
            public int pop() {
                while (a.Count > 0) {
                    b.Push(a.Pop());
                }

                return b.Pop();
            }

            public static void Test() {
                var queue = new QueueWithTwoStack.Solution();

                queue.push(1);
                queue.push(2);
                queue.push(3);

                System.Console.WriteLine($"{queue.pop()}");
                System.Console.WriteLine($"{queue.pop()}");
                System.Console.WriteLine($"{queue.pop()}");
            }
        }
    }
}
