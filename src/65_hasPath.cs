using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

/*
 * 矩阵中的路径

题目描述

请设计一个函数，用来判断在一个矩阵中是否存在一条包含某字符串所有字符的路径。
路径可以从矩阵中的任意一个格子开始，每一步可以在矩阵中向左，向右，向上，向下
移动一个格子。如果一条路径经过了矩阵中的某一个格子，则该路径不能再进入该格子。 
例如 
a b c e 
s f c s 
a d e e 
矩阵中包含一条字符串"bcced"的路径，
但是矩阵中不包含"abcb"路径，因为字符串的第一个字符b占据了矩阵中的第一行第二个格子之后，
路径不能再次进入该格子。
*/

namespace nowcoder {
    namespace hasPath {
        class Solution {
            public class Record {
                public int Row { get; private set; }
                public int Col { get; private set; }
                public Record(int row, int col) {
                    Row = row;
                    Col = col;
                }

                public override string ToString() {
                    return $"[{Row},{Col}]";
                }

                public static Record Create(int row, int col) {
                    return new Record(row, col);
                }
            }
            public bool hasPath(string matrix, int rows, int cols, string path) {
                if (path.Length == 0) {
                    return false;
                }
                var firstChar = path[0];
                var index = matrix.IndexOf(firstChar);
                while (index >= 0) {
                    var row = index / cols;
                    var col = index % cols;
                    var cell = Record.Create(row, col);
                    var cells = new System.Collections.Generic.List<Record>();
                    cells.Add(cell);
                    if (hasPath(matrix, rows, cols, path, cells))
                        return true;
                    index = matrix.IndexOf(firstChar, index + 1);
                }

                return false;
            }

            bool hasPath(string matrix, int rows, int cols, string path, System.Collections.Generic.List<Record> cells) {
                if(cells.Count == path.Length) {
                    return true;
                }

                var pastCount = cells.Count;
                var lastCell = cells[pastCount - 1];
                var curChar = path[pastCount];
                var curCells = cells.Take(pastCount).ToList();
                System.Func<int, int, bool> isValidCell = (int row, int col) => {
                    if (row < 0 || col < 0 || row >= rows || col >= cols)
                        return false;
                    if (hasCell(curCells, row, col))
                        return false;

                    var cellChar = matrix[row * cols + col];
                    if (cellChar != curChar)
                        return false;

                    return true;
                };

                System.Func<int, int, bool> checkCell = (int row, int col) => {
                    if(isValidCell(row, col)) {
                        var tempCells = cells.Take(pastCount).ToList();
                        tempCells.Add(Record.Create(row, col));
                        return hasPath(matrix, rows, cols, path, tempCells);
                    }
                    return false;
                };

                if (checkCell(lastCell.Row - 1, lastCell.Col))
                    return true;
                if (checkCell(lastCell.Row + 1, lastCell.Col))
                    return true;
                if (checkCell(lastCell.Row, lastCell.Col - 1))
                    return true;
                if (checkCell(lastCell.Row, lastCell.Col + 1))
                    return true;

                return false;
            }

            bool hasCell(System.Collections.Generic.List<Record> cells, int row, int col) {
                foreach (var rec in cells) {
                    if (rec.Row == row && rec.Col == col)
                        return true;
                }

                return false;
            }


            // Test
            public static void Test() {
                TestCase("abcesfcsadee", 3,4,"bcced");
                TestCase("abcesfcsadee", 3,4,"abcd");
                //TestCase(TreeLinkNode.Create(new int[] { 8, 6, 10, 5, 7, 9, 11 }, 7));

                System.Console.ReadKey();
            }


            static void TestCase(string input, int rows, int cols, string path) {
                var start = System.DateTime.Now;
                var obj = new Solution();
                var result = obj.hasPath(input, rows, cols, path);
                var elapse = (System.DateTime.Now - start).TotalMilliseconds;
                System.Console.WriteLine($"{result} -- with {elapse}ms");
            }
        }
    }
}
