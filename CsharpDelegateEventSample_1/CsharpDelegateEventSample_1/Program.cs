using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpDelegateEventSample_1
{
    /// <summary>
    /// Receiver：呼び出す側　メソッドを登録し、デリゲート経由で機能を呼び出されるオブジェクト
    /// </summary>
    internal class Program
    {
        /* 
           イベントの実行制限
           イベントはそのイベント変数が宣言されているクラス内にしか置くことができない
           
           イベントを発生させるクラスの中にイベント宣言も持っているべきという仕様から
           例えイベント宣言されたクラスの派生クラス内からであっても、実行はできないようになっている
           
           delegate：デリゲート呼び出しは別クラスからも可能
           └ event ：デリゲート呼び出しはクラス内部のみ可能　外部からはデリゲートの追加(+=)/削除(-=)のみが可能　※イベントの実体▶デリゲート型のプロパティ
         */

        private static void Main(string[] args)
        {
            #region ★デリゲートのCallbackサンプル---------------------------------

            // 1. 呼び出されるメソッドが所属するクラスのインスタンスを生成
            var callback = new デリゲートのCallback();

            // 2. subscribe：フィールドにメソッドの参照を登録　登録されたイベントハンドラは、イベントが発生する度にシステムが自動的に呼び出す
            callback.Callback += コンソールに結果を表示する;

            //3. 呼び出されるメソッドをコール
            callback.OnCallbackを呼び出し();

            #endregion

            #region ★StandardEventArgsサンプル------------------------------------

            // 1. 呼び出されるメソッドが所属するクラスのインスタンス生成
            var handler = new StandardEventArgs();

            // 2. subscribe：イベントにメソッドの参照を登録　登録されたイベントハンドラは、イベントが発生する度にシステムが自動的に呼び出す
            handler.Event1 += コンソールに結果を表示する;
            handler.Event2 += コンソールに結果を表示する;

            // 3. 呼び出されるメソッドをコール
            handler.OnEventを呼び出し();

            #endregion

            #region ★CustomEventAgrsサンプル-------------------------------------非推奨

            //1. 呼び出されるメソッドが所属するクラスのインスタンス生成
            var eventAgrs = new CustomEventAgrs();

            //2. subscribe：イベントにメソッドの参照を登録　登録されたイベントハンドラは、イベントが発生する度にシステムが自動的に呼び出す
            eventAgrs.Event1 += コンソールに結果を表示する;

            //3. 呼び出されるメソッドをコール
            eventAgrs.OnEventを呼び出し();

            #endregion

            #region ★CustomEventArgs <T> サンプル------------------------------------------推奨

            //1. 呼び出され側クラスのインスタンスを生成
            var @eat = new CustomEventArgs_T();

            //2. subscribe：イベントにメソッドの参照を登録　登録されたイベントハンドラは、イベントが発生する度にシステムが自動的に呼び出す
            eat.Event1 += コンソールに結果を表示する;
            eat.Event2 += コンソールに結果を表示する;

            //3. 呼び出されるメソッドをコール           
            eat.OnEventを呼び出し();

            #endregion

            #region ★CustomEventArgs <T> を継承したサンプル------------------------------------------

            //1. 呼び出され側クラスのインスタンスを生成
            var su = new Succession();

            //2. subscribe：イベントにメソッドの参照を登録　登録されたイベントハンドラは、イベントが発生する度にシステムが自動的に呼び出す
            su.Event1 += コンソールに結果を表示する;
            su.Event2 += コンソールに結果を表示する;

            //3. 呼び出されるメソッドをコール           
            su.OnEventを呼び出し();
            su.SuccessionからOnメソッドを呼び出し();

            #endregion

            #region 定義済みデリゲートSample

            var 定義済 = new 定義済みdelegate();
            定義済.show();

            #endregion

            #region 未定義デリゲートSample

            var 未定義 = new 未定義delegate();
            未定義.show();

            #endregion
        }

        #region ★イベントハンドラたち------------------------------------

        /// <summary>
        /// 5. OnCallBackメソッドが呼び返される　※呼び返されるメソッドは呼び出されるdelegate型と同じメソッドが必要
        /// </summary>  
        public static void コンソールに結果を表示する()
        {
            Console.WriteLine("★デリゲートのCallbackサンプル：OnCallBackメソッドが呼ばれた");
            Console.ReadLine();
        }

        /// <summary>
        /// 5. (4)に呼ばれる、イベントが発生したときに行う処理　★イベントハンドラ(event handler)　呼び返される静的メソッド群：引数が同じクラスに対し、どのような処理を行いたいのか？ 
        /// ～ void xxx(object, EventArgs)
        /// </summary>
        public static void コンソールに結果を表示する(object sender, EventArgs e)
        {
            Console.WriteLine("★標準EventHandlerサンプル：コンソールに結果を表示しました");
            Console.ReadLine();
        }

        /// <summary>
        /// 5. (4)に呼ばれる、イベントが発生したときに行う処理　★イベントハンドラ(event handler)　呼び返される静的メソッド群：引数が同じクラスに対し、どのような処理を行いたいのか？ 
        /// ～ void xxx(object, EventArgs)
        /// </summary>
        public static void コンソールに結果を表示する(object sender, StringEventArgs e)
        {
            var x = e.S1;
            var y = e.S2;
            Console.WriteLine("★カスタムEventAgrsサンプル：" + x + " " + y);
            Console.ReadLine();
        }

        /// <summary>
        /// 5. (4)に呼ばれる、イベントが発生したときに行う処理　★イベントハンドラ(event handler)　呼び返される静的メソッド群：引数が同じクラスに対し、どのような処理を行いたいのか？ 
        /// ～ void xxx(object, EventArgs)
        /// </summary>
        public static void コンソールに結果を表示する(object sender, ReturnClassEventArgs<string> e) //★
        {
            var x = e.S1;
            var y = e.S2;
            Console.WriteLine("★EventAgrs<T>サンプル：" + x + " " + y);
            Console.ReadLine();
        }

        public static void コンソールに結果を表示する(object sender, ReturnClassEventArgs<int> e) //☆
        {
            var x = e.S1;
            var y = e.S2;
            Console.WriteLine("★EventAgrs<T>サンプル：" + x + " " + y);
            Console.ReadLine();
        }

        #endregion
    }
}