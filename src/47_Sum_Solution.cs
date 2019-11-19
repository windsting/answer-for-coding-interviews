using System;
using System.Collections.Generic;
using System.Text;

/*
 * 求1+2+3+...+n

题目描述

求1+2+3+...+n，要求不能使用乘除法、for、while、if、else、switch、case等关键字及条件判断语句（A? B:C）。
*/

namespace nowcoder {
    namespace Sum_Solution {
        // referenced answer of nailperry on page
        //  https://www.nowcoder.com/questionTerminal/7a0da8fc483247ff8800059e12d7caf1?f=discussion
        class Solution {
            public int Sum_Solution(int n) {
                var val = n;
                var end = (n != 0) && (val += Sum_Solution(n - 1)) > 0;
                return val;
            }

            public static void Test() {
                TestCase(10);

                System.Console.ReadKey();
            }


            static void TestCase(int input) {
                var start = System.DateTime.Now;
                var obj = new Solution();
                var result = obj.Sum_Solution(input);
                var elapse = (System.DateTime.Now - start).TotalMilliseconds;
                System.Console.WriteLine($"{result} -- with {elapse}ms");
            }
        }
    }
}
