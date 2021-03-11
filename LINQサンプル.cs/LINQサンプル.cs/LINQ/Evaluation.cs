using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQサンプル.cs
{
    /// <summary>
    /// 評価関連のLINQ
    /// </summary>
    public static class Evaluation
    {

        public static List<string> Aclass { get { return TeamList.Aclass_personnel.Values.ToList(); } }
        public static List<string> Bclass { get { return TeamList.Bclass_personnel.Values.ToList(); } }

        /// <summary>
        /// シーケンス（集合）のすべての要素が条件を満たすかどうかを決定します
        /// </summary>
        public static void All01()
        {
            // サンプル：全ての番号が５より大きいかを調べる

            {
                // 非LINQ
                var result = true;

                foreach (var numbers in TeamList.SrcNumbers_A)
                {
                    if (numbers <= 5)
                    {
                        result = false;
                        break;
                    }
                }
            }

            {
                // LINQ
                var result = TeamList.SrcNumbers_A.All(numbers =>
                {
                    if (numbers > 5)
                    {
                        return true;
                    }

                    return false;
                });
            }

            { // LINQ

                var result = TeamList.SrcNumbers_A.All(numbers => numbers > 5);

            }
        }

        /// <summary>
        /// シーケンス（集合）がすべての要素を含めるかどうかを決定します：集合に要素があるかどうか
        /// </summary>
        public static void Any01()
        {


            {
                // 非LINQ
                var result = false;
                if (TeamList.SrcNames_A.Count() > 0)
                {
                    result = true;
                }
            }

            {
                // LINQ：Countメソッドは全件数えて結果を返すため、あるかないかを判断するAnyメソッドの方が早い
                var result = TeamList.SrcNames_A.Any();
            }
        }

        /// <summary>
        /// シーケンス（集合）の要素が任意の条件を満たすかどうかを決定します
        /// </summary>
        public static void Any02()
        {
            // サンプル：名前に「太刀川隊」が含まれるかを調べる

            {
                // 非LINQ
                var result = false;

                foreach (var element in TeamList.SrcNames_A)
                {
                    if (element.Equals("太刀川隊"))
                    {
                        result = true;
                        break;
                    }
                }
            }

            {
                // LINQ
                var result = TeamList.SrcNames_A.Any(element =>
                {
                    if (element.Equals("太刀川隊"))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                });
            }

            {
                // LINQ：Anyメソッドの引数（=任意の条件）として、引数T型・戻り値boolのデリゲートを渡す
                var result = TeamList.SrcNames_A.Any(element => element.Equals("太刀川隊"));
            }
        }

        /// <summary>
        /// Ex：指定したオブジェクトが等しいかどうかを判断するクラス
        /// </summary>
        private class StringLengthComparer : IEqualityComparer<string>
        {
            /// <summary>Ex：このインスタンスと、指定した別の System.String の文字数が同一かどうかを判断します。</summary>
            /// <returns>Ex：指定したオブジェクトが等しい場合は true。それ以外の場合は false。</returns>
            /// <param name="x">Ex：比較対象の <paramref name="T" /> 型の第 1 オブジェクト。</param>
            /// <param name="y">Ex：比較対象の <paramref name="T" /> 型の第 2 オブジェクト。</param>
            public bool Equals(string x, string y)
            {
                return x.Length.Equals(y.Length);
            }

            /// <summary>Ex：指定したオブジェクトのハッシュ コードを返します。</summary>
            /// <returns>Ex：指定したオブジェクトのハッシュ コード。</returns>
            /// <param name="obj">Ex：ハッシュ コードが返される対象の <see cref="T:System.Object" />。</param>
            /// <exception cref="T:System.ArgumentNullException">
            /// <paramref name="obj" /> の型が参照型で、<paramref name="obj" /> が null です。
            /// </exception>
            public int GetHashCode(string obj)
            {
                return obj.GetHashCode();
            }
        }

        /// <summary>
        /// 型に対して【既定の等値比較子】を使用して要素を比較することで、2 つのシーケンス（集合）が等しいかどうかを決定します
        /// </summary>
        public static void SequenceEqual01()
        {
            {
                // 非LINQ
                var result = true;

                if (Aclass.Count != Bclass.Count)
                {
                    result = false;
                }
                else
                {
                    for (var i = 0; i < Aclass.Count; i++)
                    {
                        // AclassとBclassの文字列が同一でない場合、false
                        if (Aclass[i].Equals(Bclass[i]) == false)
                        {
                            result = false;
                            break;
                        }
                    }
                }
            }

            {
                // LINQ：SequenceEqualメソッドの引数に比較したい要素を渡す
                var result = Aclass.SequenceEqual(Bclass);
            }
        }

        /// <summary>
        /// 型に対して【指定の等値比較子：IEqualityComparer】を使用して要素を比較することで、2 つのシーケンス（集合）が等しいかどうかを決定します
        /// </summary>
        public static void SequenceEqual02()
        {
            {
                // 非LINQ
                var result = true;
                var comparer = new StringLengthComparer();

                if (Aclass.Count != Bclass.Count)
                {
                    result = false;
                }
                else
                {
                    for (var i = 0; i < Aclass.Count; i++)
                    {
                        // AclassとBclassの文字数が同一でない場合、false
                        if (comparer.Equals(Aclass[i], Bclass[i]) == false)
                        {
                            result = false;
                            break;
                        }
                    }
                }
            }

            {
                // LINQ：SequenceEqualメソッドの引数に比較したい要素と比較子を渡す
                var result = Aclass.SequenceEqual(Bclass, new StringLengthComparer());
            }
        }




    }
}
