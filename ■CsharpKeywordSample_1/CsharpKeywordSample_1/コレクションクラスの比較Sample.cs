using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpKeywordSample_1
{
    internal class コレクションクラスの比較Sample
    {
        public void 各コレクションを比較する()
        {
            Console.Write("\r\n★★★各コレクションを比較する★★★\r\n");

            Console.Write("\r\n■■配列■■\r\n");
            var col1A = new[]
                        {
                            "1.string配列",
                            "2.string配列",
                            "3.string配列"
                        };
            引数が配列(col1A);
            引数が可変長引数_str(col1A);
            引数がIEnumerable_Tstr(col1A);
            Console.ReadKey();


            Console.Write("\r\n■■配列(可変長引数)■■\r\n");//配列を作成せず呼び出せる
            //引数がIEnumerable_Tst("あ");　一度配列を作成しないと呼び出しできないためエラー
            引数が可変長引数_str("あ", "い");
            引数が可変長引数_str("あ", "い", "う");
            引数が可変長引数_str("あ", "い", "う", "え", "お");
            Console.ReadKey();


            //“Rectangular Array”(四角い配列)
            Console.Write("\r\n■■多次元配列■■\r\n");
            var col1B = new[,]
                        {
                            {
                                "1-1.string配列",
                                "1-2.string配列",
                                "1-3.string配列"
                            },
                            {
                                "2-1.string配列",
                                "2-2.string配列",
                                "2-3.string配列"
                            }
                        };
            多次元配列(col1B);
            //引数がIEnumerable_Tst(col1B);　IEnuemrable<T>は多次元配列に対応していないためエラー
            Console.ReadKey();


            //“Jagged Array” (ジャグ配列/ぎざぎざ配列)
            Console.Write("\r\n■■配列の配列■■\r\n");
            var col1C
                = new[]
                  {
                      new[]
                      {
                          1,
                          3,
                          5,
                          7,
                          9
                      },
                      new[]
                      {
                          0,
                          2,
                          4,
                          6
                      },
                      new[]
                      {
                          11,
                          22
                      }
                  };
            配列の配列(col1C);
            //引数がIEnumerable_Tint(col1C);　IEnuemrable<T>は配列の配列に対応していないためエラー
            Console.ReadKey();


            Console.Write("\r\n■■List<T>■■\r\n");
            IEnumerable<string> col2 = new List<string>
                                       {
                                           "1.List<T>",
                                           "2.List<T>",
                                           "3.List<T>"
                                       };
            //引数が可変長引数_str(col2);　List<T>はIEnuemrable<T>を使用しているため、エラー
            引数がIEnumerable_Tstr(col2);
            Console.ReadKey();


            Console.Write("\r\n■■LinkedList<T>■■\r\n");
            var col3 = new LinkedList<string>();
            col3.AddFirst("1.LinkedList");
            col3.AddLast("2.LinkedList");
            col3.AddFirst("3.LinkedList");
            //引数が可変長引数_str(col3);　LinkedList<T>はIEnuemrable<T>を使用しているため、エラー
            引数がIEnumerable_Tstr(col3);
            Console.ReadKey();


            //そのまま列挙される
            Console.Write("\r\n■■Dictionary<TKey,TValue>■■\r\n");
            var col4 = new Dictionary<string, int>();
            col4["Sixteen"] = 16;
            col4["Seventy-two"] = 72;
            col4["Forty-two"] = 42;
            KeyValuePairがあるコレクション(col4);
            Console.ReadKey();


            //ソートされた状態で列挙される
            //インデックスを指定したアクセスができる
            //SortedListに格納される要素に割り振られるインデックスは、あくまで各要素を並べ替えた時の順序
            Console.Write("\r\n■■SortedList<TKey,TValue>■■\r\n");
            var col5A = new SortedList<string, int>();
            col5A["ccc"] = 1;
            col5A["aaa"] = 2;
            col5A["ddd"] = 3;
            col5A["eee"] = 4;
            col5A["bbb"] = 5;
            KeyValuePairがあるコレクション(col5A);
            Console.ReadKey();


            //インデックスを指定したアクセスはできない
            Console.Write("\r\n■■SortedDictionary<TKey,TValue>■■\r\n");
            var col5B = new SortedDictionary<string, int>();
            col5B["ccc"] = 1;
            col5B["aaa"] = 2;
            col5B["ddd"] = 3;
            col5B["eee"] = 4;
            col5B["bbb"] = 5;
            KeyValuePairがあるコレクション(col5B);
            Console.ReadKey();


            /*後入れ先出し(LIFO: Last-In, First-Out)
            Stack(スタック)に格納される要素は格納された順に並べられ、格納された後はその順序を並べ替えることはできない*/
            Console.Write("\r\n■■Stack<T>■■\r\n");
            var col6 = new Stack<string>();
            col6.Push("aaa");
            col6.Push("bbb");
            col6.Push("ccc");
            col6.Push("ddd");
            col6.Push("eee");
            //引数が可変長引数_str(col6);　Stack<T>はIEnuemrable<T>を使用しているため、エラー
            引数がIEnumerable_Tstr(col6);
            Console.ReadKey();


            /*先入れ先出し(FIFO: First-In, First-Out) 
            Queue(キュー)に格納される要素は格納された順に並べられ、格納された後はその順序を並べ替えることはできない*/
            Console.Write("\r\n■■Queue<T>■■\r\n");
            var col7 = new Queue<string>();
            col7.Enqueue("aaa");
            col7.Enqueue("bbb");
            col7.Enqueue("ccc");
            col7.Enqueue("ddd");
            col7.Enqueue("eee");
            //引数が可変長引数_str(col7);　Queue<T>はIEnuemrable<T>を使用しているため、エラー
            引数がIEnumerable_Tstr(col7);
            Console.ReadKey();


            /*数学における集合の概念を表すコレクションクラス
            要素は重複することなく格納される　
            SortedSetクラスは、名前のとおりHashSetクラスに並べ替えの機能を追加したクラス*/
            Console.Write("\r\n■■HashSet<T>■■\r\n");
            var col8 = new HashSet<int>(new[]
                                        {
                                            0,
                                            1,
                                            3,
                                            4,
                                            6
                                        });
            col8.Add(2);
            //引数が可変長引数_int(col8);　HashSet<T>はIEnuemrable<T>を使用しているため、エラー
            引数がIEnumerable_Tint(col8);
            Console.ReadKey();

            Console.Write("\r\n■■SortedSet<T>■■\r\n");
            var col9 = new SortedSet<int>(new[]
                                          {
                                              0,
                                              1,
                                              3,
                                              4,
                                              6
                                          });
            col9.Add(2);
            //引数が可変長引数_int(col9);　SortedSet<T>はIEnuemrable<T>を使用しているため、エラー
            引数がIEnumerable_Tint(col9);
            Console.ReadKey();
        }

        //各メソッドの定義

        public void 引数が配列(string[] array)
        {
            foreach (var s in array)
            {
                Console.WriteLine(s);
            }
        }


        public void 引数が可変長引数_str(params string[] array)
        {
            foreach (var s in array)
            {
                Console.WriteLine(s);
            }
        }


        public void 引数が可変長引数_int(params int[] array)
        {
            foreach (var s in array)
            {
                Console.WriteLine(s);
            }
        }


        public void 多次元配列(string[,] array)
        {
            foreach (var s in array)
            {
                Console.WriteLine(s);
            }
        }


        public void 配列の配列(int[][] array)
        {
            for (var i = 0; i < array.Length; i++)
            {
                Console.Write("配列({0}): ", i);

                for (var j = 0; j < array[i].Length; j++)
                {
                    Console.Write("{0}{1}", array[i][j], j == (array[i].Length - 1)
                                                             ? ""
                                                             : " ");
                }
                Console.WriteLine();
            }
        }


        public void 引数がIEnumerable_Tstr(IEnumerable<string> enumerable)
        {
            foreach (var s in enumerable)
            {
                Console.WriteLine(s);
            }
        }


        public void 引数がIEnumerable_Tint(IEnumerable<int> enumerable)
        {
            foreach (var s in enumerable)
            {
                Console.WriteLine(s);
            }
        }


        //KeyValuePairがあるコレクション用の関数定義(引数)
        public void KeyValuePairがあるコレクション(IEnumerable<KeyValuePair<string, int>> enumerable)
        {
            foreach (var s in enumerable)
            {
                Console.WriteLine(s);
            }
        }
    }
}
