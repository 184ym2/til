using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQサンプル.cs
{
    /// <summary>
    /// 射影関連のLINQ
    /// </summary>
    static class Projection
    {
        public static void Zip01()
        {
            // 2つのシーケンス(集合)の対応する要素に対して、1 つの指定した関数を適用し、結果として 1 つのシーケンス(集合)を生成します。

            { /*非LINQ*/

                var result = new List<string>();

                var maxSequence = TeamList.Aclass_personnel.Values.Count;

                if (maxSequence > TeamList.Bclass_personnel.Count)
                {
                    maxSequence = TeamList.Bclass_personnel.Count;
                }

                for (var i = 0; i < maxSequence; i++)
                {
                    result.Add(TeamList.Aclass_personnel.Values.ToList()[i] + " " + TeamList.Bclass_personnel.Values.ToList()[i]);
                }
            }

            { /*LINQ*/

                var result = TeamList.Aclass_personnel.Values.Zip(TeamList.Bclass_personnel.Values, (elementA, elementB) => elementA + " " + elementB);
            }


        }

        public static void Where01()
        {
            //述語に基づいて値のシーケンス(集合)をフィルター処理します。

            { /*非LINQ*/

                var result = new List<string>();

                foreach (var element in TeamList.SrcNames_A)
                {
                    if (element.Contains("ま"))
                    {
                        result.Add(element);
                    }
                }
            }

            { /*LINQ*/

                var result = TeamList.SrcNames_A.Where(element => element.Contains("ま"));
            }

            { /*LINQ*/

                var result = TeamList.SrcNames_A.Where(element => element.Contains("ま"))
                                     .Where(element => element.Contains("と"));

            }

            { /*LINQ*/

                var result = from a in TeamList.SrcNames_A.Where(element => element.Contains("ま"))
                                                .Where(element => element.Contains("と"))
                             join b in TeamList.Bclass_personnel.Values
                             on a equals b
                             where b.Contains("ま")
                             select b;

            }

        }

        public static void Union02()
        {
            /*指定された比較子を使用して 2 つのシーケンス(集合)の和集合を生成します。*/

            /*値が同じだった場合、同一とする比較子を使用*/

            { /*非LINQ*/

                var result = new List<int>();
                var compare = new ValueComparer();

                foreach (var element in TeamList.Aclass_personnel.Keys)
                {
                    if (result.Contains(element, compare) == false)
                    {
                        result.Add(element);
                    }
                }

                foreach (var element in TeamList.Bclass_personnel.Keys)
                {
                    if (result.Contains(element, compare) == false)
                    {
                        result.Add(element);
                    }
                }
            }

            { /*LINQ*/

                var result = TeamList.Aclass_personnel.Keys.Union(TeamList.Bclass_personnel.Keys, new ValueComparer());
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

                foreach (var element in TeamList.Aclass_personnel.Values)
                {
                    if (result.Contains(element) == false)
                    {
                        result.Add(element);
                    }
                }

                foreach (var element in TeamList.Bclass_personnel.Values)
                {
                    result.Add(element);
                }
            }

            { /*LINQ*/

                var result = TeamList.Aclass_personnel.Values.Union(TeamList.Bclass_personnel.Values);
            }
        }

        public static void ToDictionary01()
        {
            //指定されたキー セレクター関数および要素セレクター関数に従って、Dictionary<TKey,TValue> から IEnumerable<T> を作成します。

            { /*非LINQ*/

                var result = new Dictionary<int, string>();

                foreach (var element in TeamList.Aclass_personnel)
                {
                    result.Add(element.Key, element.Value);
                }
            }

            { /*LINQ*/

                var result = TeamList.Aclass_personnel.ToDictionary(element => element.Key
                                                , element => element.Value);
            }
        }

        public static void TakeWhile01()
        {
            //指定された条件が満たされる限り、シーケンス(集合)から要素を返します。

            { /*非LINQ*/
                var result = new List<int>();

                foreach (var element in TeamList.SrcNumbers_A)
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
                var result = TeamList.SrcNumbers_A.TakeWhile(element => element < 3);
            }
        }

        public static void Take01()
        {
            //シーケンス(集合)の先頭から、指定された数の連続する要素を返します。

            { /*非LINQ*/

                var result = new List<string>();

                for (var i = 0; i < 2; i++)
                {
                    if (TeamList.SrcNames_A.Count == i)
                    {
                        break;
                    }

                    result.Add(TeamList.SrcNames_A[i]);
                }
            }

            { /*LINQ*/

                var result = TeamList.SrcNames_A.Take(2);
            }

            //シーケンス(集合)の先頭から、指定された数の連続する要素を返します。
        }

        public static void SkipWhile01()
        {
            //指定された条件が満たされる限り、シーケンス(集合)の要素をバイパスした後、残りの要素を返します。

            //サンプル: 5以下をバイパス

            { /*非LINQ*/

                var result = new List<int>();

                foreach (var element in TeamList.SrcNumbers_A)
                {
                    if (element < 5)
                    {
                        continue;
                    }

                    result.Add(element);
                }
            }

            { /*LINQ*/
                var result = TeamList.SrcNumbers_A.SkipWhile(element => element < 5);
            }
        }

        public static void Skip01()
        {
            //シーケンス(集合)内の指定された数の要素をバイパスし、残りの要素を返します。

            /*サンプル：はじめに５つをスキップします。*/

            { /*非LINQ*/

                var result = new List<string>();

                for (var i = 5; i < TeamList.SrcNames_A.Count; i++)
                {
                    result.Add(TeamList.SrcNames_A[i]);
                }
            }

            { /*LINQ*/

                var result = TeamList.SrcNames_A.Skip(5);
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

                foreach (var element in TeamList.SrcNames_A)
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

                var result = TeamList.SrcNames_A.SingleOrDefault(element => element.Equals("すずき"));
            }
        }

        public static void Single02()
        {
            //指定された条件を満たす、シーケンス(集合)の唯一の要素を返し、そのような要素が複数存在する場合は例外をスローします。

            { /*非LINQ*/

                string result;
                var work = new List<string>();

                foreach (var element in TeamList.SrcNames_A)
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

                var result = TeamList.SrcNames_A.Single(element => element.Equals("すずき"));
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

        public static void Select02()
        {
            /*シーケンス(集合)の各要素をインデックス付きで新しいフォームに射影します。*/

            { /*非LINQ*/

                var result = new Dictionary<int, string>();

                var index = 0;

                foreach (var element in TeamList.SrcNames_A)
                {
                    result.Add(index, element);

                    index = index + 1;
                }
            }

            { /*LINQ*/

                var result = TeamList.SrcNames_A.Select((element, index) => new
                {
                    index
                                                                     ,
                    element
                });
            }
        }

        public static void Select01()
        {
            /*名前だけのリストを作成します。*/

            { /*非LINQ*/

                var result = new List<string>();

                foreach (var element in TeamList.Aclass_personnel)
                {
                    result.Add(element.Value);
                }
            }

            { /*LINQ*/

                var result = TeamList.Aclass_personnel.Select(element => element.Value);
            }

            {/*LINQ 複数要素抜き出し*/
                var result = (from e in TeamList.Aclass_personnel
                              select new
                              {
                                  e.Key
                                         ,
                                  e.Value
                              });

            }

            { /*LINQ 独自クラスに抜き出し*/
                var result = (from e in TeamList.Aclass_personnel
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

        public static void OfType01()
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

                foreach (var element in TeamList.SrcNames_A)
                {
                    if (element.Contains("い"))
                    {
                        result = result + 1;
                    }
                }
            }

            { /*LINQ*/

                var result = TeamList.SrcNames_A.LongCount(element => element.Contains("い"));
            }
        }

        public static void LongCount01()
        {
            /*シーケンス(集合)内の要素の合計数を表す Int64 を返します。*/

            { /*非LINQ*/

                var result = (long)TeamList.Aclass_personnel.Count;
            }

            { /*LINQ*/

                var result = TeamList.Aclass_personnel.LongCount();
            }
        }

        public static void LastOrDefault02()
        {
            /*条件を満たす、シーケンス(集合)の最後の要素を返します。このような要素が見つからない場合は既定値を返します。*/

            { /*非LINQ*/
                var found = false;
                string result;

                foreach (var element in TeamList.SrcNames_A)
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

                var result = TeamList.SrcNames_A.LastOrDefault(element => element.Equals("とおくにA"));
            }
        }

        public static void LastOrDefault01()
        {
            /*シーケンス(集合)の最後の要素を返します。シーケンス(集合)に要素が含まれていない場合は既定値を返します。*/

            { /*非LINQ*/

                string result;

                if (TeamList.SrcNames_A.Count == 0)
                {
                    result = default(string);
                }
                else
                {
                    result = TeamList.SrcNames_A[TeamList.SrcNames_A.Count];
                }
            }

            { /*LINQ*/

                var result = TeamList.SrcNames_A.LastOrDefault();
            }
        }

        public static void Last02()
        {
            /*指定された条件を満たす、シーケンス(集合)の最後の要素を返します。*/

            { /*非LINQ*/

                var found = false;
                string result = null;

                foreach (var element in TeamList.SrcNames_A)
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

                var result = TeamList.SrcNames_A.Last(element => element.Equals("たなか"));
            }
        }

        public static void Last01()
        {
            /*最後の要素を取得します。*/

            { /*非LINQ*/

                if (TeamList.Aclass_personnel.Count == 0)
                {
                    throw new InvalidOperationException();
                }

                var result = TeamList.Aclass_personnel[TeamList.Aclass_personnel.Count];
            }

            { /*LINQ*/

                var result = TeamList.Aclass_personnel.Last();
            }
        }

        public static void Intersect01()
        {
            /*既定の等値比較子を使用して値を比較することにより、2 つのシーケンス(集合)の積集合を生成します。*/

            /*サンプル：ソースA・ソースBから　同じ名前のものを抜き出します。*/

            { /*非LINQ*/

                var result = new List<string>();

                foreach (var sourceAValue in TeamList.Aclass_personnel.Values)
                {
                    foreach (var sourceBValue in TeamList.Bclass_personnel.Values)
                    {
                        if (sourceAValue == sourceBValue)
                        {
                            result.Add(sourceAValue);
                        }
                    }
                }
            }

            { /*LINQ*/

                var result = TeamList.Aclass_personnel.Values.Intersect(TeamList.Bclass_personnel.Values);
            }
        }

        public static void InnerJoin()
        {
            { /*LINQ*/

                /*sourceAの集合と、sourceBの集合を、ValueでINNER JOIN した結果を返す。*/

                var result = from sA in TeamList.Aclass_personnel
                             join sB in TeamList.Bclass_personnel
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

                var result = from sA in TeamList.Aclass_personnel
                             join sB in TeamList.Bclass_personnel
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

                var result = from sA in TeamList.Aclass_personnel
                             join sB in TeamList.Bclass_personnel
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

                var result = from sA in TeamList.Aclass_personnel
                             join sB in TeamList.Bclass_personnel
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

                if (TeamList.SrcNumbers_A.Count == 0)
                {
                    throw new InvalidOperationException();
                }

                var result = TeamList.SrcNumbers_A[0];
            }

            { /*LINQ*/

                var result = TeamList.SrcNumbers_A.First();
            }
        }

        public static void First02()
        {
            /*指定された条件を満たす、シーケンス(集合)の最初の要素を返します。*/

            /*サンプル 初めに現れる４の値を取得します。*/

            { /*非LINQ*/

                int? result = null;

                foreach (var element in TeamList.SrcNumbers_A)
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

                var result = TeamList.SrcNumbers_A.First(element => element == 4);
            }
        }

        public static void FirstOrDefault01()
        {
            /*シーケンス(集合)の最初の要素を返します。シーケンス(集合)に要素が含まれていない場合は既定値を返します。*/

            { /*非LINQ*/

                int result;

                if (TeamList.SrcNumbers_A.Count == 0)
                {
                    result = default(int);
                }
                else
                {
                    result = TeamList.SrcNumbers_A[0];
                }
            }

            { /*LINQ*/

                var result = TeamList.SrcNumbers_A.FirstOrDefault();
            }
        }

        public static void FirstOrDefault02()
        {
            /*条件を満たす、シーケンス(集合)の最初の要素を返します。このような要素が見つからない場合は既定値を返します。*/

            /*サンプル：はじめにみつかった２５の値を返します。*/

            { /*非LINQ*/

                int? result = null;

                foreach (var srcNumber in TeamList.SrcNumbers_A)
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

                var result = TeamList.SrcNumbers_A.FirstOrDefault(element => element == 25);
            }
        }

        public static void Group01()
        {
            /*指定したキー値ごとの要素を集合化（グループ化）します。*/

            { /*非LINQ*/

                var result = new Dictionary<int, List<KeyValuePair<int, string>>>();

                foreach (var pair in TeamList.MargedSource_AB)
                {
                    if (result.ContainsKey(pair.Key) == false)
                    {
                        result.Add(pair.Key, new List<KeyValuePair<int, string>>());
                    }

                    result[pair.Key].Add(pair);
                }
            }

            { /*LINQ*/

                var result = TeamList.MargedSource_AB.GroupBy(e => e.Key);
            }
        }

        #region group2

        public static void Group02()
        {
            /*指定した(複数の)キーごとの要素を集合化(グループ化)します。*/

            { /*非LINQ*/

                var result = new Dictionary<Group02Key, List<KeyValuePair<int, string>>>();

                foreach (var pair in TeamList.MargedSource_AB)
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

                var result = TeamList.MargedSource_AB.GroupBy(e => new
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

                foreach (var sourceAValue in TeamList.Aclass_personnel.Values)
                {
                    if (TeamList.Bclass_personnel.Values.Contains(sourceAValue) == false)
                    {
                        result.Add(sourceAValue);
                    }
                }
            }

            { /*LINQ*/

                var result = TeamList.Aclass_personnel.Values.Except(TeamList.Bclass_personnel.Values);
            }
        }

        public static void ElementAtDefault01()
        {
            /*シーケンス(集合)内の指定したインデックス位置にある要素を返します。インデックスが範囲外の場合は既定値を返します。*/

            /*サンプル 15番目の要素を取得します。*/

            { /*非LINQ*/

                string result;
                var index = 15;

                if (TeamList.Aclass_personnel.Values.Count - 1 >= index)
                {
                    result = TeamList.Aclass_personnel[index];
                }
                else
                {
                    result = default(string);
                }
            }

            { /*LINQ*/

                var result = TeamList.Aclass_personnel.Values.ElementAtOrDefault(15);
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

                foreach (var element in TeamList.MargedNames_AB)
                {
                    if (result.Contains(element) == false)
                    {
                        result.Add(element);
                    }
                }
            }

            { /*LINQ*/

                var result = TeamList.MargedNames_AB.Distinct();
            }
        }

        public static void DefaultIfEmpty01()
        {
            /*集合を返します。もしも要素がない場合は指定した要素を返します。*/

            { /*非LINQ*/

                var result = new List<string>();

                foreach (var sourceCValue in TeamList.SourceC.Values)
                {
                    result.Add(sourceCValue);
                }

                if (result.Count == 0)
                {
                    result.Add("default");
                }
            }

            { /*LINQ*/

                var result = TeamList.SourceC.Values.DefaultIfEmpty("default");
            }


            /*あるばあいの結果*/

            {/*LINQ*/

                var result = TeamList.Aclass_personnel.Values.DefaultIfEmpty("default");
            }
        }

        public static void DefaultIfEmpty02()
        {
            /*集合を返します。もしも要素がない場合は（戻り値の型の）デフォルト値を返します。*/

            { /*非LINQ*/

                var result = new List<int>();

                foreach (var sourceCKey in TeamList.SourceC.Keys)
                {
                    result.Add(sourceCKey);
                }

                if (result.Count == 0)
                {
                    result.Add(default(int));
                }
            }

            { /*LINQ*/

                var result = TeamList.SourceC.Keys.DefaultIfEmpty();
            }
        }

        /*集合の型を変換する。*/
        public static void Cast01()
        {
            /*番号を、objectでのListに変換する*/

            { /*非LINQ版*/

                var result = new List<object>();

                foreach (var element in TeamList.Aclass_personnel.Keys)
                {
                    result.Add(element);
                }
            }

            { /*LINQ*/

                var result = TeamList.Aclass_personnel.Keys.Cast<object>();
            }
        }

        /*集合を連結する*/
        public static void Concat01()
        {

            /*サンプル　： sourceA集合と sourceB集合を　連結する*/

            { /*非LINQ*/

                var result = new List<KeyValuePair<int, string>>();

                foreach (var keyvaluepair in TeamList.Aclass_personnel)
                {
                    result.Add(keyvaluepair);
                }

                foreach (var keyvaluepair in TeamList.Bclass_personnel)
                {
                    result.Add(keyvaluepair);
                }
            }

            { /*LINQ*/

                var result = TeamList.Aclass_personnel.Concat(TeamList.Bclass_personnel);
            }
        }

        /*指定した要素が、集合に含まれているか否かを返す。*/
        public static void Contains01()
        {
            /*名前集合に"hoge"が含まれているかを返す。*/

            /*非LINQ*/
            {
                var result = false;

                foreach (var element in TeamList.SrcNames_A)
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
                var result = TeamList.SrcNames_A.Contains("hoge");
            }
        }
    }
}
