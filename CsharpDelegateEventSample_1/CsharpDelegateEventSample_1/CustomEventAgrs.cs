using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpDelegateEventSample_1
{
    /// <summary>
    /// イベントと共に何らかの情報をイベントハンドラに渡す場合に EventArgs を継承したカスタムクラスを作成
    /// EventArgsを継承しているため、EventHandlerの引数に対応可能
    /// </summary>
    public class StringEventArgs : EventArgs
    {
        public string S1;
        public string S2;
    }

    /// <summary>
    /// Sender：呼び出され側クラス　メソッドを受け取り、条件によってその登録されているメソッドを呼び出すオブジェクト
    /// </summary>
    public class CustomEventAgrs
    {
        /*
         * EventHandlerというデリゲート型は .NET Frameworkに定義済みの型
         * public delegate void EventHandler<TEventArgs>(object sender, TEventArgs e);
         * 
         * 戻り値/なし　引数/Object型,EventArgs型 ▶代入するメソッド(＝デリゲートのインスタンス)
         * これにより登録できるメソッドは　～ void Xxxxx(object sender, TEventArgs e)という形で宣言されているものに限定される
         */

        public event EventHandler<StringEventArgs> Event1;

        public event EventHandler<StringEventArgs> Event2;

        /// <summary>
        /// 3. OnEventをコール　このメソッドを呼び出す瞬間がイベント発生の瞬間
        /// </summary>
        public void OnEventを呼び出し()
        {
            OnEvent1(new StringEventArgs
                     {
                         S1 = "OnEvent1:StringEventArgs_S1",
                         S2 = "OnEvent1:StringEventArgs_S2"
                     });

            OnEvent2(new StringEventArgs
                     {
                         S1 = "OnEvent2:StringEventArgs_S1",
                         S2 = "OnEvent2:StringEventArgs_S2"
                     });

            /*
             他クラスから呼び出さない場合は、Onメソッドで包む必要はない
             Event1(this, new StringEventArgs
                          {
                              S1 = "OnEvent1:StringEventArgs_S1",
                              S2 = "OnEvent1:StringEventArgs_S2"
                          });
            */
        }

        /// <summary>
        /// 4. イベントを実行し、イベントに参照が登録されているメソッド(5)を呼び返す(マルチキャストデリゲート)
        /// </summary>
        protected virtual void OnEvent1(StringEventArgs e) //イベントデータを持つ場合は引数有り
        {
            Console.WriteLine("OnEvent1が実行された");
            var handler = Event1;
            if (handler != null) handler(this, e);
        }

        protected virtual void OnEvent2(StringEventArgs e)
        {
            Console.WriteLine("OnEvent2が実行された");
            var handler = Event2;
            if (handler != null) handler(this, e);
        }
    }
}