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
    /// <typeparam name="T"></typeparam>
    public class ReturnClassEventArgs<T> : EventArgs
    {
        public T S1;
        public T S2;
    }

    /// <summary>
    /// Sender：呼び出され側クラス　メソッドを受け取り、条件によってその登録されているメソッドを呼び出すオブジェクト
    /// </summary>
    public class CustomEventArgs_T
    {
        /*
         * EventHandlerというデリゲート型は .NET Frameworkに定義済みの型
         * public delegate void EventHandler<TEventArgs>(object sender, TEventArgs e);
         * 
         * 戻り値/なし　引数/Object型,EventArgs型 ▶代入するメソッド(＝デリゲートのインスタンス)
         * これにより登録できるメソッドは　～ void Xxxxx(object sender, TEventArgs e)という形で宣言されているものに限定される
        */

        //イベント宣言で型を指定：呼び返される(Callback)メソッドに伝える情報がある　※イベント発生待受部分

        public event EventHandler<ReturnClassEventArgs<string>> Event1; //★

        public event EventHandler<ReturnClassEventArgs<int>> Event2; //☆

        /// <summary>
        /// 3. OnEventをコール このメソッドを呼び出す瞬間がイベント発生の瞬間
        /// </summary>
        public void OnEventを呼び出し()
        {
            OnEvent1(new ReturnClassEventArgs<string>
                     {
                         S1 = "OnEvent1:ReturnClass<string>_S1",
                         S2 = "OnEvent1:ReturnClass<string>_S2"
                     });

            OnEvent2(new ReturnClassEventArgs<int>
                     {
                         S1 = 10,
                         S2 = 20
                     });

            /*  
             他クラスから呼び出さない場合は、Onメソッドで包む必要はない
             Event1(this, new ReturnClassEventArgs<string>
                         {
                             S1 = "OnEvent1:ReturnClass<string>_S1",
                             S2 = "OnEvent1:ReturnClass<string>_S2"
                         });
             */
        }

        /// <summary>
        /// 4. イベントを実行し、イベントに参照が登録されているメソッド(5)を呼び返す(マルチキャストデリゲート) 
        /// </summary>
        protected virtual void OnEvent1(ReturnClassEventArgs<string> e) //イベントデータを持つ場合は引数有り
        {
            Console.WriteLine("OnEvent1が実行された");

            var handler = Event1;
            if (handler != null) handler(this, e);
        }

        protected virtual void OnEvent2(ReturnClassEventArgs<int> e)
        {
            Console.WriteLine("OnEvent2が実行された");

            var handler = Event2;
            if (handler != null) handler(this, e);
        }
    }
}