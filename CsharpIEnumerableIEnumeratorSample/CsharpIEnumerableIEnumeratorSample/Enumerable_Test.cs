using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpIEnumerableIEnumeratorSample
{
    internal class Enumerable_Test : IEnumerable<int>
    {
        /// <summary>
        /// 列挙子(IEnumerator)
        /// </summary>
        private IEnumerator<int> enumerator;

        #region Implementation of IEnumerable

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
    }
}