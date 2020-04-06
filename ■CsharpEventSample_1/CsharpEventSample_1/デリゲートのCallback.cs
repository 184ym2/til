using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpEventSample_1
{
    /// <summary>
    /// 呼び出されるクラス
    /// </summary>
    public class デリゲートのCallback
    {
        /// <summary>
        /// 呼び出されるフィールド(delegate型)
        /// </summary>
        public Action Callback;

        //定義済みdelegateを使わない場合の書き方
        //public delegate void SampleDelegate();　
        //public SampleDelegate Callback;

        /// <summary>
        /// 呼び出されるメソッド
        /// </summary>
        //4. Callbackに登録されているデリゲート(メソッド参照)を呼び出し
        public void Callback用デリゲートを持っています()
        {
            Callback();
        }

        /// <summary>
        /// 呼び返されるメソッド　⚠呼び返されるメソッドは呼び出されるdelegate型と同じメソッドが必要
        /// </summary>
        //5. OnCallBackメソッドが呼び返される 
        public void OnCallBack()
        {
            Console.WriteLine("★デリゲートのCallbackサンプル：OnCallBackメソッドが呼ばれた");
            Console.ReadLine();
        }
    }
}