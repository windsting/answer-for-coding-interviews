using System;
using System.Collections.Generic;
using System.Text;

/*
 * 二维数组中的查找

题目描述

在一个二维数组中（每个一维数组的长度相同），每一行都按照从左到右递增的顺序排序，
每一列都按照从上到下递增的顺序排序。请完成一个函数，
输入这样的一个二维数组和一个整数，判断数组中是否含有该整数。
*/

namespace nowcoder {
    namespace Find {
        class Solution {
            public bool Find(int target, int[][] array) {
                var xLen = array[0].Length;
                var yLen = array.Length;

                if (xLen == 0) {
                    return false;
                }

                var xLast = xLen - 1;
                for (var i = 0; i < yLen; ++i) {
                    if (array[i][xLast] < target) {
                        continue;
                    }
                    if (array[i][0] > target) {
                        break;
                    }
                    if (bSearch(target, array[i], 0, xLen - 1)) {
                        return true;
                    }
                }

                return false;
            }

            bool bSearch(int target, int[] array, int start, int end) {
                if (start > end) {
                    return false;
                }

                int mid = start + (end - start) / 2;
                var vMid = array[mid];
                if (vMid > target) {
                    return bSearch(target, array, start, mid - 1);
                } else if (vMid < target) {
                    return bSearch(target, array, mid + 1, end);
                }

                return true;
            }

            bool bSearchY(int target, int[][] array, int x, ref int start, ref int end) {
                if (start > end) {
                    return false;
                }

                int mid = start + (end - start) / 2;
                var vMid = array[mid][x];
                if (vMid > target) {
                    end = mid - 1;
                    return bSearchY(target, array, x, ref start, ref end);
                } else if (vMid < target) {
                    start = mid + 1;
                    return bSearchY(target, array, x, ref start, ref end);
                }

                return true;
            }
        }
    }
}
