using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQサンプル.cs.LINQ
{
    /// <summary>
    /// 集計関連のLINQ
    /// </summary>
    public class Aggregation
    {
        private List<int> SrcNumbers_A { get { return TeamList.SrcNumbers_A; } }

        private List<string> SrcNames_A { get { return TeamList.SrcNames_A; } }

        /// <summary>
        /// シーケンス（集合）の最大値を返します
        /// </summary>
        public void Max01()
        {
            {
                // 非LINQ：intの最小値と要素を比較 → 比較した要素が大きい場合、resultに代入 → resultに代入した要素と新しい要素を比較
                var result = int.MinValue /*-2147483647*/;

                foreach (var element in SrcNumbers_A)
                {
                    if (element /*10*/ > result /*-2147483647*/)
                    {
                        result /*10*/ = element /*10*/;
                    }
                }
            }

            {
                // LINQ
                var result = SrcNumbers_A.Max();
            }
        }

        /// <summary>
        /// シーケンス（集合）の各要素に対して変換関数を呼び出し、最大値を返します
        /// </summary>
        public void Max02()
        {
            {
                // 非LINQ：intの最小値と要素を比較 → 比較した要素が大きい場合、resultに代入 → resultに代入した要素と新しい要素を比較
                var result = int.MinValue /*-2147483647*/;

                foreach (var element in SrcNames_A)
                {
                    var length = element.Length;

                    if (length /*10*/ > result /*-2147483647*/)
                    {
                        result /*10*/ = length /*10*/;
                    }
                }
            }

            {
                // LINQ
                var result = SrcNames_A.Max(element => element.Length);
            }
        }

        /// <summary>
        /// シーケンス（集合）の最小値を返します
        /// </summary>
        public void Min01()
        {
            {
                // 非LINQ：intの最大値と要素を比較 → 比較した要素が小さい場合、resultに代入 → resultに代入した要素と新しい要素を比較
                var result = int.MaxValue /*2147483647*/;

                foreach (var element in SrcNumbers_A)
                {
                    if (element /*10*/ < result /*2147483647*/ )
                    {
                        result /*10*/ = element /*10*/;
                    }
                }
            }

            {
                // LINQ
                var result = SrcNumbers_A.Min();
            }
        }

        /// <summary>
        /// シーケンス（集合）の各要素に対して変換関数を呼び出し、最小値を返します
        /// </summary>
        public void Min02()
        {
            {
                // 非LINQ：intの最小値と要素を比較 → 比較した要素が大きい場合、resultに代入 → resultに代入した要素と新しい要素を比較
                var result = int.MaxValue /*2147483647*/;

                foreach (var element in SrcNames_A)
                {
                    var length = element.Length;

                    if (length /*10*/ < result /*2147483647*/)
                    {
                        result /*10*/ = length /*10*/;
                    }
                }
            }

            {
                // LINQ
                var result = SrcNames_A.Min(element => element.Length);
            }
        }

        /// <summary>
        /// シーケンス（集合）の値の合計を計算します
        /// </summary>
        public void Sum01()
        {
            // サンプル：シーケンス（集合）の数を計算
            {
                // 非LINQ
                var result = 0;

                foreach (var element in SrcNumbers_A)
                {
                    result = result /*合計をストックしている*/ + element;

                    // そのままresultに代入すると、値の上書きになるから
                }
            }

            {
                // LINQ
                var result = SrcNumbers_A.Sum();
            }
        }

        /// <summary>
        /// シーケンス（集合）の各要素で変換関数を呼び出すことによって取得される値の合計を計算します
        /// </summary>
        public void Sum02()
        {
            // サンプル：シーケンス（集合）の文字数を計算
            {
                // 非LINQ
                var result = 0;

                foreach (var element in SrcNames_A)
                {
                    result = result /*合計をストックしている*/ + element.Length;

                    // そのままresultに代入すると、値の上書きになるから
                }
            }

            {
                // LINQ
                var result = SrcNames_A.Sum(element => element.Length);
            }
        }

        /// <summary>
        /// シーケンス（集合）の平均値を計算します
        /// </summary>
        public void Average()
        {
            {
                // 非LINQ（CountメソッドはLINQ）
                decimal result = 0;
                decimal sum = 0;

                decimal count = SrcNumbers_A.Count();

                if (count > 0)
                {
                    foreach (var element in SrcNumbers_A)
                    {
                        sum = sum /*合計をストックしている*/ + element;
                        result = sum / count;
                    }
                }
            }

            { 
                // LINQ
                var result = SrcNumbers_A.Average();
            }
        }

        /// <summary>
        /// シーケンスにアキュムレーター（演算装置による演算結果を累積する、すなわち総和を得るといったような計算に使う）関数を適用します
        /// </summary>
        public void Aggregate01()
        {
            // サンプル：全ての番号の累計（値の合計）を取得する

            { 
                // 非LINQ
                var result = 0;

                foreach (var element in SrcNumbers_A)
                {
                    result = result /*合計をストックしている*/ + element;
                }
            }

            { 
                // LINQ
                var result = SrcNumbers_A.Aggregate((summary /*0*/, element /*要素？*/) =>
                                                                        {
                                                                            var sum = summary + element;
                                                                            return sum;
                                                                        });

                var result2 = SrcNumbers_A.Aggregate((summary /*0*/, element /*要素？*/) => summary + element);
            }
        }

        /// <summary>
        /// シーケンスにアキュムレーター（演算装置による演算結果を累積する、すなわち総和を得るといったような計算に使う）関数を適用します
        /// 指定されたシード値が最初のアキュムレーター値として使用されます
        /// </summary>
        public void Aggregate02()
        {
            // サンプル：100に対して、全ての番号の累計（値の合計）を加算する

            {
                // 非LINQ
                var result = 100;

                foreach (var element in SrcNumbers_A)
                {
                    result = result + element;
                }
            }

            {
                // LINQ::
                var result = SrcNumbers_A.Aggregate(100, (summary /*100*/, element /*要素？*/) =>
                                                                             {
                                                                                 var sum = summary + element;
                                                                                 return sum;
                                                                             });

                var result2 = SrcNumbers_A.Aggregate(100, (summary /*100*/, element /*要素？*/) => summary + element);

                
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Aggregate03()
        {
            // サンプル：全ての番号の件数と累計（値の合計）を取得する

            { 
                // 非LINQ
                var result = new Aggr3Result();

                foreach (var element in SrcNumbers_A)
                {
                    result.Count = result.Count + 1;
                    result.Sum = result.Sum + element;
                }
            }

            {
                // LINQ
                var result = SrcNumbers_A.Aggregate(new Aggr3Result(), (summary /*Aggr3Result.cs*/, element /*要素？*/) =>
                                                                                           {
                                                                                               summary.Count = summary.Count + 1;
                                                                                               summary.Sum = summary.Sum + element;
                                                                                               return summary;
                                                                                           });
            }

            {
                // LINQ
                var result = SrcNumbers_A.Aggregate(new /*匿名型を作成*/
                {
                    Count = 0,
                    Sum = 0
                },
                (summary /*匿名型*/, element/*要素？*/) =>
                new
                {
                    Count = summary.Count + 1,
                    Sum = summary.Sum + element
                });
            }
        }

        /// <summary>
        /// Ex：アキュムレーターサンプル用クラス
        /// </summary>
        public class Aggr3Result
        {
            public int Count;
            public int Sum;
        }

        /// <summary>
        /// シーケンス（集合）内の要素の数を返します
        /// </summary>
        public void Count01()
        {
            var data = new List<int>()
                       {
                           1
                           , 2
                           , 3
                           , 4
                           , 5
                       };

            var enumrable = (IEnumerable<int>)data;

            { 
                // 非LINQ
                var result = enumrable.ToList().Count;
            }

            {
                // LINQ：IEnumrableインタフェースからListへキャストせずに件数が取得可能
                var result = enumrable.Count();
            }
        }

        /// <summary>
        /// 指定されたシーケンス（集合）内の条件を満たす要素の数を返します
        /// </summary>
        public void Count02()
        {
            // サンプル：偶数の番号の数を取得する

            { 
                // 非LINQ
                var result = 0;

                foreach (var element in SrcNumbers_A)
                {
                    if (element % 2 == 0)
                    {
                        result = result /*合計をストックしている*/ + 1;
                    }
                }
            }

            {
                // LINQ
                var result = SrcNumbers_A.Count(element =>
                {
                    return element % 2 == 0;
                });
            }

            {
                // LINQ
                var result = SrcNumbers_A.Count(element => element % 2 == 0);
            }
        }

    }
}
