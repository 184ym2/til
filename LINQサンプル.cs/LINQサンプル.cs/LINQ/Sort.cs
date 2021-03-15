using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQサンプル.cs
{
    /// <summary>
    /// ソート関連のLINQ
    /// </summary>
    static class Sort
    {

        /// <summary>
        /// Ex：列挙子を公開するメソッド
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<OrderSample> GetOrderSample()
        {
            return new List<OrderSample>
                   {
                       new OrderSample(4, 1, 4)
                       , new OrderSample(7, 8, 3)
                       , new OrderSample(5, 5, 8)
                       , new OrderSample(8, 5, 3)
                   };
        }

        /// <summary>
        /// Ex：並び替えサンプル用クラス
        /// </summary>
        public class OrderSample
        {
            // newする際に渡された引数で初期化
            public OrderSample(int v1, int v2, int v3)
            {
                Value1 = v1;
                Value2 = v2;
                Value3 = v3;
            }

            public int Value1 { get; set; }
            public int Value2 { get; set; }
            public int Value3 { get; set; }

            /// <summary>Ex：現在の <see cref="T:System.Object" /> を表す <see cref="T:System.String" /> を返します。</summary>
            /// <returns>Ex：現在の <see cref="T:System.Object" /> を表す <see cref="T:System.String" />。</returns>
            public override string ToString()
            {
                return string.Format("V1={0} V2={1} V3={2}", Value1, Value2, Value3);
            }
        }


        /// <summary>
        /// シーケンス（集合）内の要素の順序を反転します
        /// </summary>
        public static void Reverse01()
        {
            {
                // 非LINQ：IEnnumrableのままではソートできないのでリスト化
                var result = GetOrderSample().ToList();
                result.Reverse();
            }

            {
                // LINQ：リスト化不要
                var result = GetOrderSample().Reverse();
            }
        }

        /// <summary>
        /// シーケンス（集合）の要素をキーに従って昇順に並べ替えます
        /// </summary>
        public static void OrderBy01()
        {
            {
                // 非LINQ：IEnumrable<T>のままではソートできないのでリスト化
                var result = GetOrderSample().ToList();

                // Comparison<T>：同じタイプの2つのオブジェクトを比較するメソッドを表します
                // 引数 x：比較する最初のオブジェクト　y：比較する2番目のオブジェクト
                // ------------------------------------------------------
                // 戻り値 | 0未満　　　　  | 0　　　　　  | 0より大きい　　  |
                // ------------------------------------------------------
                // 　　　 | xはyより小さい | xはyに等しい | xはyよりも大きい |
                // ------------------------------------------------------
                // このデリゲートに代入可能なメソッドをラムダ式で作成する
                Comparison<OrderSample> comparison = (orderA, orderB) => orderA.Value2 - orderB.Value2;

                // 列挙子に対してSortメソッドを呼び、Comparison<T> デリゲートを渡す　※同じ機能を持つメソッドの代入も可能
                result.Sort(comparison);
            }

            {
                // LINQ：列挙子に対してOrderByメソッドを呼び、並び替えのキーを渡す
                var result = GetOrderSample().OrderBy(element => element.Value2);
            }

            {
                // LINQ：クエリ構文
                var result = from classA in TeamList.Aclass_personnel
                             orderby classA.Key, classA.Value
                             select classA;

            }

            {
                // LINQ：標準クエリ演算子 IEnumerableを継承している場合、どのクラスに対しても同じメソッドを呼び出し可能
                var result = TeamList.Aclass_personnel.OrderBy(e => e.Key).ThenBy(e => e.Value);
            }

        }

        /// <summary>
        /// シーケンス（集合）の要素をキーに従って降順に並べ替えます
        /// </summary>
        public static void OrderByDecending01()
        {
            {
                // 非LINQ：IEnumrableのままではソートできないのでリスト化
                var result = GetOrderSample().ToList();

                // 列挙子に対してSortメソッドを呼び、Comparison<T> デリゲートを渡す　※同じ機能を持つメソッドの代入も可能
                result.Sort((orderA, orderB) => orderB.Value2 - orderA.Value2);
            }

            {
                // LINQ：列挙子に対してOrderByDescendingメソッドを呼び、並び替えのキーを渡す
                var result = GetOrderSample().OrderByDescending(element => element.Value2);
            }

            {
                // LINQ：クエリ構文
                var result = from classA in TeamList.Aclass_personnel
                             orderby classA.Key descending, classA.Value descending
                             select classA;

            }
        }



    }
}
