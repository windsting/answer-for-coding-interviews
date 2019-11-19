using System;
using System.Collections.Generic;
using System.Text;

/*
 * 旋转数组的最小数字

题目描述

把一个数组最开始的若干个元素搬到数组的末尾，我们称之为数组的旋转。
输入一个非递减排序的数组的一个旋转，输出旋转数组的最小元素。
例如数组{3,4,5,1,2}为{1,2,3,4,5}的一个旋转，该数组的最小值为1。
NOTE：给出的所有元素都大于0，若数组大小为0，请返回0。
*/

/*
 * Just find the min value, the "rotate" part is noise.
 */

namespace nowcoder {
    namespace minNumberInRotateArray {
        class Solution {
            public int minNumberInRotateArray(int[] rotateArray) {
                if (rotateArray.Length == 0)
                    return 0;

                var minIndex = MinIndex(rotateArray);
                var minValue = rotateArray[minIndex];
                Reverse(rotateArray, 0, minIndex - 1);
                Reverse(rotateArray, minIndex, rotateArray.Length - 1);
                Reverse(rotateArray, 0, rotateArray.Length - 1);

                return minValue;
            }

            public static int MinIndex(int[] array) {
                int index = 0;
                for (int i = 0; i < array.Length; ++i) {
                    if (array[i] < array[index]) {
                        index = i;
                    }
                }
                return index;
            }

            public static void Reverse(int[] array, int start, int end) {
                while (start <= end) {
                    int temp = array[start];
                    array[start] = array[end];
                    array[end] = temp;
                    start++;
                    end--;
                }
            }

            public static void Test() {
                var obj = new Solution();
                var array = new int[] { 3, 4, 5, 1, 2 };
                var val = obj.minNumberInRotateArray(array);
                Console.WriteLine($"{nameof(val)}: {val}");
            }
        }
    }
}
