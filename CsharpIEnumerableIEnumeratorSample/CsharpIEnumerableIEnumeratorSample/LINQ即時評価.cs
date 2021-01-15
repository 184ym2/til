using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpIEnumerableIEnumeratorSample
{
    internal class LINQ即時評価
    {
        public void 即時評価()
        {
            // LINQ では、クエリの実行はクエリ自体とは別個のものです。 つまり、クエリ変数を作成するだけでは、データは取得されません。

            // 標準クエリ演算子の実行のタイミングは、シングルトン値を返すか、値のシーケンスを返すかで異なります。
            // これらのシングルトン値を返すメソッド (たとえば、Average と Sum) は、すぐに実行されます。
            // シーケンスを返すメソッドは、クエリの実行を遅延させ、列挙可能なオブジェクトを返します。

            var range = Enumerable.Range(1, 6); // データを取得しているわけではない

            var average = range.Average(); // 

            var sum = range.Sum(); // 


            var array = new int[]
                        {
                            1,
                            2,
                            3,
                            4,
                            5,
                            6
                        };


            var average2 = array.Average();

            var sum2 = array.Sum();

            var select = array.Select(e => e);


            var range2 = FirstLast(1, 6); // データを取得しているわけではない

            var average3 = range2.Average(); // 実際はここ

            var sum3 = range2.Sum(); // 実際はここ

        }

        /// <summary>
        /// 指定した範囲のシーケンスを生成する
        /// </summary>
        /// <param name="first"></param>
        /// <param name="last"></param>
        /// <returns></returns>
        public static IEnumerable<int> FirstLast(int first, int last)
        {
            for (var namber = first; namber <= last; namber++)
                yield return namber;
            // 反復子？
        }

        public static IEnumerable<int> FirstSix()
        {
            yield return 1;
            yield return 2;
            yield return 3;
            yield return 4;
            yield return 5;
            yield return 6;
        }
    }
}