﻿using System;
using System.Collections.Generic;
using System.Text;

/*
 * 整数中1出现的次数（从1到n整数中1出现的次数）

题目描述

求出1~13的整数中1出现的次数,并算出100 ~1300的整数中1出现的次数？
为此他特别数了一下1 ~13中包含1的数字有1、10、11、12、13因此共出现6次,
但是对于后面问题他就没辙了。ACMer希望你们帮帮他,并把问题更加普遍化,
可以很快的求出任意非负整数区间中1出现的次数（从1 到 n 中1出现的次数）。
*/

namespace nowcoder {
    namespace NumberOf1Between1AndN_Solution {
        class Solution {
            public int NumberOf1Between1AndN_Solution(int n) {
                var unit = Unit(n);
                if(unit == 1) {
                    return n >= 1 ? 1 : 0;
                }
                var unitCount = n / unit;
                var unitRemain = n % unit;

                var numberOfRemain = NumberOf1Between1AndN_Solution(unitRemain);
                var countPerUnit = NumberOf1Between1AndN_Solution(unit - 1);
                if(unitCount > 1) {
                    return unit + unitCount * countPerUnit + numberOfRemain;
                }

                return unitRemain + 1 + countPerUnit + numberOfRemain;
            }

            int Unit(int n) {
                var digits = 1;
                var scale = 10;
                var ceiling = 10;
                while (ceiling <= n) {
                    digits++;
                    ceiling *= scale;
                }
                return ceiling / scale;
            }

            public static void Test() {
                var obj = new Solution();
                var unit = obj.NumberOf1Between1AndN_Solution(9999);
                Console.WriteLine($"{unit}");
            }
        }
    }
}
