using System;
using System.Collections.Generic;
using System.Text;

/*
 * 数组中只出现一次的数字

题目描述

一个整型数组里除了两个数字之外，其他的数字都出现了两次。
请写程序找出这两个只出现一次的数字。
*/

namespace nowcoder {
    namespace FindNumsAppearOnce {
        //num1,num2分别为长度为1的数组。传出参数
        //将num1[0],num2[0]设置为返回结果
        class Solution {
            System.Collections.Generic.List<int> Positions;
            public void FindNumsAppearOnce(int[] array, int[] num1, int[] num2) {
                if (array == num1 || array.Length == 0) {
                    return;
                }
                Positions = new System.Collections.Generic.List<int>();
                System.Array.Sort(array);
                FindNumsAppearOncePos(array, 0, array.Length - 1);
                if(Positions.Count > 0) {
                    num1[0] = array[Positions[0]];
                }

                if(Positions.Count > 1) {
                    num2[0] = array[Positions[1]];
                }
            }

            void FindNumsAppearOncePos(int[] array, int first, int last) {
                if (first > last) {
                    return;
                }
                var len = SpanLen(first, last);
                if (len == 0) {
                    return;
                }

                if (len == 1) {
                    Positions.Add(first);
                    return;
                }

                if (len == 2) {
                    if (array[first] != array[last]) {
                        Positions.Add(first);
                        Positions.Add(last);
                    }
                    return;
                }

                var mid = (first + last) >> 1;
                var midVal = array[mid];
                var pairWithLeft = (midVal == array[mid - 1]);
                var pairWithRight = (midVal == array[mid + 1]);
                int leftLast = 0, rightFirst = 0;
                if (pairWithLeft == false && pairWithRight == false) {
                    Positions.Add(mid);

                    leftLast = mid - 1;
                    rightFirst = mid + 1;

                } else if (pairWithLeft && pairWithRight) {
                    leftLast = mid;
                    while (leftLast >= first && array[leftLast] == midVal)
                        leftLast--;
                    rightFirst = mid;
                    while (rightFirst <= last && array[rightFirst] == midVal)
                        rightFirst++;
                } else if (pairWithLeft) {
                    leftLast = mid - 2;
                    rightFirst = mid + 1;
                } else {
                    leftLast = mid - 1;
                    rightFirst = mid + 2;
                }

                var leftLenOdd = IsOddLen(first, leftLast);
                var rightLenOdd = IsOddLen(rightFirst, last);
                if (leftLenOdd == rightLenOdd) {
                    FindNumsAppearOncePos(array, first, leftLast);
                    FindNumsAppearOncePos(array, rightFirst, last);
                } else if (leftLenOdd) {
                    FindNumsAppearOncePos(array, first, leftLast);
                } else {
                    FindNumsAppearOncePos(array, rightFirst, last);
                }
            }

            bool IsOddLen(int first, int last) {
                var spanLen = SpanLen(first, last);
                return IsOdd(spanLen);
            }

            bool IsPairLeadingPosition(int first, int pos) {
                var diff = pos - first;
                return IsOdd(diff);
            }

            bool IsOdd(int val) {
                return (val & 1) == 1;
            }

            int SpanLen(int first, int last) {
                return last - first + 1;
            }


            public static void Test() {
                TestCase(new int[] { 4, 6, 1, 1, 1, 1 });

                Console.ReadKey();
            }


            static void TestCase(int[] input) {
                var start = DateTime.Now;
                var obj = new Solution();
                var arr1 = new int[1] { 0 };
                var arr2 = new int[1] { 0 };
                obj.FindNumsAppearOnce(input, arr1, arr2);
                var elapse = (DateTime.Now - start).TotalMilliseconds;
                System.Console.WriteLine($"{arr1[0]}, {arr2[0]} -- with {elapse}ms");
            }
        }
    }
}
