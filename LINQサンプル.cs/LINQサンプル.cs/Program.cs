using LINQサンプル.cs.LINQ;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQサンプル.cs
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var ag = new Aggregation();

            ag.Aggregate01(); // シーケンス（集合）に集計関数を適用します
            ag.Aggregate02(); // シーケンス（集合）に集計関数を適用します 指定されたシード値が最初の集計値として使用されます
            ag.Aggregate03(); // シーケンス（集合）に集計関数を適用します（複数項目集計サンプル）

            Evaluation.All01(); // シーケンス（集合）のすべての要素が条件を満たしているかどうかを判断します
            Evaluation.Any01(); // シーケンス（集合）に要素が含まれているかどうかを判断します
            Evaluation.Any02(); // シーケンス（集合）の任意の要素が条件を満たしているかどうかを判断します

            ag.Average(); // シーケンス（集合）の平均値を計算します

            Projection.Cast01(); // 指定した型にキャストします
            Projection.Concat01(); // 2 つのシーケンス（集合）を連結します
            Projection.Contains01(); // 指定した要素がシーケンス（集合）に含まれているかどうかを判断します

            ag.Count01(); // シーケンス（集合）内の要素数を返します
            ag.Count02(); // 条件を満たす、指定されたシーケンス（集合）内の要素の数を表す数値を返します

            Projection.DefaultIfEmpty01(); // 指定されたシーケンス（集合）の要素を返します。シーケンス（集合）が空の場合は指定した値を返します
            Projection.DefaultIfEmpty02(); // 指定されたシーケンス（集合）の要素を返します。シーケンス（集合）が空の場合は型の既定値を返します
            Projection.Distinct01(); // シーケンス（集合）から一意の要素を返します
            Projection.ElementAt01(); // 指定されたインデックス位置にある要素を返します
            Projection.ElementAtDefault01(); // 指定したインデックス位置にある要素を返します。インデックスが範囲外の場合は既定値を返します
            Projection.Except01(); // 2 つのシーケンス（集合）の差集合を生成します
            Projection.First01(); // シーケンス（集合）の最初の要素を返します
            Projection.First02(); // 指定された条件を満たす、シーケンス（集合）の最初の要素を返します
            Projection.FirstOrDefault01(); // シーケンス（集合）の最初の要素を返します。シーケンス（集合）に要素が含まれていない場合は既定値を返します
            Projection.FirstOrDefault02(); // 条件を満たす、シーケンス（集合）の最初の要素を返します。このような要素が見つからない場合は既定値を返します
            Projection.InnerJoin(); // ２つのシーケンス（集合）の内部結合を行います（INNER JOIN）
            Projection.OuterJoin(); // ２つのシーケンス（集合）の左辺外部結合を行います（LEFT OUETER JOIN）
            Projection.LongCount01(); // シーケンス（集合）内の要素の合計数を表す Int64 を返します
            Projection.LongCount02(); // シーケンス（集合）内で条件を満たす要素の数を表す Int64 を返します

            ag.Max01(); // シーケンス（集合）の最大値を返します
            ag.Max02(); // シーケンス（集合）の各要素に対して変換関数を呼び出し、最大値を返します
            ag.Min01(); // シーケンス（集合）の最小値を返します
            ag.Min02(); // シーケンス（集合）の各要素に対して変換関数を呼び出し、結果の最小値を返します

            Projection.OfType01(); // 指定された型に基づいて要素をフィルター処理します

            Sort.OrderBy01(); // 要素を指定のキーに従って昇順に並べ替えます
            Sort.OrderByDecending01(); // 要素を指定のキーに従って降順に並べ替えます
            Sort.Reverse01(); // シーケンス（集合）の要素の順序を反転させます

            Projection.Select01(); // シーケンス（集合）の各要素を新しいフォームに射影します
            Projection.Select02(); // シーケンス（集合）の各要素をインデックス付きで新しいフォームに射影します

            Evaluation.SequenceEqual01(); // 標準の比較子で要素を比較することで、2 つのシーケンス（集合）が等しいかどうかを判断します
            Evaluation.SequenceEqual02(); // 指定の比較子で要素を比較することで、2 つのシーケンス（集合）が等しいかどうかを判断します
            
            Projection.Single01(); // シーケンス（集合）の唯一の要素を返し、シーケンス（集合）内の要素が 1 つだけでない場合は例外をスローします
            Projection.Single02(); // 指定された条件を満たす、シーケンス（集合）の唯一の要素を返し、そのような要素が複数存在する場合は例外をスローします
            Projection.SingleOrDefault01(); // シーケンス（集合）の唯一の要素を返します。シーケンス（集合）が空の場合、既定値を返します。シーケンス（集合）内に要素が複数ある場合、このメソッドは例外をスローします
            Projection.SingleOrDefault02(); // 指定された条件を満たすシーケンス（集合）の唯一の要素、またはそのような要素がない場合は既定値を返します。このメソッドは、複数の要素が条件を満たす場合に例外をスローします
            Projection.Skip01(); // シーケンス（集合）内の指定された数の要素をバイパスし、残りの要素を返します
            Projection.SkipWhile01(); // 指定された条件が満たされる限り、シーケンス（集合）の要素をバイパスした後、残りの要素を返します

            ag.Sum01(); // 値のシーケンス（集合）の合計を計算します
            ag.Sum02(); // 各要素に対して変換関数を呼び出して取得する値の合計を計算します

            Projection.Take01(); // シーケンス（集合）の先頭から、指定された数の連続する要素を返します
            Projection.TakeWhile01(); // 指定された条件が満たされる限り、シーケンス（集合）から要素を返します
            Projection.ToDictionary01(); // 指定されたキー セレクター関数および要素セレクター関数に従って、Dictionary<TKey,TValue> から IEnumerable<T> を作成します
            Projection.Union01(); // 既定の等値比較子を使用して、2 つのシーケンス（集合）の和集合を生成します
            Projection.Union02(); // 指定された比較子を使用して 2 つのシーケンス（集合）の和集合を生成します
            Projection.Where01(); // 述語に基づいて値のシーケンス（集合）をフィルター処理します
            Projection.Zip01(); // 2 つのシーケンス（集合）の対応する要素に対して、1 つの指定した関数を適用し、結果として 1 つのシーケンス（集合）を生成します
        }

    }
}