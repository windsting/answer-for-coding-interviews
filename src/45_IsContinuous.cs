using System;
using System.Collections.Generic;
using System.Text;

/*
 * 扑克牌顺子

题目描述

LL今天心情特别好, 因为他去买了一副扑克牌, 发现里面居然有2个大王,2个小王(一副牌原本是54张^_^)...
他随机从中抽出了5张牌,想测测自己的手气,看看能不能抽到顺子,如果抽到的话,他决定去买体育彩票,嘿嘿！！
“红心A,黑桃3,小王,大王,方片5”,“Oh My God!”不是顺子.....
LL不高兴了,他想了想,决定大\小 王可以看成任何数字, 并且A看作1, J为11, Q为12, K为13。
上面的5张牌就可以变成“1,2,3,4,5”(大小王分别看作2和4),“So Lucky!”。LL决定去买体育彩票啦。 

现在,要求你使用这幅牌模拟上面的过程,然后告诉我们LL的运气如何， 
如果牌能组成顺子就输出true，否则就输出false。
为了方便起见,你可以认为大小王是0。
*/

namespace nowcoder {
    namespace IsContinuous {
        class Solution {
            public bool IsContinuous(int[] numbers) {
                const int Empty = -1;
                const int SeqCardCount = 5;
                if (numbers == null || numbers.Length != SeqCardCount) {
                    return false;
                }
                var list = new System.Collections.Generic.List<int>();
                int jokerCount = 0;
                foreach(var val in numbers) {
                    if (val != 0) {
                        list.Add(val);
                    } else {
                        jokerCount++;
                    }
                }

                if(list.Count < 2) {
                    return true;
                }

                list.Sort();
                
                for(var i = 0; i < list.Count - 1; ++i) {
                    if (list[i] == list[i + 1])
                        return false;
                }

                var firstValue = list[0];
                int[] temp = new int[numbers.Length];
                for(int i = 0; i < numbers.Length; ++i) {
                    temp[i] = Empty;
                }

                foreach(var val in list) {
                    var pos = val - firstValue;
                    if (pos < temp.Length) {
                        temp[pos] = val;
                    } else {
                        return false;
                    }
                }
                var emptyCount = 0;
                foreach(var val in temp) {
                    if (val == Empty) {
                        emptyCount++;
                    }
                }

                if (emptyCount <= jokerCount)
                    return true;

                return false;
            }

            public static void Test() {
                TestCase(new int[] { 1, 3, 2, 5, 4 });

                System.Console.ReadKey();
            }

            static void TestCase(int[] input) {
                var start = System.DateTime.Now;
                var obj = new Solution();
                var result = obj.IsContinuous(input);
                var elapse = (System.DateTime.Now - start).TotalMilliseconds;
                System.Console.WriteLine($"{result} -- with {elapse}ms");
            }
        }
    }
}
