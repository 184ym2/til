using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpGenericSample_1
{
    //★GenericList<T>というジェネリッククラスを作成する
    public class GenericList<T>
    {
        #region 内部クラス(Nested Type)

        private class Node
        {
            /* ① */

            //★<T>は非ジェネリックコンストラクタでも使用できる
            public Node(T a)//コンストラクタの引数は<T>型(呼び出し後=int型)のa
            {
                _next = null;
                _data = a;
            }

            private Node _next;//非公開
            public Node Next 
                //★プロパティはクラス内部から見るとメソッドのように振る舞っている
                //★外部からはメンバ変数に見える     
            
            {
                get { return _next; } //値の取得時の処理
                set { _next = value; }//値の変更時の処理 //valueという名前の変数に代入された値が格納される
            }

            private T _data; //★フィールド(プライベートメンバ)としての<T> 
            public T Data    //★プロパティの戻り値の型としての<T>
            {
                get { return _data; }
                set { _data = value; }
            }
        }
        #endregion

        //★変数宣言 GenericList<T>クラスの中にNodeクラスを入れるフィールド変数を用意
        private Node _head;  //_headに _next,_data,Next,Data が入っている 

        //GenericListのコンストラクタ
        public GenericList()
        {
            _head = null;　//★変数だけを用意する為_headにnullを格納する 
        }


        //★メソッドの引数としての<T>
        public void 追加(T b)//★戻り値なし,引数一つ,<T>型のb
        {
            //引数つきのコンストラクターを呼び出すためには、newを使ってインスタンスを生成する際に、以下のようにして引数を渡す
            //クラス名 変数名 = new クラス名(引数)

            /* ② */
            var n = new Node(b)//T型(呼び出し後int型)ならば引数はなんでもOK = T型のbを引数として渡す
            //★この時点でnに(Nodeクラス/_next,_data,Next,Data)が入る
                    {
                        Next = _head //★_headが代入の値(null)なのでNextはnull
                    };

            _head = n;//★nが代入の値(Nodeクラス/_next,_data,Next,Data)なので_headは(Nodeクラス/_next,_data,Next,Data)
　　　　　　　　　　　
        }


        //イテレーターブロック…(イールド)yield returnもしくはyield breakを含むブロックのこと
        public IEnumerator<T> GetEnumerator()
        {
            var current = _head;//現在の要素

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
                
            }
        }
    }
}
