using System;
using System.Collections.Generic;
using System.Text;

/*
 * 数字在排序数组中出现的次数

题目描述

统计一个数字在排序数组中出现的次数。
*/

namespace nowcoder {
    namespace GetNumberOfK {
        class Solution {
            public int GetNumberOfK(int[] data, int k) {
                if(data==null || data.Length == 0) {
                    return 0;
                }

                var len = data.Length;
                var lastIndex = len - 1;
                if(data[0] > data[len - 1]) {
                    System.Array.Reverse(data);
                }

                var index = IndexOf(data, k, 0, lastIndex);
                if (index == NotExist) {
                    return 0;
                }

                var count = 1;
                var i = index + 1;
                while(i <= lastIndex && data[i] == k) {
                    count++;
                    i++;
                }
                i = index - 1;
                while(i >= 0 &&data[i] == k) {
                    count++;
                    i--;
                }

                return count;
            }

            const int NotExist = -1;
            int IndexOf(int[] data, int k, int first, int last) {
                if (first == last && data[first] == k) {
                    return first;
                }

                if(first >= last) {
                    return NotExist;
                }

                var mid = (first + last) >> 1;
                var midValue = data[mid];
                if (midValue > k) {
                    return IndexOf(data, k, first, mid-1);
                } else if(midValue < k) {
                    return IndexOf(data, k, mid + 1, last);
                }

                return mid;
            }

            public static void Test() {
                TestCase(new int[] { 3 }, 3);

                Console.ReadKey();
            }


            static void TestCase(int[] input, int k) {
                var start = DateTime.Now;
                var obj = new Solution();
                var result = obj.GetNumberOfK(input, k);
                var elapse = (DateTime.Now - start).TotalMilliseconds;
                System.Console.WriteLine($"{result} -- with {elapse}ms");
            }
        }
    }
}
