using System.Collections.Generic;

/*
 * 和为S的连续正数序列

题目描述

小明很喜欢数学, 有一天他在做数学作业时, 要求计算出9~16的和,他马上就写出了正确答案是100。
但是他并不满足于此,他在想究竟有多少种连续的正数序列的和为100(至少包括两个数)。
没多久,他就得到另一组连续正数和为100的序列:18,19,20,21,22。现在把问题交给你,
你能不能也很快的找出所有和为S的连续正数序列? Good Luck!

输出描述:
输出所有和为S的连续正数序列。序列内按照从小至大的顺序，序列间按照开始数字从小到大的顺序
*/

namespace nowcoder {
    namespace FindContinuousSequence {
        class Solution {
            public List<List<int>> FindContinuousSequence(int sum) {
                var result = new List<List<int>>();
                for (var i = 2; ; ++i) {
                    var remIndex = i - 1;
                    var remSum = Sums[remIndex];
                    if (sum <= remSum)
                        break;
                    if ((sum - remSum) % i != 0) {
                        continue;
                    }

                    var first = (sum - remSum) / i;
                    List<int> seq = new List<int>();
                    result.Add(seq);
                    for(var j = 0; j < i; j++) {
                        seq.Add(first + j);
                    }
                }
                result.Reverse();
                return result;
            }

            static List<int> _Sums;
            static List<int> Sums {
                get {
                    if (_Sums == null) {
                        _Sums = new List<int> { 0 };
                        int i = 1;
                        while(_Sums[_Sums.Count-1] < int.MaxValue - i) {
                            _Sums.Add(_Sums[_Sums.Count - 1] + i);
                            ++i;
                        }
                    }
                    return _Sums;
                }
            }

            public static void Test() {
                TestCase(6);
                TestCase(100);

                System.Console.ReadKey();
            }


            static void TestCase(int input) {
                var start = System.DateTime.Now;
                var obj = new Solution();
                var results = obj.FindContinuousSequence(input);
                var elapse = (System.DateTime.Now - start).TotalMilliseconds;
                System.Console.WriteLine($"{results.Count} results -- with {elapse}ms");
            }
        }
    }
}
