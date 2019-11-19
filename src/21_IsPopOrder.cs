
/*
 * 栈的压入、弹出序列

题目描述

输入两个整数序列，第一个序列表示栈的压入顺序，请判断第二个序列是否可能为该栈的弹出顺序。
假设压入栈的所有数字均不相等。例如序列1,2,3,4,5是某栈的压入顺序，序列4,5,3,2,1是该
压栈序列对应的一个弹出序列，但4,3,5,1,2就不可能是该压栈序列的弹出序列。
（注意：这两个序列的长度是相等的）
*/

namespace nowcoder {
    namespace IsPopOrder {
        class Solution {
            public bool IsPopOrder(int[] pushV, int[] popV) {
                for (int i = 0; i < popV.Length; ++i) {
                    if (IsPushOrder(pushV, popV, i) == false) {
                        return false;
                    }
                }
                return true;
            }

            bool IsPushOrder(int[] pushV, int[] popV, int popIndex) {
                var curPopValue = popV[popIndex];
                var pushIndex = -1;
                for (int i = 0; i < pushV.Length; ++i) {
                    if (pushV[i] == curPopValue) {
                        pushIndex = i;
                        break;
                    }
                }
                if (pushIndex < 0) {
                    return false;
                }
                System.Func<int, bool> isLaterPushed = (val) => {
                    for (var i = pushIndex + 1; i < pushV.Length; ++i) {
                        if (pushV[i] == val) {
                            return true;
                        }
                    }
                    return false;
                };
                var checkPushIndex = pushIndex;
                for (var i = popIndex + 1; i < popV.Length; ++i) {
                    var checkValue = popV[i];
                    if (isLaterPushed(checkValue)) {
                        continue;
                    }
                    var find = false;
                    while (checkPushIndex-- > 0) {
                        if (pushV[checkPushIndex] == checkValue) {
                            find = true;
                            break;
                        }
                    }

                    if (find == false) {
                        return false;
                    }
                }

                return true;
            }

            public static void Test() {
                TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 4, 5, 3, 2, 1 });
                TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 4, 3, 5, 1, 2 });
            }

            static void TestCase(int[] pushV, int[] popV) {
                var obj = new Solution();
                var answer = obj.IsPopOrder(pushV, popV);
                System.Console.WriteLine($"{answer}");
            }
        }
    }
}
