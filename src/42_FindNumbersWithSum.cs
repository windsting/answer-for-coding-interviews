using System.Collections.Generic;

/*
 * 和为S的两个数字
 
题目描述

输入一个递增排序的数组和一个数字S，在数组中查找两个数，使得他们的和正好是S，
如果有多对数字的和等于S，输出两个数的乘积最小的。

输出描述:
对应每个测试案例，输出两个数，小的先输出。
*/

namespace nowcoder {
    namespace FindNumbersWithSum {
        class Solution {
            public List<int> FindNumbersWithSum(int[] array, int sum) {
                List<int> list = new List<int>();
                int[] values = new int[2];
                FindNumbersWithSum(array, sum, 0, array.Length - 1, int.MaxValue, values);

                if (values[0] != values[1])
                    foreach (var val in values)
                        list.Add(val);

                return list;
            }

            void FindNumbersWithSum(int[] array, int sum, int left, int right, int curProd, int[] curValues) {
                if (left >= right)
                    return;
                var valLeft = array[left];
                var valRight = array[right];
                var curSum = valLeft + valRight;
                if(curSum == sum) {
                    var product = valLeft * valRight;
                    if(product < curProd) {
                        curValues[0] = valLeft;
                        curValues[1] = valRight;
                        curProd = product;
                    }
                }

                if(curSum >= sum) {
                    FindNumbersWithSum(array, sum, left, right - 1, curProd, curValues);
                } else {
                    FindNumbersWithSum(array, sum, left + 1, right, curProd, curValues);
                }
            }

            public static void Test() {
                TestCase(new int[] { 1, 2, 4, 7, 11, 16 }, 10);

                System.Console.ReadKey();
            }


            static void TestCase(int[] input, int k) {
                var start = System.DateTime.Now;
                var obj = new Solution();
                var result = obj.FindNumbersWithSum(input, k);
                var elapse = (System.DateTime.Now - start).TotalMilliseconds;
                System.Console.WriteLine($"{result} -- with {elapse}ms");
            }
        }
    }
}
