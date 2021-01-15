using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpIEnumerableIEnumeratorSample
{
    internal class Enumerator_Test : IEnumerator<int>
    {
        #region Implementation of IDisposable

        /// <summary>
        /// アンマネージ リソースの解放およびリセットに関連付けられているアプリケーション定義のタスクを実行します。
        /// </summary>
        public void Dispose()
        {
        }

        #endregion

        #region Implementation of IEnumerator

        /// <summary>
        /// 列挙子をコレクションの次の要素に進めます。
        /// </summary>
        /// <returns>
        /// 列挙子が次の要素に正常に進んだ場合は true。列挙子がコレクションの末尾を越えた場合は false。
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">列挙子が作成された後に、コレクションが変更されました。</exception>
        public bool MoveNext()
        {
            return true;
        }

        /// <summary>
        /// 列挙子を初期位置、つまりコレクションの最初の要素の前に設定します。
        /// </summary>
        /// <exception cref="T:System.InvalidOperationException">列挙子が作成された後に、コレクションが変更されました。</exception>
        public void Reset()
        {
        }

        /// <summary>
        /// 列挙子の現在位置にあるコレクション内の要素を取得します。
        /// </summary>
        /// <returns>
        /// コレクション内の、列挙子の現在位置にある要素。
        /// </returns>
        public int Current { get; private set; }

        /// <summary>
        /// コレクション内の現在の要素を取得します。
        /// </summary>
        /// <returns>
        /// コレクション内の現在の要素。
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">列挙子が、コレクションの最初の要素の前、または最後の要素の後に位置しています。</exception>
        object IEnumerator.Current { get { return Current; } }

        #endregion
    }
}