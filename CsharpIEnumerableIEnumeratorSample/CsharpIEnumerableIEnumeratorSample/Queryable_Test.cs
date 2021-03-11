using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CsharpIEnumerableIEnumeratorSample
{
    /// <summary>
    /// 実装：IEnumerable[T]  IEnumerable  IQueryable
    /// </summary>
    internal class Queryable_Tests : IQueryable<int>
    {
        #region Implementation of IEnumerable

        private IEnumerator<int> enumerator;

        /// <summary>
        /// コレクションを反復処理する列挙子を返します。
        /// </summary>
        /// <returns>
        /// コレクションを反復処理するために使用できる <see cref="T:System.Collections.Generic.IEnumerator`1"/>。
        /// </returns>
        public IEnumerator<int> GetEnumerator()
        {
            return enumerator;
        }

        /// <summary>
        /// コレクションを反復処理する列挙子を返します。
        /// </summary>
        /// <returns>
        /// コレクションを反復処理するために使用できる <see cref="T:System.Collections.IEnumerator"/> オブジェクト。
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region Implementation of IQueryable

        /// <summary>
        /// <see cref="T:System.Linq.IQueryable"/> のインスタンスに関連付けられている式ツリーを取得します。
        /// </summary>
        /// <returns>
        /// <see cref="T:System.Linq.IQueryable"/> のこのインスタンスに関連付けられている <see cref="T:System.Linq.Expressions.Expression"/>。
        /// </returns>
        public Expression Expression { get; private set; }

        /// <summary>
        /// <see cref="T:System.Linq.IQueryable"/> のこのインスタンスに関連付けられた式ツリーが実行されたときに返される要素の型を取得します。
        /// </summary>
        /// <returns>
        /// このオブジェクトに関連付けられた式ツリーが実行されたときに返される要素の型を表す <see cref="T:System.Type"/>。
        /// </returns>
        public Type ElementType { get; private set; }

        /// <summary>
        /// このデータ ソースに関連付けられたクエリ プロバイダーを取得します。
        /// </summary>
        /// <returns>
        /// このデータ ソースに関連付けられた <see cref="T:System.Linq.IQueryProvider"/>。
        /// </returns>
        public IQueryProvider Provider { get; private set; }

        #endregion
    }
}