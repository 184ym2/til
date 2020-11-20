using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpDelegateEventSample_1
{
    /// <summary>
    /// Sender：呼び出され側クラス　メソッドを受け取り、条件によってその登録されているメソッドを呼び出すオブジェクト
    /// </summary>
    public class StandardEventArgs
    {
        /*
         * EventHandlerというデリゲート型は .NET Frameworkに定義済みの型
         * public delegate void EventHandler<TEventArgs>(object sender, TEventArgs e);
         * 
         * 戻り値/なし　引数/Object型,EventArgs型 ▶代入するメソッド(＝デリゲートのインスタンス)
         * これにより登録できるメソッドは　～ void xxx(object sender, TEventArgs e)という形で宣言されているものに限定される
         */

        /// <summary>
        /// 標準EventHandler：呼び返されるメソッドにはないも無いという条件でのみ使用可能　※Actionデリゲートと同じ
        /// </summary>
        public event EventHandler Event1;

        public event EventHandler Event2;

        /// <summary>
        /// 3. OnEventをコール　このメソッドを呼び出す瞬間がイベント発生の瞬間
        /// </summary>
        public void OnEventを呼び出し()
        {
            OnEvent1();
            OnEvent2();

            /*
             他クラスから呼び出さない場合は、Onメソッドで包む必要はない
             Event1(this, EventArgs.Empty);
             */
        }

        /// <summary>
        /// 4. イベントを実行し、イベントに参照が登録されているメソッド(5)を呼び返す(マルチキャストデリゲート)
        /// </summary>
        protected virtual void OnEvent1() //イベントデータを持たない場合は引数無し
        {
            Console.WriteLine("OnEvent1が実行された");
            var handler = Event1;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        protected virtual void OnEvent2()
        {
            Console.WriteLine("OnEvent2が実行された");
            var handler = Event2;
            if (handler != null) handler(this, EventArgs.Empty);
        }
    }
}