using System;
using System.Collections.Generic;
using System.Text;

/*
 * 变态跳台阶

题目描述

一只青蛙一次可以跳上1级台阶，也可以跳上2级……它也可以跳上n级。
求该青蛙跳上一个n级的台阶总共有多少种跳法。
*/

namespace nowcoder {
    namespace jumpFloorII {
        class Solution {
            public int jumpFloorII(int number) {
                if (number == 1)
                    return 1;

                int count = 1;
                for (int i = 1; i < number; ++i) {
                    count += jumpFloorII(number - i);
                }

                return count;
            }

            public static void Test() {
                var obj = new Solution();
                for (int i = 0; i < 10; i++)
                    Console.WriteLine($"jumpFloorII({i}): {obj.jumpFloorII(i)}");
            }
        }
    }
}
