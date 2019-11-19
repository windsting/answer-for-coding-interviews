using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * 最小的K个数

题目描述

输入n个整数，找出其中最小的K个数。
例如输入4,5,1,6,2,7,3,8这8个数字，
则最小的4个数字是1,2,3,4,。
*/

namespace nowcoder {
    namespace GetLeastNumbers_Solution {
        class Solution {
            public List<int> GetLeastNumbers_Solution(int[] input, int k) {
                if (k > input.Length) {
                    return new List<int>();
                }
                SortedSet<int> values = new SortedSet<int>();
                foreach(var v in input) {
                    values.Add(v);
                }
                var list = values.ToList();
                return list.Take(k).ToList();
            }
        }
    }
}
