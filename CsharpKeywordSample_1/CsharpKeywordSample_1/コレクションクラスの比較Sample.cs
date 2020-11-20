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

            #region 1次元配列

            Console.Write("\r\n■1次元配列■\r\n");
            var array = new[]
                        {
                            "[0]",
                            "[1]",
                            "[2]"
                        };
            Array(array);
            Array2(array);
            IEnumerable(array);
            Console.ReadKey();

            #endregion

            #region 1次元配列(可変長引数)

            Console.Write("\r\n■1次元配列(可変長引数)■\r\n"); //配列を作成せず呼び出せる
            Array2("[0]", "[1]", "[2]", "[3]", "[4]");
            //IEnumerable("あ", "い", "う", "え", "お"); IEnumerableにparamsを付けることはできない
            Console.ReadKey();

            #endregion

            #region 多次元配列：Rectangular Array(四角い配列)

            Console.Write("\r\n■2次元配列(多次元配列)■\r\n");
            var strings2 = new[,]
                           {
                               {
                                   "[1-0]",
                                   "[1-1]",
                                   "[1-2]"
                               },
                               {
                                   "[2-0]",
                                   "[2-1]",
                                   "[2-2]"
                               }
                           };
            Array3(strings2);
            //IEnumerable(strings2);　IEnuemrable<T>は多次元配列に対応していないためエラー
            Console.ReadKey();

            Console.Write("\r\n■3次元配列(多次元配列)■\r\n");
            var strings3 = new[,,]
                           {
                               {
                                   {
                                       "[1-1-0]",
                                       "[1-1-1]",
                                       "[1-1-2]"
                                   },
                                   {
                                       "[1-2-0]",
                                       "[1-2-1]",
                                       "[1-2-2]"
                                   }
                               },
                               {
                                   {
                                       "[2-1-0]",
                                       "[2-1-1]",
                                       "[2-1-2]"
                                   },
                                   {
                                       "[2-2-0]",
                                       "[2-2-1]",
                                       "[2-2-2]"
                                   }
                               }
                           };
            Array4(strings3);
            //IEnumerable(strings3);　IEnuemrable<T>は多次元配列に対応していないためエラー
            Console.ReadKey();

            #endregion

            #region 配列の配列：Jagged Array(ジャグ配列/ぎざぎざ配列)

            Console.Write("\r\n■配列の配列■\r\n");
            var ints
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
            Array5(ints);
            //IEnumerable(col1C);　IEnuemrable<T>は配列の配列に対応していないためエラー
            Console.ReadKey();

            #endregion

            #region List<T>

            Console.Write("\r\n■List<T>■\r\n");
            IEnumerable<string> list = new List<string>
                                       {
                                           "[0]",
                                           "[1]",
                                           "[2]"
                                       };
            //Array(list);　List<T>はIEnuemrable<T>を使用しているため、エラー
            IEnumerable(list);
            Console.ReadKey();

            #endregion

            #region LinkedList<T>

            Console.Write("\r\n■LinkedList<T>■\r\n");
            var linkedList = new LinkedList<string>();
            linkedList.AddFirst("[0]");
            linkedList.AddLast("[1]");
            linkedList.AddFirst("[2]");
            //Array(linkedList);　LinkedList<T>はIEnuemrable<T>を使用しているため、エラー
            IEnumerable(linkedList);
            Console.ReadKey();

            #endregion

            #region Dictionary<TKey,TValue>

            //そのまま列挙される
            Console.Write("\r\n■Dictionary<TKey,TValue>■\r\n");
            var dictionary = new Dictionary<string, int>();

            dictionary["Sixteen"] = 16;
            dictionary["Seventy-two"] = 72;
            dictionary["Forty-two"] = 42;

            KeyValuePair(dictionary);
            Console.ReadKey();

            #endregion

            #region SortedList<TKey,TValue>

            //ソートされた状態で列挙される
            //インデックスを指定したアクセスができる
            //SortedListに格納される要素に割り振られるインデックスは、あくまで各要素を並べ替えた時の順序
            Console.Write("\r\n■SortedList<TKey,TValue>■\r\n");
            var sortedList = new SortedList<string, int>();

            sortedList["ccc"] = 1;
            sortedList["aaa"] = 2;
            sortedList["ddd"] = 3;
            sortedList["eee"] = 4;
            sortedList["bbb"] = 5;

            KeyValuePair(sortedList);
            Console.ReadKey();

            #endregion

            #region SortedDictionary<TKey,TValue>

            //インデックスを指定したアクセスはできない
            Console.Write("\r\n■SortedDictionary<TKey,TValue>■\r\n");
            var sortedDictionary = new SortedDictionary<string, int>();

            sortedDictionary["ccc"] = 1;
            sortedDictionary["aaa"] = 2;
            sortedDictionary["ddd"] = 3;
            sortedDictionary["eee"] = 4;
            sortedDictionary["eee"] = 5;

            KeyValuePair(sortedDictionary);
            Console.ReadKey();

            #endregion

            #region Stack<T>

            /*後入れ先出し(LIFO: Last-In, First-Out)
            Stack(スタック)に格納される要素は格納された順に並べられ、格納された後はその順序を並べ替えることはできない*/
            Console.Write("\r\n■Stack<T>■\r\n");
            var stack = new Stack<string>();
            stack.Push("aaa");
            stack.Push("bbb");
            stack.Push("ccc");
            stack.Push("ddd");
            stack.Push("eee");
            //Array(stack);　Stack<T>はIEnuemrable<T>を使用しているため、エラー
            IEnumerable(stack);
            Console.ReadKey();

            #endregion

            #region Queue<T>

            /*先入れ先出し(FIFO: First-In, First-Out) 
            Queue(キュー)に格納される要素は格納された順に並べられ、格納された後はその順序を並べ替えることはできない*/
            Console.Write("\r\n■Queue<T>■\r\n");
            var queue = new Queue<string>();
            queue.Enqueue("aaa");
            queue.Enqueue("bbb");
            queue.Enqueue("ccc");
            queue.Enqueue("ddd");
            queue.Enqueue("eee");
            //Array(queue);　Queue<T>はIEnuemrable<T>を使用しているため、エラー
            IEnumerable(queue);
            Console.ReadKey();

            #endregion

            #region HashSet<T>

            /*数学における集合の概念を表すコレクションクラス
            要素は重複することなく格納される　
            SortedSetクラスは、名前のとおりHashSetクラスに並べ替えの機能を追加したクラス*/
            Console.Write("\r\n■HashSet<T>■\r\n");
            var hashSet = new HashSet<int>(new[]
                                           {
                                               0,
                                               1,
                                               3,
                                               4,
                                               6
                                           })
                          {
                              2
                          };

            //hashSet.Add(2);

            //Array(hashSet);　HashSet<T>はIEnuemrable<T>を使用しているため、エラー
            IEnumerable(hashSet);
            Console.ReadKey();

            #endregion

            #region SortedSet<T>

            Console.Write("\r\n■SortedSet<T>■\r\n");
            var sortedSet = new SortedSet<int>(new[]
                                               {
                                                   0,
                                                   1,
                                                   3,
                                                   4,
                                                   6
                                               })
                            {
                                2
                            };

            //sortedSet.Add(2);

            //Array(sortedSet);　SortedSet<T>はIEnuemrable<T>を使用しているため、エラー
            IEnumerable(sortedSet);
            Console.ReadKey();

            #endregion
        }

        /// <summary>
        /// 1次元配列
        /// </summary>
        /// <param name="array"></param>
        public void Array<T>(T[] array)
        {
            foreach (var s in array)
            {
                Console.WriteLine(s);
            }
        }

        /// <summary>
        /// 1次元配列　params(可変長引数)：メソッドの引数の数を可変にする
        /// </summary>
        /// <param name="array"></param>
        public void Array2<T>(params T[] array)
        {
            foreach (var s in array)
            {
                Console.WriteLine(s);
            }
        }

        /// <summary>
        /// 2次元配列
        /// </summary>
        /// <param name="array"></param>
        public void Array3<T>(T[,] array)
        {
            foreach (var s in array)
            {
                Console.WriteLine(s);
            }
        }

        /// <summary>
        /// 3次元配列
        /// </summary>
        /// <param name="array"></param>
        public void Array4<T>(T[,,] array)
        {
            foreach (var s in array)
            {
                Console.WriteLine(s);
            }
        }

        /// <summary>
        /// 配列の配列
        /// </summary>
        /// <param name="array"></param>
        public void Array5<T>(T[][] array)
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

        /// <summary>
        /// IEnumerable[T]
        /// </summary>
        /// <param name="enumerable"></param>
        public void IEnumerable<T>(IEnumerable<T> enumerable)
        {
            foreach (var s in enumerable)
            {
                Console.WriteLine(s);
            }
        }

        /// <summary>
        /// IEnumerable[KeyValuePair[T, T2]]
        /// </summary>
        /// <param name="enumerable"></param>
        public void KeyValuePair<T, T2>(IEnumerable<KeyValuePair<T, T2>> enumerable)
        {
            foreach (var s in enumerable)
            {
                Console.WriteLine(s);
            }
        }
    }
}