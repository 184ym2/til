using System;
using System.Collections;
using System.Collections.Generic;

using System.Linq;
using System.Text;

namespace CsharpKeywordSample_1
{
    class イテレーターとは
    {
        /* イテレーター構文　　：IEnumerator を簡単に実装するための機能　return の代わりに yield return
         * 
         * イテレーターブロック：メソッドやプロパティのgetアクセサーなどを定義する際、
         * 　　　　　　　　　　　ブロック中にreturnの代わりにyield returnもしくはyield breakを書くことで
         * 　　　　　　　　　　　通常のメソッドやプロパティとは違った動作が得られる　→　これらが含まれるブロックをイテレーターブロックと呼ぶ
         * 
         * ★イテレーター ブロックを使うことで、「foreach 文」で利用可能なコレクションを返すメソッドやプロパティを簡単に実装することができる
         * 
         * 通常のブロック(メソッドやプロパティgetアクセサーの本体)との違いは以下の通り
         * 
         * 1.戻り値の型が以下のうちのいずれか
         * System.Collections.IEnumerator　System.Collections.Generic.IEnumerator<T>
         * System.Collections.IEnumerable　System.Collections.Generic.IEnumerable<T>
         * 
         * 2.
         * return の代わりに  yield return 　
         * break  の代わりに  yield break　を使用する
         */

        //「イテレーター ブロック」IEnubrable を実装するクラスが自動生成される
        static public IEnumerable<int> FromTo(int from, int to)
        {
            while (from <= to)
                yield return from++;
        }

        public void イテレーターブロック()
        {
            // ↓こんな感じで使う。
            foreach (var i in FromTo(10, 20))
            {
                Console.Write("{0}\n", i);
            }
        }

        //イテレーター ブロック中で、yield return 文が呼ばれるたびに、 foreach 文中で使われる値を1つ得る
        //for 文や while 文を使わず、ベタに yield return を並べても OK
        //yield break を記述した行まで処理が進むと、イテレーターの処理はそこで終了される
        static public IEnumerable GetEnumerable(int from, int to)
        {
            yield return 1;
            yield return 3.14;
            yield return "文字列";         
            yield return 1.0f;
        }
    }

    //イテレーター ブロックは静的（static）なものでもインスタンス（非 static）でも、 どちらでも定義可能
    //また、プロパティ風の記述も可能
    //上述の例は static なメソッドだが、以下のような非 static なプロパティ風の定義も可能 
    class イテレーターとは2
    {
        int _from, _to;

        public イテレーターとは2(int from, int to)
        {
            _from = from;
            _to = to;
        }

        public IEnumerable<int> Enumerable
        {
            get
            {
                while (_from <= _to)
                    yield return _from++;
            }
        }

        public static void 非staticプロパティ風()
        {
            foreach (var i in new イテレーターとは2(10, 20).Enumerable)
            {
                Console.Write("{0}\n", i);
            }
        }
    }


}
