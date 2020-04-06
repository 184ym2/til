using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpKeywordSample_1
{
    class foreachとは
    {
        //foreachとは、コレクションのすべての要素を1回ずつ読み出すための構文

        public void IEnumerableインターフェース()
        {
            /* データの格納方式が異なる場合、データの読み出し方も変わってくる
             * 同じ「コレクション内のすべての要素を1回ずつ読み出す」という操作だが、書くコードは異なるという現象が発生する
             * 
             * コレクションごとにコードを変更するのは面倒、 仕様の変更に柔軟に対応できないなどの問題があり
             * 
             * そこで、コレクションクラスは共通のインターフェースを実装するという決まりを作成
             * 要素へのアクセスはこのインターフェースを通して行うのが一般的 
             * 
             * そのためのクラスとして .NET Framework には IEnumerable というインターフェースが存在する
             * もちろん、C# の配列は IEnumerable インターフェースを実装している
             */
        }

        /* foreach文を用いることで、IEnumerableインターフェース を介した要素へのアクセスを簡略化できる
         * foreach(型名 変数 in コレクション)
         *
         * ★foreach文の実態は IEnumerable インターフェース を介した要素へのアクセス
         * ★IEnumerable インターフェースを実装しているならどんなコレクションクラスの要素でも読み出すことが可能
         * ★余談：foreach で使うコレクションは、実は IEnumerable を実装している必要はなく
         *　　　　 GetEnumerator という名前のメソッドを持っていればどんな型でも◎　→　duck typing
         *　　　　
         *　　　　★duck typing：インターフェースに頼るのではなく、 メソッドなどの名前だけ見て処理を振り分けるようなプログラミングスタイル
         *　　　　「アヒルのように歩き、アヒルのように鳴くものはアヒルに違いない」という格言が由来
         *　　　　「見た目が一緒なら同じ扱いしてもいいのでは？」という意味
         *
         * 例）.NET Framework標準ライブラリのArrayListクラスはIEnumrableインターフェースを実装している　→　foreach文を使ってコレクション内の要素を列挙する
         */

        public void コレクションクラスの自作()
        {
            /* IEnumrableインターフェースを実装することで、foreach文で利用できるコレクションクラスを自作できる
             * 
             * IEnumrableインターフェースにはGetEnumeratorメソッドがあり、このメソッドはIEnumeratorインターフェースを返す
             * コレクションクラスを自作する場合、このIEnumeratorインターフェースを実装する列挙子も自作する必要がある
             * 
             * IEnumeratorインターフェースにはCurrentというプロパティとMoveNext、Resetという2つのメソッドがある
             * 
             * Current プロパティ：コレクション内の現在の要素を取得するためのもの
             * MoveNextメソッド　：列挙子をコレクションの次の要素に進める
             * Reset   メソッド　：列挙子を初期位置、つまりコレクションの最初の要素の前に戻す
             */

            //以上の作業を簡略化するための機能が C#2.0「イテレーター」で追加された
        }

    }
}
