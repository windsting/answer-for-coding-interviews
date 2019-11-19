using System;
using System.Collections.Generic;
using System.Text;

/*
 * 机器人的运动范围

题目描述

地上有一个m行和n列的方格。一个机器人从坐标0,0的格子开始移动，
每一次只能向左，右，上，下四个方向移动一格，
但是不能进入行坐标和列坐标的数位之和大于k的格子。 
例如，当k为18时，机器人能够进入方格（35,37），因为3+5+3+7 = 18。
但是，它不能进入方格（35,38），因为3+5+3+8 = 19。
请问该机器人能够达到多少个格子？
*/

namespace nowcoder {
    namespace movingCount {
        class Solution {
            public int movingCount(int threshold, int rows, int cols) {
                int count = 0;
                for (var i = 0; i < rows; ++i) {
                    var sumRow = digitsSum(i);
                    if (sumRow > threshold) {
                        break;
                    }
                    for (var j = 0; j < cols; ++j) {
                        var sumCol = digitsSum(j);
                        if (sumCol > threshold) {
                            break;
                        }
                        if (sumRow + sumCol <= threshold) {
                            count++;
                        }
                    }
                }

                return count;
            }

            const int scale = 10;
            int digitsSum(int value) {
                int result = 0;
                while (value > 0) {
                    result += value % scale;
                    value = value / scale;
                }

                return result;
            }

            // Test
            public static void Test() {
                TestCase(15, 100, 1);

                System.Console.ReadKey();
            }


            static void TestCase(int input, int rows, int cols) {
                var start = System.DateTime.Now;
                var obj = new Solution();
                var result = obj.movingCount(input, rows, cols);
                var elapse = (System.DateTime.Now - start).TotalMilliseconds;
                System.Console.WriteLine($"{result} -- with {elapse}ms");
            }
        }
    }
}
