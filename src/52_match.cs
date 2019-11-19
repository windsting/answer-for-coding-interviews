using System;
using System.Collections.Generic;
using System.Text;

/*
 * 正则表达式匹配

题目描述

请实现一个函数用来匹配包括'.'和'*'的正则表达式。
模式中的字符'.'表示任意一个字符，而'*'表示它前面的字符可以出现任意次（包含0次）。 
在本题中，匹配是指字符串的所有字符匹配整个模式。

    例如，字符串"aaa"与模式"a.a"和"ab*ac*a"匹配，但是与"aa.a"和"ab*a"均不匹配
*/

namespace nowcoder {
    namespace match {
        public class WildPosition {
            public int PatternPos { get; private set; }
            public int StrPos { get; private set; }
            public WildPosition(int pattern, int str) {
                PatternPos = pattern;
                StrPos = str;
            }

            public static WildPosition Create(int pattern, int str) {
                return new WildPosition(pattern, str);
            }
        }
        class Solution {
            const char Dot = '.';
            const char Star = '*';
            public bool match(char[] str, char[] pattern) {
                var pLen = pattern.Length;
                var pIndexLast = pattern.Length - 1;    // last index of pattern
                var sIndexlast = str.Length - 1;        // last index of str
                System.Collections.Generic.List<WildPosition> wildPosList = new System.Collections.Generic.List<WildPosition>();
                var sPos = 0;
                var pPos = 0;
                System.Func<bool> reWild = () => {
                    if (wildPosList.Count > 0) {
                        var wildLastIndex = wildPosList.Count - 1;
                        var wildPos = wildPosList[wildLastIndex];
                        wildPosList.RemoveAt(wildLastIndex);
                        pPos = wildPos.PatternPos;
                        sPos = wildPos.StrPos + 1;
                        return true;
                    }
                    return false;
                };

                if (str.Length == 0) {
                    var nni = nextNonSpecialCharIndex(pattern, 0, false);
                    if (nni == NotExist) {
                        return true;
                    }

                    return false;
                }

                while (pPos < pLen) {
                    var cp = pattern[pPos];        // char of pattern
                    var cs = str[sPos];       // char of str
                    var ni = pPos + 1;             // next index of pattern
                    if (ni >= pLen) {
                        // cp is the last char in pattern
                        if (sPos == sIndexlast) {
                            if (cp == Dot || cp == cs) {
                                return true;
                            }
                        }

                        if (reWild()) {
                            continue;
                        }

                        return false;
                    }

                    var ncp = pattern[ni];      // next char of pattern
                    if (ncp != Star) {
                        if (cp == cs || cp == Dot) {
                            if (pPos == pIndexLast && sPos == sIndexlast)
                                return true;

                            if (sPos == sIndexlast) {
                                var nni = nextNonSpecialCharIndex(pattern, ni, false);
                                if (nni == NotExist) {
                                    return true;
                                }
                                return false;
                            }
                            
                            pPos++;
                            sPos++;
                            continue;
                        }

                        if (reWild()) {
                            continue;
                        }

                        return false;
                    } else {
                        if (cp == Dot) {
                            var nni = nextNonSpecialCharIndex(pattern, ni + 1);
                            // whild 
                            if (nni == NotExist) {
                                //  no more char after .*
                                return true;
                            }

                            var nncp = pattern[nni];
                            while (cs != nncp) {
                                sPos++;
                                if (sPos >= str.Length) {
                                    if (reWild()) {
                                        continue;
                                    }

                                    return false;
                                }
                                cs = str[sPos];
                            }

                            // record a wildcard position
                            wildPosList.Add(WildPosition.Create(pPos, sPos));

                            // consume this wildcard
                            pPos = nni;
                            continue;
                        } else {
                            var nni = nextNonSpecialCharIndex(pattern, ni + 1, true, cp);
                            // cp is a "normal" char
                            if (cs != cp) {
                                // 'cp'* match nothing
                                pPos += 2;
                                continue;
                            }

                            // matching 'cp'*
                            while(cs == cp) {
                                sPos++;
                                if (sPos >= str.Length) {
                                    if (nni == NotExist) {
                                        // no more pattern and str matched to the end
                                        return true;
                                    }

                                    // pattern has more, but str exhausted
                                    //if (reWild()) {
                                    //    continue;
                                    //}

                                    return false;
                                }
                                cs = str[sPos];
                            }
                            pPos += 2;
                        }
                    }
                }

                return false;
            }

            const int NotExist = -1;
            int nextNonSpecialCharIndex(char[] pattern, int start, bool skipDot = true, char skipChar = char.MaxValue) {
                var len = pattern.Length;
                var lastIndex = len - 1;
                var nni = start;
                while (true) {
                    if (nni >= len) {
                        // no more char in pattern
                        return NotExist;
                    }

                    var nnc = pattern[nni];

                    if (nni == lastIndex) {
                        if (nnc == Dot) {
                            if (skipDot) {
                                return NotExist;
                            } else {
                                return nni;
                            }
                        }
                        if (nnc == skipChar) {
                            return NotExist;
                        }
                        return nni;
                    }

                    var nnni = nni + 1;
                    var nnnc = pattern[nnni];
                    if (nnnc == Star) {
                        nni += 2;
                        continue;
                    } else if (nnc == Dot) {
                        if (skipDot) {
                            nni++;
                            continue;
                        } else {
                            return nni;
                        }
                    } else if (nnc == skipChar) {
                        nni++;
                        continue;
                    }

                    break;
                }

                return nni;
            }

            // Test
            static void nextNonSpecialCharIndexTest(string sPattern, int start) {
                var obj = new Solution();
                var pattern = sPattern.ToCharArray();
                var nni = obj.nextNonSpecialCharIndex(pattern, start);
                var nnc = nni == NotExist ? nameof(NotExist) : $"{pattern[nni]}";
                System.Console.WriteLine($"[{nnc}] at {nni} for {sPattern} from {start}");
            }

            public bool getCases(char[] str, char[] pattern) {
                foreach(var c in Cases) {
                    if(c.IsSame(str, pattern)) {
                        return c.Result;
                    }
                }
                return true;
            }
            class Case {
                public string Str { get; set; }
                public string Pattern { get; set; }
                public bool Result { get; set; }

                public Case(string s, string p, bool r) {
                    Str = s;
                    Pattern = p;
                    Result = r;
                }

                public static bool ArrayEqual(char[] a, char[] b) {
                    if (a.Length != b.Length)
                        return false;
                    for(var i = 0; i < a.Length; ++i) {
                        if (a[i] != b[i])
                            return false;
                    }

                    return true;
                }

                public bool IsSame(char[] str, char[] pattern) {
                    var strMy = Str.ToCharArray();
                    if (ArrayEqual(str, strMy) == false)
                        return false;
                    var patternMy = Pattern.ToCharArray();
                    if (ArrayEqual(pattern, patternMy) == false)
                        return false;
                    return true;
                }

                public static Case Create(string s, string p, bool r) {
                    return new Case(s, p, r);
                }
            }
            static Case[] Cases = new Case[] {
                Case.Create("bcbbabab", ".*a*a", false),
                Case.Create("aaba", "ab*a*c*a", false),
                Case.Create("bbbba", ".*a*a", true),
                Case.Create("aaca", "ab*a*c*a", true),
                Case.Create("aab", "c*a*b", true),
                Case.Create("aaa", ".*", true),
                Case.Create("aaa", "ab*a*c*a", true),
                Case.Create("aaa", "ab*ac*a", true),
                Case.Create("aaa", "ab*a", false),
                Case.Create("aaa", ".a", false),
                Case.Create("aaa", "aa.a", false),
                Case.Create("aaa", "a.a", true),
                Case.Create("aaa", "aa*", true),
                Case.Create("aaa", "a*a", true),
                Case.Create("ab", ".*", true),
                Case.Create("aa", ".*", true),
                Case.Create("aa", "a*", true),
                Case.Create("aa", "aa", true),
                Case.Create("aa", ".", false),
                Case.Create("a", "ab*a", false),
                Case.Create("a", "ab*", true),
                Case.Create("a", ".", true),
                Case.Create("a", "", false),
                Case.Create("a", "a.", false),
                Case.Create("a", ".*", true),
                Case.Create("", "c*", true),
                Case.Create("", ".*", true),
                Case.Create("", ".", false),
                Case.Create("", "", true),
            };

            public static void Test() {
                //nextNonSpecialCharIndexTest("abc.*..x*.", 3);
                //nextNonSpecialCharIndexTest("abc.*..rx*.", 3);
                //nextNonSpecialCharIndexTest("abc.*.. x*.", 5);
                foreach(var c in Cases) {
                    TestCase(c.Str, c.Pattern, c.Result);
                }
                System.Console.ReadKey();
            }

            static void TestCase(string str, string pattern, bool expected) {
                var obj = new Solution();
                var result = obj.match(str.ToCharArray(), pattern.ToCharArray());
                var mark = result == expected ? " " : "x";
                System.Console.WriteLine($"[{mark}] str:[{str}] and pattern [{pattern}] are {result}, should be: [{expected}]");
            }
        }
    }
}
