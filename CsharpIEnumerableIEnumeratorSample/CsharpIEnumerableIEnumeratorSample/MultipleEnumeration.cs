using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace CsharpIEnumerableIEnumeratorSample
{
    /// <summary>
    /// ReSharper公式ドキュメント
    /// https://pleiades.io/help/resharper/PossibleMultipleEnumeration.html
    /// IEnumerable[T]の遅延評価について（C#）
    /// https://ad-sho-loko.hatenablog.com/entry/2018/11/26/013826
    /// </summary>
    public class MultipleEnumeration
    {
        private IEnumerable<int> GetIds()
        {
            var range = Enumerable.Range(1, 3);

            // このメソッドは、遅延実行を使用して実装されています。
            // 即時の戻り値は、アクションを実行するために必要なすべての情報を格納するオブジェクトです。
            // このメソッドで表されるクエリは、そのGetEnumeratorメソッドを直接呼び出すか、Visual C#のforeachやVisual BasicのFor Eachを使用してオブジェクトを列挙するまで実行されません。
            
            return range;
        }

        public void 複数列挙の可能性()
        {
            // ここでGetNames()が実行されているように見えるが、実際に実行されるのはforeach内に到達してからの可能性がある
            // ★理由：IEnumerableは遅延評価(delayed evaluation)・lazyな評価(lazy evaluation)・実行されるから
            var ids = GetIds();

            // GetNames() が IEnumerable<string> を返すと仮定すると、2 つの foreach ステートメントでこのコレクションを 2 回列挙することで、実際に余分な作業をしています。
            // GetNames() がデータベースクエリを生成すると、さらに悪化する可能性があります。
            // その場合、2 つの呼び出し間でデータベースを変更するプロセスがあれば、両方の foreach ループで異なる値が得られる可能性があります。

            // Possible multiple enumeration of IEnumerable
            // 訳）IEnumerableの複数列挙の可能性があります
            foreach (var id in ids)
            {
                Console.WriteLine("IDを列挙します：" + id);
            }

            var allIds = new StringBuilder();
            foreach (var id in ids)
            {
                allIds.Append(id + " ");
            }

            // 発生条件：IEnumrable<T>型の変数を複数foreach(ForEach)した場合        
            // 回避方法：変数に代入する前に、IEnumrable<T>を配列（ToArray）やList（ToList）に変換をする
            // ※全件操作・どのような動きをするかわからないクラス・foreach(ForEach)を2回するものは「必ず配列・Listに変換」する
        }
    }
}