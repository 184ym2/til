using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQサンプル.cs
{
    /// ※※※※※※※※※※※※※※※※※※※※※※
    /// ※※
    /// ※※　DEBUGモードで利用すること
    /// 
    /// ※※
    /// ※※※※※※※※※※※※※※※※※※※※※※
    internal class Program
    {
        public static Dictionary<int, string> SourceA = new Dictionary<int, string>
                                                        {
                                                            {1, "いわお"}
                                                            , {2, "かどた"}
                                                            , {3, "しもむら"}
                                                            , {4, "すずき"}
                                                            , {5, "たなか"}
                                                            , {6, "てらさきA"}
                                                            , {7, "とおくにA"}
                                                            , {8, "まとのA"}
                                                            , {9, "やましたA"}
                                                        };

        public static Dictionary<int, string> SourceB = new Dictionary<int, string>
                                                        {
                                                            {1, "いわお"}
                                                            , {2, "かどた"}
                                                            , {3, "しもむら"}
                                                            , {4, "すずき"}
                                                            , {5, "たなか"}
                                                            , {6, "てらさきB"}
                                                            , {7, "とおくにB"}
                                                            , {8, "まとのB"}
                                                            , {9, "みやけB"}
                                                        };

        public static Dictionary<int, string> SourceC = new Dictionary<int, string>();

        public static List<string> margedNames
        {
            get { return SourceA.Values.Concat(SourceB.Values).ToList(); }
        }

        public static List<int> margedNumbers
        {
            get { return SourceA.Keys.Concat(SourceB.Keys).ToList(); }
        }

        public static List<KeyValuePair<int, string>> margedSource
        {
            get { return SourceA.Concat(SourceB).ToList(); }
        }

        public static List<string> SrcNames
        {
            get { return SourceA.Values.ToList(); }
        }

        public static List<int> SrcNumbers
        {
            get { return SourceA.Keys.ToList(); }
        }

        private static void Main(string[] args)
        {
            Aggregate01(); //シーケンス(集合)に集計関数を適用します。
            Aggregate02(); //シーケンス(集合)に集計関数を適用します。 指定されたシード値が最初の集計値として使用されます
            Aggregate03(); //シーケンス(集合)に集計関数を適用します。(複数項目集計サンプル)
            All01(); //シーケンス(集合)のすべての要素が条件を満たしているかどうかを判断します。
            Any01(); //シーケンス(集合)に要素が含まれているかどうかを判断します。
            Any02(); //シーケンス(集合)の任意の要素が条件を満たしているかどうかを判断します。
            Average(); //シーケンス(集合)の平均値を計算します。
            Cast01(); //指定した型にキャストします。
            Concat01(); //2 つのシーケンス(集合)を連結します。
            Contains01(); //指定した要素がシーケンス(集合)に含まれているかどうかを判断します。
            Count01(); //シーケンス(集合)内の要素数を返します。
            Count02(); //条件を満たす、指定されたシーケンス(集合)内の要素の数を表す数値を返します。
            DefaultIfEmpty01(); //指定されたシーケンス(集合)の要素を返します。シーケンス(集合)が空の場合は指定した値を返します。
            DefaultIfEmpty02(); //指定されたシーケンス(集合)の要素を返します。シーケンス(集合)が空の場合は型の既定値を返します。
            Distinct01(); //シーケンス(集合)から一意の要素を返します。
            ElementAt01(); //指定されたインデックス位置にある要素を返します。
            ElementAtDefault01(); //指定したインデックス位置にある要素を返します。インデックスが範囲外の場合は既定値を返します。
            Except01(); //2 つのシーケンス(集合)の差集合を生成します。
            First01(); //シーケンス(集合)の最初の要素を返します。
            First02(); //指定された条件を満たす、シーケンス(集合)の最初の要素を返します。
            FirstOrDefault01(); //シーケンス(集合)の最初の要素を返します。シーケンス(集合)に要素が含まれていない場合は既定値を返します。
            FirstOrDefault02(); //条件を満たす、シーケンス(集合)の最初の要素を返します。このような要素が見つからない場合は既定値を返します。
            InnerJoin(); //２つのシーケンス(集合)の内部結合を行います。(INNER JOIN)
            OuterJoin(); //２つのシーケンス(集合)の左辺外部結合を行います(LEFT OUETER JOIN)
            LongCount01(); //シーケンス(集合)内の要素の合計数を表す Int64 を返します。
            LongCount02(); //シーケンス(集合)内で条件を満たす要素の数を表す Int64 を返します。
            Max01(); //シーケンス(集合)の最大値を返します。
            Max02(); //シーケンス(集合)の各要素に対して変換関数を呼び出し、最大値を返します。
            Min01(); //シーケンス(集合)の最小値を返します。
            Min02(); //シーケンス(集合)の各要素に対して変換関数を呼び出し、結果の最小値を返します。
            OfType01(); //指定された型に基づいて要素をフィルター処理します。
            OrderBy01(); //要素を指定のキーに従って昇順に並べ替えます。
            OrderByDecending01(); //要素を指定のキーに従って昇順に並べ替えます。
            Reverse01(); //シーケンス(集合)の要素の順序を反転させます。
            Select01(); //シーケンス(集合)の各要素を新しいフォームに射影します。
            Select02(); //シーケンス(集合)の各要素をインデックス付きで新しいフォームに射影します。
            SequenceEqual01(); //標準の比較子で要素を比較することで、2 つのシーケンス(集合)が等しいかどうかを判断します
            SequenceEqual02(); //指定の比較子で要素を比較することで、2 つのシーケンス(集合)が等しいかどうかを判断します
            Single01(); //シーケンス(集合)の唯一の要素を返し、シーケンス(集合)内の要素が 1 つだけでない場合は例外をスローします。
            Single02(); //指定された条件を満たす、シーケンス(集合)の唯一の要素を返し、そのような要素が複数存在する場合は例外をスローします。
            SingleOrDefault01(); //シーケンス(集合)の唯一の要素を返します。シーケンス(集合)が空の場合、既定値を返します。シーケンス(集合)内に要素が複数ある場合、このメソッドは例外をスローします。
            SingleOrDefault02(); //指定された条件を満たすシーケンス(集合)の唯一の要素、またはそのような要素がない場合は既定値を返します。このメソッドは、複数の要素が条件を満たす場合に例外をスローします
            Skip01(); //シーケンス(集合)内の指定された数の要素をバイパスし、残りの要素を返します。
            SkipWhile01(); //指定された条件が満たされる限り、シーケンス(集合)の要素をバイパスした後、残りの要素を返します。
            Sum01(); //値のシーケンス(集合)の合計を計算します。
            Sum02(); //各要素に対して変換関数を呼び出して取得する値の合計を計算します。
            Take01(); //シーケンス(集合)の先頭から、指定された数の連続する要素を返します。
            TakeWhile01(); //指定された条件が満たされる限り、シーケンス(集合)から要素を返します。
            ToDictionary01(); //指定されたキー セレクター関数および要素セレクター関数に従って、Dictionary<TKey,TValue> から IEnumerable<T> を作成します。
            Union01(); //既定の等値比較子を使用して、2 つのシーケンス(集合)の和集合を生成します。
            Union02(); //指定された比較子を使用して 2 つのシーケンス(集合)の和集合を生成します。
            Where01(); //述語に基づいて値のシーケンス(集合)をフィルター処理します。
            Zip01(); //2 つのシーケンス(集合)の対応する要素に対して、1 つの指定した関数を適用し、結果として 1 つのシーケンス(集合)を生成します。
        }

        #region ソート

        #region ソート用データ

        public static IEnumerable<ordersmpl> getordersample()
        {
            return new List<ordersmpl>
                   {
                       new ordersmpl(4, 1, 4)
                       , new ordersmpl(7, 8, 3)
                       , new ordersmpl(5, 5, 8)
                       , new ordersmpl(8, 5, 3)
                   };
        }

        public class ordersmpl
        {
            public ordersmpl(int v1, int v2, int v3)
            {
                V1 = v1;
                V2 = v2;
                V3 = v3;
            }

            public int V1 { get; set; }
            public int V2 { get; set; }
            public int V3 { get; set; }

            /// <summary>現在の <see cref="T:System.Object" /> を表す <see cref="T:System.String" /> を返します。</summary>
            /// <returns>現在の <see cref="T:System.Object" /> を表す <see cref="T:System.String" />。</returns>
            public override string ToString()
            {
                return string.Format("V1={0} V2={1} V3={2}", V1, V2, V3);
            }
        }

        #endregion ソート用データ

        private static void Reverse01()
        {
            /*要素を逆順に並び替え*/

            { /*非LINQ*/

                /*IEnnumrableのままではソートできないのでリスト化*/
                var result = getordersample().ToList();

                result.Reverse();
            }

            { /*LINQ*/

                var result = getordersample().Reverse();
            }
        }

        private static void OrderByDecending01()
        {
            /*V2をキーにソート*/

            /*非LINQ*/
            {
                /*IEnumrableのままではソートできないのでリスト化*/
                var result = getordersample().ToList();

                result.Sort((orderA, orderB) => orderB.V2 - orderA.V2);
            }

            { /*LINQ*/

                var result = getordersample().OrderByDescending(element => element.V2);
            }

            { /*LINQ*/

                var result = (from e in SourceA
                              orderby e.Key descending, e.Value descending
                              select e);

            }
        }

        private static void OrderBy01()
        {
            /*V2をキーにソート*/

            /*非LINQ*/
            {
                /*IEnumrable<T>のままではソートできないのでリスト化*/
                var result = getordersample().ToList();

                result.Sort((orderA, orderB) => orderA.V2 - orderB.V2);
            }

            { /*LINQ*/

                var result = getordersample().OrderBy(element => element.V2);
            }

            {/*LINQ*/

                var result = (from e in SourceA
                              orderby e.Key, e.Value
                              select e);

            }
            {/*LINQ*/

                var result = SourceA.OrderBy(e => e.Key).ThenBy(e => e.Value);

            }

        }

        #endregion

        #region 射影

        public static void Zip01()
        {
            //2 つのシーケンス(集合)の対応する要素に対して、1 つの指定した関数を適用し、結果として 1 つのシーケンス(集合)を生成します。

            { /*非LINQ*/

                var result = new List<string>();

                var maxSequence = SourceA.Values.Count;

                if (maxSequence > SourceB.Count)
                {
                    maxSequence = SourceB.Count;
                }

                for (var i = 0; i < maxSequence; i++)
                {
                    result.Add(SourceA.Values.ToList()[i] + " " + SourceB.Values.ToList()[i]);
                }
            }

            { /*LINQ*/

                var result = SourceA.Values.Zip(SourceB.Values, (elementA, elementB) => elementA + " " + elementB);
            }


        }

        public static void Where01()
        {
            //述語に基づいて値のシーケンス(集合)をフィルター処理します。

            { /*非LINQ*/

                var result = new List<string>();

                foreach (var element in SrcNames)
                {
                    if (element.Contains("ま"))
                    {
                        result.Add(element);
                    }
                }
            }

            { /*LINQ*/

                var result = SrcNames.Where(element => element.Contains("ま"));
            }

            { /*LINQ*/

                var result = SrcNames.Where(element => element.Contains("ま"))
                                     .Where(element => element.Contains("と"));

            }

            { /*LINQ*/

                var result = (from a in SrcNames.Where(element => element.Contains("ま"))
                                                .Where(element => element.Contains("と"))
                              join b in SourceB.Values
                              on a equals b
                              where b.Contains("ま")
                              select b);

            }

        }

        public static void Union02()
        {
            /*指定された比較子を使用して 2 つのシーケンス(集合)の和集合を生成します。*/

            /*値が同じだった場合、同一とする比較子を使用*/

            { /*非LINQ*/

                var result = new List<int>();
                var compare = new ValueComparer();

                foreach (var element in SourceA.Keys)
                {
                    if (result.Contains(element, compare) == false)
                    {
                        result.Add(element);
                    }
                }

                foreach (var element in SourceB.Keys)
                {
                    if (result.Contains(element, compare) == false)
                    {
                        result.Add(element);
                    }
                }
            }

            { /*LINQ*/

                var result = SourceA.Keys.Union(SourceB.Keys, new ValueComparer());
            }
        }

        private class ValueComparer : IEqualityComparer<int>
        {
            /// <summary>指定したオブジェクトが等しいかどうかを判断します。</summary>
            /// <returns>指定したオブジェクトが等しい場合は true。それ以外の場合は false。</returns>
            /// <param name="x">比較対象の <paramref name="T" /> 型の第 1 オブジェクト。</param>
            /// <param name="y">比較対象の <paramref name="T" /> 型の第 2 オブジェクト。</param>
            public bool Equals(int x, int y)
            {
                return x == y;
            }

            /// <summary>指定したオブジェクトのハッシュ コードを返します。</summary>
            /// <returns>指定したオブジェクトのハッシュ コード。</returns>
            /// <param name="obj">ハッシュ コードが返される対象の <see cref="T:System.Object" />。</param>
            /// <exception cref="T:System.ArgumentNullException">
            ///     <paramref name="obj" /> の型が参照型で、<paramref name="obj" /> が null です。
            /// </exception>
            public int GetHashCode(int obj)
            {
                return obj.GetHashCode();
            }
        }

        public static void Union01()
        {
            ////既定の等値比較子を使用して、2 つのシーケンス(集合)の和集合を生成します。

            { /*非LINQ*/

                var result = new List<string>();

                foreach (var element in SourceA.Values)
                {
                    if (result.Contains(element) == false)
                    {
                        result.Add(element);
                    }
                }

                foreach (var element in SourceB.Values)
                {
                    result.Add(element);
                }
            }

            { /*LINQ*/

                var result = SourceA.Values.Union(SourceB.Values);
            }
        }

        public static void ToDictionary01()
        {
            //指定されたキー セレクター関数および要素セレクター関数に従って、Dictionary<TKey,TValue> から IEnumerable<T> を作成します。

            { /*非LINQ*/

                var result = new Dictionary<int, string>();

                foreach (var element in SourceA)
                {
                    result.Add(element.Key, element.Value);
                }
            }

            { /*LINQ*/

                var result = SourceA.ToDictionary(element => element.Key
                                                , element => element.Value);
            }
        }

        public static void TakeWhile01()
        {
            //指定された条件が満たされる限り、シーケンス(集合)から要素を返します。

            { /*非LINQ*/
                var result = new List<int>();

                foreach (var element in SrcNumbers)
                {
                    if (element < 3)
                    {
                        result.Add(element);
                    }
                    else
                    {
                        break;
                    }
                }
            }

            { /*LINQ*/
                var result = SrcNumbers.TakeWhile(element => element < 3);
            }
        }

        public static void Take01()
        {
            //シーケンス(集合)の先頭から、指定された数の連続する要素を返します。

            { /*非LINQ*/

                var result = new List<string>();

                for (var i = 0; i < 2; i++)
                {
                    if (SrcNames.Count == i)
                    {
                        break;
                    }

                    result.Add(SrcNames[i]);
                }
            }

            { /*LINQ*/

                var result = SrcNames.Take(2);
            }

            //シーケンス(集合)の先頭から、指定された数の連続する要素を返します。
        }

        public static void SkipWhile01()
        {
            //指定された条件が満たされる限り、シーケンス(集合)の要素をバイパスした後、残りの要素を返します。

            //サンプル: 5以下をバイパス

            { /*非LINQ*/

                var result = new List<int>();

                foreach (var element in SrcNumbers)
                {
                    if (element < 5)
                    {
                        continue;
                    }

                    result.Add(element);
                }
            }

            { /*LINQ*/
                var result = SrcNumbers.SkipWhile(element => element < 5);
            }
        }

        public static void Skip01()
        {
            //シーケンス(集合)内の指定された数の要素をバイパスし、残りの要素を返します。

            /*サンプル：はじめに５つをスキップします。*/

            { /*非LINQ*/

                var result = new List<string>();

                for (var i = 5; i < SrcNames.Count; i++)
                {
                    result.Add(SrcNames[i]);
                }
            }

            { /*LINQ*/

                var result = SrcNames.Skip(5);
            }
        }

        public static void SingleOrDefault01()
        {
            //シーケンス(集合)の唯一の要素を返します。シーケンス(集合)が空の場合、既定値を返します。シーケンス(集合)内に要素が複数ある場合、このメソッドは例外をスローします。

            var data = new List<string>
                       {
                           "aaaa"
                       };

            { /*非LINQ*/

                string result;

                if (data.Count == 0)
                {
                    result = default(string);
                }

                else if (data.Count == 1)
                {
                    result = data[0];
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }

            { /*LINQ*/

                var result = data.SingleOrDefault();
            }
        }

        public static void SingleOrDefault02()
        {
            //指定された条件を満たすシーケンス(集合)の唯一の要素、またはそのような要素がない場合は既定値を返します。このメソッドは、複数の要素が条件を満たす場合に例外をスローします

            { /*非LINQ*/

                string result;
                var work = new List<string>();

                foreach (var element in SrcNames)
                {
                    if (element.Equals("すずき"))
                    {
                        work.Add(element);
                    }
                }

                if (work.Count == 0)
                {
                    result = default(string);
                }
                else if (work.Count == 1)
                {
                    result = work[0];
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }

            { /*LINQ*/

                var result = SrcNames.SingleOrDefault(element => element.Equals("すずき"));
            }
        }

        public static void Single02()
        {
            //指定された条件を満たす、シーケンス(集合)の唯一の要素を返し、そのような要素が複数存在する場合は例外をスローします。

            { /*非LINQ*/

                string result;
                var work = new List<string>();

                foreach (var element in SrcNames)
                {
                    if (element.Equals("すずき"))
                    {
                        if (work.Any())
                        {
                            throw new InvalidOperationException();
                        }

                        work.Add(element);
                    }
                }

                if (work.Count != 1)
                {
                    throw new InvalidOperationException();
                }

                result = work[0];
            }

            { /*LINQ*/

                var result = SrcNames.Single(element => element.Equals("すずき"));
            }
        }

        public static void Single01()
        {
            //シーケンス(集合)の唯一の要素を返し、シーケンス(集合)内の要素が 1 つだけでない場合は例外をスローします。

            var data = new List<string>
                       {
                           "aaaa"
                       };

            { /*非LINQ*/

                string result;

                if (data.Count != 1)
                {
                    throw new InvalidOperationException();
                }

                result = data[0];
            }

            { /*LINQ*/

                var result = data.Single();
            }
        }

        private static void Select02()
        {
            /*シーケンス(集合)の各要素をインデックス付きで新しいフォームに射影します。*/

            { /*非LINQ*/

                var result = new Dictionary<int, string>();

                var index = 0;

                foreach (var element in SrcNames)
                {
                    result.Add(index, element);

                    index = index + 1;
                }
            }

            { /*LINQ*/

                var result = SrcNames.Select((element, index) => new
                                                                 {
                                                                     index
                                                                     ,
                                                                     element
                                                                 });
            }
        }

        private static void Select01()
        {
            /*名前だけのリストを作成します。*/

            { /*非LINQ*/

                var result = new List<string>();

                foreach (var element in SourceA)
                {
                    result.Add(element.Value);
                }
            }

            { /*LINQ*/

                var result = SourceA.Select(element => element.Value);
            }

            {/*LINQ 複数要素抜き出し*/
                var result = (from e in SourceA
                              select new
                                     {
                                         e.Key
                                         ,
                                         e.Value
                                     });

            }

            { /*LINQ 独自クラスに抜き出し*/
                var result = (from e in SourceA
                              select new selectresult()
                                     {
                                         k = e.Key
                                         ,
                                         v = e.Value
                                     });
            }

        }

        public class selectresult
        {
            public int k;
            public string v;
        }

        private static void OfType01()
        {
            ////指定された型に基づいて要素をフィルター処理します。

            var data = new List<object>
                       {
                           64
                           , "aaaa"
                           , (long) 32
                       };

            { /*非LINQ*/

                var result = new List<string>();

                foreach (var element in data)
                {
                    if (element.GetType() == typeof(string))
                    {
                        result.Add((string)element);
                    }
                }
            }

            { /*LINQ*/

                var result = data.OfType<string>();
            }
        }

        public static void LongCount02()
        {
            //シーケンス(集合)内で条件を満たす要素の数を表す Int64 を返します。

            { /*非LINQ*/
                long result = 0;

                foreach (var element in SrcNames)
                {
                    if (element.Contains("い"))
                    {
                        result = result + 1;
                    }
                }
            }

            { /*LINQ*/

                var result = SrcNames.LongCount(element => element.Contains("い"));
            }
        }

        public static void LongCount01()
        {
            /*シーケンス(集合)内の要素の合計数を表す Int64 を返します。*/

            { /*非LINQ*/

                var result = (long)SourceA.Count;
            }

            { /*LINQ*/

                var result = SourceA.LongCount();
            }
        }

        public static void LastOrDefault02()
        {
            /*条件を満たす、シーケンス(集合)の最後の要素を返します。このような要素が見つからない場合は既定値を返します。*/

            { /*非LINQ*/
                var found = false;
                string result;

                foreach (var element in SrcNames)
                {
                    if (element.Equals("とおくにA"))
                    {
                        result = element;
                        found = true;
                    }
                }

                if (found == false)
                {
                    result = default(string);
                }
            }

            { /*LINQ*/

                var result = SrcNames.LastOrDefault(element => element.Equals("とおくにA"));
            }
        }

        public static void LastOrDefault01()
        {
            /*シーケンス(集合)の最後の要素を返します。シーケンス(集合)に要素が含まれていない場合は既定値を返します。*/

            { /*非LINQ*/

                string result;

                if (SrcNames.Count == 0)
                {
                    result = default(string);
                }
                else
                {
                    result = SrcNames[SrcNames.Count];
                }
            }

            { /*LINQ*/

                var result = SrcNames.LastOrDefault();
            }
        }

        public static void Last02()
        {
            /*指定された条件を満たす、シーケンス(集合)の最後の要素を返します。*/

            { /*非LINQ*/

                var found = false;
                string result = null;

                foreach (var element in SrcNames)
                {
                    if (element.Equals("たなか"))
                    {
                        result = element;
                        found = true;
                    }
                }

                if (found == false)
                {
                    throw new InvalidOperationException();
                }
            }

            { /*LINQ*/

                var result = SrcNames.Last(element => element.Equals("たなか"));
            }
        }

        public static void Last01()
        {
            /*最後の要素を取得します。*/

            { /*非LINQ*/

                if (SourceA.Count == 0)
                {
                    throw new InvalidOperationException();
                }

                var result = SourceA[SourceA.Count];
            }

            { /*LINQ*/

                var result = SourceA.Last();
            }
        }

        public static void Intersect01()
        {
            /*既定の等値比較子を使用して値を比較することにより、2 つのシーケンス(集合)の積集合を生成します。*/

            /*サンプル：ソースA・ソースBから　同じ名前のものを抜き出します。*/

            { /*非LINQ*/

                var result = new List<string>();

                foreach (var sourceAValue in SourceA.Values)
                {
                    foreach (var sourceBValue in SourceB.Values)
                    {
                        if (sourceAValue == sourceBValue)
                        {
                            result.Add(sourceAValue);
                        }
                    }
                }
            }

            { /*LINQ*/

                var result = SourceA.Values.Intersect(SourceB.Values);
            }
        }

        public static void InnerJoin()
        {
            { /*LINQ*/

                /*sourceAの集合と、sourceBの集合を、ValueでINNER JOIN した結果を返す。*/

                var result = from sA in SourceA
                             join sB in SourceB
                             on sA.Value equals sB.Value
                             select new
                                    {
                                        sA
                                        ,
                                        sB
                                    };
            }

            { /*LINQ*/

                /*sourceAの集合と、sourceBの集合を、KeyとValueでINNER JOIN した結果を返す。*/
                /*２つ以上の項目の場合　new{要素、要素} でかこって比較、型と名前、順序は合わせる*/

                var result = from sA in SourceA
                             join sB in SourceB
                             on new { sA.Key, sA.Value }
                             equals new { sB.Key, sB.Value }
                             select new
                                    {
                                        sA
                                        ,
                                        sB
                                    };
            }
        }

        public static void OuterJoin()
        {
            { /*LINQ*/

                /*sourceAの集合と、sourceBの集合を、ValueでLEFT OUTER JOIN した結果を返す。*/

                var result = from sA in SourceA
                             join sB in SourceB
                             on sA.Value equals sB.Value into sbjoind
                             from sBj in sbjoind.DefaultIfEmpty()
                             select new
                                    {
                                        sA
                                        ,
                                        sBj
                                    };
            }

            { /*LINQ*/

                /*sourceAの集合と、sourceBの集合を、KeyとValueでLEFT OUTER JOIN した結果を返す。*/
                /*２つ以上の項目の場合　new{要素、要素} でかこって比較、型と名前、順序は合わせる*/

                var result = from sA in SourceA
                             join sB in SourceB
                             on new { sA.Key, sA.Value }
                             equals new { sB.Key, sB.Value } into sbjoind
                             from sBj in sbjoind.DefaultIfEmpty()
                             select new
                                    {
                                        sA
                                        ,
                                        sBj
                                    };
            }

            var dataa = new List<dataclassA>
                        {
                           new dataclassA(0,0,0,0),
                           new dataclassA(0,0,1,2),
                           new dataclassA(0,1,0,3),
                           new dataclassA(0,1,1,4),
                           new dataclassA(8,8,8,8)
                        };

            var datab = new List<dataclassB>
                        {
                            new dataclassB(0,0,0,"a"),
                            new dataclassB(0,0,1,"b"),
                            new dataclassB(0,1,0,"c"),
                            new dataclassB(0,1,1,"d"),
                            new dataclassB(9,9,9,"e")

                        };

            var r = from da in dataa
                    join db in datab
                    on new { da.Key1, da.Key2, da.Key3 }
                    equals new { Key1 = db.KeyB1, Key2 = db.KeyB2, Key3 = db.KeyB3 } into jl
                    from j in jl.DefaultIfEmpty()
                    select new
                           {
                               da
                               ,
                               j
                           };

        }

        class dataclassA
        {
            public dataclassA(int k1, int k2, int k3, int value)
            {
                Key1 = k1;
                Key2 = k2;
                Key3 = k3;
                value = value;
            }

            public int Key1;
            public int Key2;
            public int Key3;

            public int Value;
        }

        class dataclassB
        {
            public dataclassB(int k1, int k2, int k3, string name)
            {
                KeyB1 = k1;
                KeyB2 = k2;
                KeyB3 = k3;
                Name = name;
            }

            public int KeyB1;
            public int KeyB2;
            public int KeyB3;

            public string Name;
        }

        public static void First01()
        {
            /*シーケンス(集合)の最初の要素を返します。*/

            { /*非LINQ*/

                if (SrcNumbers.Count == 0)
                {
                    throw new InvalidOperationException();
                }

                var result = SrcNumbers[0];
            }

            { /*LINQ*/

                var result = SrcNumbers.First();
            }
        }

        public static void First02()
        {
            /*指定された条件を満たす、シーケンス(集合)の最初の要素を返します。*/

            /*サンプル 初めに現れる４の値を取得します。*/

            { /*非LINQ*/

                int? result = null;

                foreach (var element in SrcNumbers)
                {
                    if (element == 4)
                    {
                        result = element;
                        break;
                    }
                }

                if (result == null)
                {
                    throw new InvalidOperationException();
                }
            }

            { /*LINQ*/

                var result = SrcNumbers.First(element => element == 4);
            }
        }

        public static void FirstOrDefault01()
        {
            /*シーケンス(集合)の最初の要素を返します。シーケンス(集合)に要素が含まれていない場合は既定値を返します。*/

            { /*非LINQ*/

                int result;

                if (SrcNumbers.Count == 0)
                {
                    result = default(int);
                }
                else
                {
                    result = SrcNumbers[0];
                }
            }

            { /*LINQ*/

                var result = SrcNumbers.FirstOrDefault();
            }
        }

        public static void FirstOrDefault02()
        {
            /*条件を満たす、シーケンス(集合)の最初の要素を返します。このような要素が見つからない場合は既定値を返します。*/

            /*サンプル：はじめにみつかった２５の値を返します。*/

            { /*非LINQ*/

                int? result = null;

                foreach (var srcNumber in SrcNumbers)
                {
                    if (srcNumber == 25)
                    {
                        result = srcNumber;
                    }
                }

                if (result == null)
                {
                    result = default(int);
                }
            }

            { /*LINQ*/

                var result = SrcNumbers.FirstOrDefault(element => element == 25);
            }
        }

        public static void Group01()
        {
            /*指定したキー値ごとの要素を集合化（グループ化）します。*/

            { /*非LINQ*/

                var result = new Dictionary<int, List<KeyValuePair<int, string>>>();

                foreach (var pair in margedSource)
                {
                    if (result.ContainsKey(pair.Key) == false)
                    {
                        result.Add(pair.Key, new List<KeyValuePair<int, string>>());
                    }

                    result[pair.Key].Add(pair);
                }
            }

            { /*LINQ*/

                var result = margedSource.GroupBy(e => e.Key);
            }
        }

        #region group2

        public static void Group02()
        {
            /*指定した(複数の)キーごとの要素を集合化(グループ化)します。*/

            { /*非LINQ*/

                var result = new Dictionary<Group02Key, List<KeyValuePair<int, string>>>();

                foreach (var pair in margedSource)
                {
                    var groupkey = new Group02Key
                                   {
                                       Key = pair.Key
                                       ,
                                       Value = pair.Value
                                   };

                    if (result.ContainsKey(groupkey) == false)
                    {
                        result.Add(groupkey, new List<KeyValuePair<int, string>>());
                    }

                    result[groupkey].Add(pair);
                }
            }

            { /*LINQ*/

                var result = margedSource.GroupBy(e => new
                                                  {
                                                      e.Key
                                                      ,
                                                      e.Value
                                                  });
            }
        }

        public class Group02Key : IEquatable<Group02Key>
        {
            public int Key;
            public string Value;

            /// <summary>指定した <see cref="T:System.Object" /> が、現在の <see cref="T:System.Object" /> と等しいかどうかを判断します。</summary>
            /// <returns>指定した <see cref="T:System.Object" /> が現在の <see cref="T:System.Object" /> と等しい場合は true。それ以外の場合は false。</returns>
            /// <param name="obj">現在の <see cref="T:System.Object" /> と比較する <see cref="T:System.Object" />。</param>
            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj))
                {
                    return false;
                }
                if (ReferenceEquals(this, obj))
                {
                    return true;
                }
                if (obj.GetType() != GetType())
                {
                    return false;
                }
                return Equals((Group02Key)obj);
            }

            /// <summary>特定の型のハッシュ関数として機能します。</summary>
            /// <returns>現在の <see cref="T:System.Object" /> のハッシュ コード。</returns>
            public override int GetHashCode()
            {
                unchecked
                {
                    return (Key * 397) ^ (Value != null
                               ? Value.GetHashCode()
                               : 0);
                }
            }

            /// <summary>現在のオブジェクトが、同じ型の別のオブジェクトと等しいかどうかを示します。</summary>
            /// <returns>現在のオブジェクトが <paramref name="other" /> パラメーターと等しい場合は true。それ以外の場合は false。</returns>
            /// <param name="other">このオブジェクトと比較するオブジェクト。</param>
            public bool Equals(Group02Key other)
            {
                if (ReferenceEquals(null, other))
                {
                    return false;
                }
                if (ReferenceEquals(this, other))
                {
                    return true;
                }

                return Key == other.Key && string.Equals(Value, other.Value);
            }
        }

        #endregion

        public static void Except01()
        {
            /*既定の等値比較子を使用して値を比較することにより、2 つのシーケンス(集合)の差集合を生成します*/

            /*差集合=集合Aから、集合Bを引いた集合*/

            { /*非LINQ*/

                var result = new List<string>();

                foreach (var sourceAValue in SourceA.Values)
                {
                    if (SourceB.Values.Contains(sourceAValue) == false)
                    {
                        result.Add(sourceAValue);
                    }
                }
            }

            { /*LINQ*/

                var result = SourceA.Values.Except(SourceB.Values);
            }
        }

        public static void ElementAtDefault01()
        {
            /*シーケンス(集合)内の指定したインデックス位置にある要素を返します。インデックスが範囲外の場合は既定値を返します。*/

            /*サンプル 15番目の要素を取得します。*/

            { /*非LINQ*/

                string result;
                var index = 15;

                if (SourceA.Values.Count - 1 >= index)
                {
                    result = SourceA[index];
                }
                else
                {
                    result = default(string);
                }
            }

            { /*LINQ*/

                var result = SourceA.Values.ElementAtOrDefault(15);
            }
        }

        public static void ElementAt01()
        {
            /*シーケンス(集合)内の指定されたインデックス位置にある要素を返します。*/

            /* 2番目の要素を取得します。*/

            var data = new List<int>()
                       {
                           1
                           , 2
                           , 3
                       };

            var enumrable = (IEnumerable<int>)data;


            { /*非LINQ*/
                /*Ienumrableにはインデックスで取得するメソッドが無いので、一度変換が必要*/
                var result = enumrable.ToList()[1];
            }

            { /*LINQ*/


                var result = enumrable.ElementAt(1);
            }
        }

        public static void Distinct01()
        {
            /*重複した要素を排除する*/

            { /*非LINQ*/

                var result = new List<string>();

                foreach (var element in margedNames)
                {
                    if (result.Contains(element) == false)
                    {
                        result.Add(element);
                    }
                }
            }

            { /*LINQ*/

                var result = margedNames.Distinct();
            }
        }

        public static void DefaultIfEmpty01()
        {
            /*集合を返します。もしも要素がない場合は指定した要素を返します。*/

            { /*非LINQ*/

                var result = new List<string>();

                foreach (var sourceCValue in SourceC.Values)
                {
                    result.Add(sourceCValue);
                }

                if (result.Count == 0)
                {
                    result.Add("default");
                }
            }

            { /*LINQ*/

                var result = SourceC.Values.DefaultIfEmpty("default");
            }


            /*あるばあいの結果*/

            {/*LINQ*/

                var result = SourceA.Values.DefaultIfEmpty("default");
            }
        }

        public static void DefaultIfEmpty02()
        {
            /*集合を返します。もしも要素がない場合は（戻り値の型の）デフォルト値を返します。*/

            { /*非LINQ*/

                var result = new List<int>();

                foreach (var sourceCKey in SourceC.Keys)
                {
                    result.Add(sourceCKey);
                }

                if (result.Count == 0)
                {
                    result.Add(default(int));
                }
            }

            { /*LINQ*/

                var result = SourceC.Keys.DefaultIfEmpty();
            }
        }

        /*集合の型を変換する。*/
        public static void Cast01()
        {
            /*番号を、objectでのListに変換する*/

            { /*非LINQ版*/

                var result = new List<object>();

                foreach (var element in SourceA.Keys)
                {
                    result.Add(element);
                }
            }

            { /*LINQ*/

                var result = SourceA.Keys.Cast<object>();
            }
        }

        /*集合を連結する*/
        public static void Concat01()
        {

            /*サンプル　： sourceA集合と sourceB集合を　連結する*/

            { /*非LINQ*/

                var result = new List<KeyValuePair<int, string>>();

                foreach (var keyvaluepair in SourceA)
                {
                    result.Add(keyvaluepair);
                }

                foreach (var keyvaluepair in SourceB)
                {
                    result.Add(keyvaluepair);
                }
            }

            { /*LINQ*/

                var result = SourceA.Concat(SourceB);
            }
        }

        /*指定した要素が、集合に含まれているか否かを返す。*/
        public static void Contains01()
        {
            /*名前集合に"hoge"が含まれているかを返す。*/

            /*非LINQ*/
            {
                var result = false;

                foreach (var element in SrcNames)
                {
                    if (element == "hoge")
                    {
                        result = true;
                        break;
                    }
                }
            }

            /*LINQ*/
            {
                var result = SrcNames.Contains("hoge");
            }
        }

        #endregion

        #region 評価

        private static void SequenceEqual02()
        {
            /*指定の比較子で要素を比較することで、2 つのシーケンス(集合)が等しいかどうかを判断します*/
            var srcA = SourceA.Values.ToList();
            var srcB = SourceB.Values.ToList();

            { /*非LINQ*/

                var result = true;
                var comparer = new StringLengthComparer();

                if (srcA.Count != srcB.Count)
                {
                    result = false;
                }
                else
                {
                    for (var i = 0; i < srcA.Count; i++)
                    {
                        if (comparer.Equals(srcA[i], srcB[i]) == false)
                        {
                            result = false;
                            break;
                        }
                    }
                }
            }

            { /*LINQ*/

                var result = srcA.SequenceEqual(srcB, new StringLengthComparer());
            }
        }

        private class StringLengthComparer : IEqualityComparer<string>
        {
            /// <summary>指定したオブジェクトが等しいかどうかを判断します。</summary>
            /// <returns>指定したオブジェクトが等しい場合は true。それ以外の場合は false。</returns>
            /// <param name="x">比較対象の <paramref name="T" /> 型の第 1 オブジェクト。</param>
            /// <param name="y">比較対象の <paramref name="T" /> 型の第 2 オブジェクト。</param>
            public bool Equals(string x, string y)
            {
                return x.Length.Equals(y.Length);
            }

            /// <summary>指定したオブジェクトのハッシュ コードを返します。</summary>
            /// <returns>指定したオブジェクトのハッシュ コード。</returns>
            /// <param name="obj">ハッシュ コードが返される対象の <see cref="T:System.Object" />。</param>
            /// <exception cref="T:System.ArgumentNullException">
            ///     <paramref name="obj" /> の型が参照型で、<paramref name="obj" /> が null です。
            /// </exception>
            public int GetHashCode(string obj)
            {
                return obj.GetHashCode();
            }
        }

        private static void SequenceEqual01()
        {
            /*標準の比較子で要素を比較することで、2 つのシーケンス(集合)が等しいかどうかを判断します*/
            var srcA = SourceA.Keys.ToList();
            var srcB = SourceB.Keys.ToList();

            { /*非LINQ*/

                var result = true;

                if (srcA.Count != srcB.Count)
                {
                    result = false;
                }
                else
                {
                    for (var i = 0; i < srcA.Count; i++)
                    {
                        if (srcA[i].Equals(srcB[i]) == false)
                        {
                            result = false;
                            break;
                        }
                    }
                }
            }

            { /*LINQ*/

                var result = srcA.SequenceEqual(srcB);
            }
        }

        /*条件が合致する、いずれかの要素があるか否かを調べる*/
        public static void Any01()
        {
            /*サンプル:名前に「すずき」が含まれるかを調べる*/

            { /*非LINQ*/
                var result = false;

                foreach (var element in SrcNames)
                {
                    if (element.Equals("すずき"))
                    {
                        result = true;
                        break;
                    }
                }
            }


            { /*LINQ*/

                var result = SrcNames.Any(element =>
                                              {
                                                  if (element.Equals("すずき"))
                                                  {
                                                      return true;
                                                  }
                                                  else
                                                  {
                                                      return false;
                                                  }

                                              });
            }

            { /*LINQ*/

                var result = SrcNames.Any(element => element.Equals("すずき"));
            }
        }

        /*要素があるか否かを調べる*/
        public static void Any02()
        {
            /*要素があるか否かを調べる*/

            { /*非LINQ*/

                var result = false;

                if (SrcNames.Count() > 0)
                {
                    result = true;
                }
            }

            { /*LINQ*/

                var result = SrcNames.Any();
            }
        }

        /*全ての要素が条件を満たすかを調べる*/
        public static void All01()
        {
            /*サンプル:全ての番号が５より大きいかを調べる*/

            { /*LINQ使わない場合*/

                var result = true;

                foreach (var element in SrcNumbers)
                {
                    if (element <= 5)
                    {
                        result = false;
                        break;
                    }
                }
            }

            { /*LINQの場合*/

                var result = SrcNumbers.All(element =>
                    {
                        if (element > 5)
                        {
                            return true;
                        }

                        return false;
                    });
            }

            { /*LINQ*/

                var result = SrcNumbers.All(element => element > 5);

            }
        }

        #endregion

        #region 集計

        public static void Sum02()
        {
            //各要素に対して変換関数を呼び出して取得する値の合計を計算します。

            /*サンプル:名称の長さの合計を求めます*/

            { /*非LINQ*/

                var result = 0;

                foreach (var element in SrcNames)
                {
                    result = result + element.Length;
                }
            }

            { /*LINQ*/
                var result = SrcNames.Sum(element => element.Length);
            }
        }

        public static void Sum01()
        {
            //値のシーケンス(集合)の合計を計算します。

            { /*非LINQ*/
                var result = 0;

                foreach (var element in SrcNumbers)
                {
                    result = result + element;
                }
            }

            { /*LINQ*/

                var result = SrcNumbers.Sum();
            }
        }

        private static void Max01()
        {
            //シーケンス(集合)の最大値を返します。
            { /*非LINQ*/

                var result = int.MinValue;

                foreach (var element in SrcNumbers)
                {
                    if (result < element)
                    {
                        result = element;
                    }
                }
            }

            { /*LINQ*/

                var result = SrcNumbers.Max();
            }
        }

        private static void Max02()
        {
            //シーケンス(集合)の各要素に対して変換関数を呼び出し、最大値を返します。

            { /*非LINQ*/
                var result = int.MinValue;

                foreach (var element in SrcNames)
                {
                    var length = element.Length;

                    if (result < length)
                    {
                        result = length;
                    }
                }
            }

            { /*LINQ*/
                var result = SrcNames.Max(element => element.Length);
            }
        }

        private static void Min01()
        {
            //シーケンス(集合)の最小値を返します。

            { /*非LINQ*/

                var result = int.MaxValue;

                foreach (var element in SrcNumbers)
                {
                    if (result < element)
                    {
                        result = element;
                    }
                }
            }

            { /*LINQ*/

                var result = SrcNumbers.Min();
            }
        }

        private static void Min02()
        {
            //シーケンス(集合)の各要素に対して変換関数を呼び出し、結果の最小値を返します。

            { /*非LINQ*/

                var result = int.MaxValue;

                foreach (var element in SrcNames)
                {
                    var length = element.Length;

                    if (length < result)
                    {
                        result = length;
                    }
                }
            }

            { /*LINQ*/

                var result = SrcNames.Min(element => element.Length);
            }
        }

        /*平均値を求める*/
        public static void Average()
        {
            /*全ての番号の平均値を取得する*/

            { /*LINQ使わない*/

                decimal result = 0;
                decimal sum = 0;
                decimal count = 0;

                count = SrcNumbers.Count();

                if (count > 0)
                {
                    foreach (var element in SrcNumbers)
                    {
                        sum = sum + element;
                        result = sum / count;
                    }
                }
            }

            { /*LINQ*/

                var result = SrcNumbers.Average();
            }
        }

        /*集約処理*/
        public static void Aggregate01()
        {
            /*サンプル：全ての番号の累計を取得する*/

            { /*LINQ使わない場合*/
                var result = 0;

                foreach (var element in SrcNumbers)
                {
                    result = result + element;
                }
            }

            { /*LINQで書いた場合*/

                var result = SrcNumbers.Aggregate((summary, element) =>
                                                      {
                                                          var work = summary + element;
                                                          return work;
                                                      });

                var result2 = SrcNumbers.Aggregate((summary, element) => summary + element);
            }
        }

        public static void Aggregate02()
        {
            /*サンプル 100に対して、全ての番号の累計を加算する*/

            { /*LINQ使わない場合*/
                var result = 100;

                foreach (var element in SrcNumbers)
                {
                    result = result + element;
                }
            }

            { /*LINQの場合*/

                var result = SrcNumbers.Aggregate(100, (summary, element) =>
                    {
                        var work = summary + element;
                        return work;
                    });

                var result2 = SrcNumbers.Aggregate(100, (summary, element) => summary + element);
            }
        }

        #region aggr3

        public static void Aggregate03()
        {
            /*サンプル：全ての番号の、{件数と累計}を取得する*/

            { /*LINQで書かない場合*/
                var result = new Aggr3Result();

                foreach (var element in SrcNumbers)
                {
                    result.Count = result.Count + 1;
                    result.Sum = result.Sum + element;
                }
            }

            { /*LINQで書いた場合*/

                var result = SrcNumbers.Aggregate(new Aggr3Result(), (summary, element) =>
                                                                         {
                                                                             summary.Count = summary.Count + 1;
                                                                             summary.Sum = summary.Sum + element;

                                                                             return summary;
                                                                         });
            }

            { /*LINQ その２(クラスを別定義しない)*/

                var result = SrcNumbers.Aggregate(new
                                                  {
                                                      Count = 0
                                                      ,
                                                      Sum = 0
                                                      ,
                                                      multiple = 0
                                                  }, (summary, element) => new
                                                                           {
                                                                               Count = summary.Count + 1
                                                                               ,
                                                                               Sum = summary.Sum + element
                                                                               ,
                                                                               multiple = summary.Count*2,
                                                                           });

            }
        }

        public class Aggr3Result
        {
            public int Count;
            public int Sum;
        }

        #endregion

        public static void Count01()
        {
            /*要素の件数を返します。*/

            var data = new List<int>()
                       {
                           1
                           , 2
                           , 3
                           , 4
                           , 5
                       };

            var enumrable = (IEnumerable<int>)data;

            { /*非LINQ*/

                var result = enumrable.ToList().Count;
            }

            { /*LINQ版*/

                /*IEnumrableインタフェースに対して件数が取得可能*/

                var result = enumrable.Count();
            }
        }

        public static void Count02()
        {
            /*条件を満たす、指定されたシーケンス(集合)内の要素の数を表す数値を返します。*/

            /*サンプル：偶数の番号の数を取得する*/

            { /*非LINQ*/

                var result = 0;

                foreach (var element in SrcNumbers)
                {
                    if (element % 2 == 0)
                    {
                        result = result + 1;
                    }
                }
            }

            {/*LINQ*/
                var result = SrcNumbers.Count(element =>
                    {
                        return element % 2 == 0;
                    });
            }

            { /*LINQ*/

                var result = SrcNumbers.Count(element => element % 2 == 0);
            }
        }

        #endregion
    }
}