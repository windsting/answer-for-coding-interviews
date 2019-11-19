using System;
using System.Collections.Generic;
using System.Text;

/*
 * 调整数组顺序使奇数位于偶数前面

题目描述

输入一个整数数组，实现一个函数来调整该数组中数字的顺序，使得所有的奇数位于数组的前半部分，
所有的偶数位于数组的后半部分，并保证奇数和奇数，偶数和偶数之间的相对位置不变。
*/

namespace nowcoder {
    namespace reOrderArray {
        class Solution {
            public int[] reOrderArray(int[] array) {
                var odd = new System.Collections.Generic.List<int>();
                var even = new System.Collections.Generic.List<int>();
                var newArray = new int[array.Length];
                foreach (var val in array) {
                    if ((val & 1) == 1) {
                        odd.Add(val);
                    } else {
                        even.Add(val);
                    }
                }
                for (var i = 0; i < odd.Count; ++i) {
                    newArray[i] = odd[i];
                }
                for (var i = 0; i < even.Count; ++i) {
                    newArray[i + odd.Count] = even[i];
                }

                return newArray;
            }
        }
    }
}
