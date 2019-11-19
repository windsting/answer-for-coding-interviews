using System.Collections.Generic;
using System.Text;

/*
 * 顺时针打印矩阵

题目描述

输入一个矩阵，按照从外向里以顺时针的顺序依次打印出每一个数字，例如，如果输入如下4 X 4矩阵： 
 1  2  3  4 
 5  6  7  8 
 9 10 11 12 
13 14 15 16 

则依次打印出数字
1,2,3,4,8,12,16,15,14,13,9,5,6,7,11,10
*/

namespace nowcoder {
    namespace printMatrix {
        class Solution {
            public List<int> printMatrix(int[][] matrix) {
                List<int> lst = new List<int>();
                if (matrix.Length == 0) {
                    return lst;
                }
                var lenX = matrix[0].Length;
                var lenY = matrix.Length;
                var layer = 0;
                var layerCount = (System.Math.Min(lenX, lenY) + 1) / 2;
                while (layer < layerCount) {
                    var matrixLenX = lenX - layer * 2;
                    var matrixLenY = lenY - layer * 2;
                    var layerLenX = matrixLenX - 1;
                    var layerLenY = matrixLenY - 1;
                    if (layerLenX == 0) {
                        for (var i = 0; i < matrixLenY; i++) {
                            lst.Add(matrix[layer + i][layer]);
                        }
                        break;
                    }
                    if (layerLenY == 0) {
                        for (var i = 0; i < matrixLenX; i++) {
                            lst.Add(matrix[layer][layer + i]);
                        }
                        break;
                    }
                    for (var i = 0; i < layerLenX; ++i) {
                        lst.Add(matrix[layer][layer + i]);
                    }
                    for (var i = 0; i < layerLenY; ++i) {
                        lst.Add(matrix[layer + i][layer + layerLenX]);
                    }
                    for (var i = 0; i < layerLenX; ++i) {
                        lst.Add(matrix[layer + layerLenY][layer + layerLenX - i]);
                    }
                    for (var i = 0; i < layerLenY; ++i) {
                        lst.Add(matrix[layer + layerLenY - i][layer]);
                    }
                    layer++;
                }
                return lst;
            }

            public static void Test() {
                int[][] matrix1 = new int[][] {
                new int[]{1,2,3,4},
                new int[]{5,6,7,8},
                new int[]{9,10,11,12},
                new int[]{13,14,15,16},
            };

                int[][] matrix2 = new int[][] {
                new int[]{1,2,3},
                new int[]{4,5,6},
                new int[]{7,8,9},
            };

                int[][] matrix3 = new int[][] {
                new int[]{1,2,3},
                new int[]{4,5,6},
            };

                int[][] matrix4 = new int[][] {
                new int[]{1},
                new int[]{2},
                new int[]{3},
                new int[]{4},
                new int[]{5},
            };
                TestCase(matrix2);
            }

            static void TestCase(int[][] matrix) {
                var obj = new Solution();
                var list = obj.printMatrix(matrix);
                foreach (var rec in list) {
                    System.Console.WriteLine($"{rec}");
                }
            }
        }
    }
}
