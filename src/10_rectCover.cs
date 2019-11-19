using System;
using System.Collections.Generic;
using System.Text;

/*
 * 矩形覆盖

题目描述

我们可以用2*1的小矩形横着或者竖着去覆盖更大的矩形。
请问用n个2*1的小矩形无重叠地覆盖一个2* n的大矩形，总共有多少种方法？
*/

namespace nowcoder {
    namespace rectCover {
        class Solution {
            public int rectCover(int number) {
                if (number == 0) {
                    return 0;
                }
                if (number == 1) {
                    return 1;
                }
                if (number == 2) {
                    return 2;
                }

                return rectCover(number - 1) + rectCover(number - 2);
            }

            public static void Test() {
                var obj = new Solution();
                for (int i = 0; i < 10; i++)
                    Console.WriteLine($"rectCover({i}): {obj.rectCover(i)}");
            }
        }
    }
}
