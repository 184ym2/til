using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpDelegateEventSample_1
{
    /// <summary>
    /// Sender：呼び出され側クラス　メソッドを受け取り、条件によってその登録されているメソッドを呼び出すオブジェクト
    /// </summary>
    public class デリゲートのCallback
    {
        /// <summary>
        /// 呼び出されるフィールド(コールバック用のデリゲート)　
        /// </summary>
        public Action Callback;

        //定義済みdelegateを使わない場合の書き方
        //public delegate void SampleDelegate();　
        //public SampleDelegate Callback;

        /// <summary>
        /// 3. OnCallbackを呼び出し をコール　※このメソッドを呼び出すと OnCallback(); が実行され、さらに Callback(); に追加されたメソッドが実行される
        /// </summary>
        public void OnCallbackを呼び出し()
        {
            OnCallback();

            /* 
             * ※他クラスから呼び出さない場合は、Onメソッドで包む必要はない
               Callback();
            */
        }

        /// <summary>
        /// 4. フィールド(デリゲート)を実行し、イベントに参照が登録されているメソッド(5)を呼び返す(マルチキャストデリゲート) 
        /// </summary>
        public void OnCallback()
        {
            Callback();
        }
    }
}