using System;
using System.Collections.Generic;
using System.Text;

/*
 * 数组中出现次数超过一半的数字

题目描述

数组中有一个数字出现的次数超过数组长度的一半，请找出这个数字。
例如输入一个长度为9的数组{1,2,3,2,2,2,5,4,2}。
由于数字2在数组中出现了5次，超过数组长度的一半，因此输出2。
如果不存在则输出0。
*/

namespace nowcoder {
    namespace MoreThanHalfNum_Solution {
        class Solution {
            const int NotExist = 0;
            public int MoreThanHalfNum_Solution(int[] numbers) {
                if (numbers == null || numbers.Length == 0) {
                    return NotExist;
                }
                var halfCount = numbers.Length / 2;
                System.Collections.Generic.Dictionary<int, int> dict = new System.Collections.Generic.Dictionary<int, int>();
                foreach(var v in numbers) {
                    if (dict.ContainsKey(v)) {
                        dict[v] += 1;
                    } else {
                        dict[v] = 1;
                    }
                }
                foreach(var pair in dict) {
                    if(pair.Value > halfCount) {
                        return pair.Key;
                    }
                }
                return NotExist;
            }
        }
    }
}
