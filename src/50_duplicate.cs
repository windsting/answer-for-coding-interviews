using System;
using System.Collections.Generic;
using System.Text;

/*
 * 数组中重复的数字

题目描述

在一个长度为n的数组里的所有数字都在0到n-1的范围内。 
数组中某些数字是重复的，但不知道有几个数字是重复的。
也不知道每个数字重复几次。请找出数组中任意一个重复的数字。 
例如，如果输入长度为7的数组{2,3,1,0,2,5,3}，
那么对应的输出是第一个重复的数字2。
*/

namespace nowcoder {
    namespace duplicate {
        class Solution {
            public bool duplicate(int[] numbers, int[] duplication) {
                System.Array.Sort(numbers);
                var lastIndex = numbers.Length - 1;
                for(int i = 0; i < lastIndex; ++i) {
                    if(numbers[i] == numbers[i + 1]) {
                        duplication[0] = numbers[i];
                        return true;
                    }
                }

                return false;
            }
        }
    }
}
