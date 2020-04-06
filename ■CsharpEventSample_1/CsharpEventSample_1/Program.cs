using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpEventSample_1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            #region ★デリゲートのCallbackサンプル---------------------------------

            //1. 呼び出されるメソッドが所属するクラスのインスタンスを生成
            var cbI = new デリゲートのCallback();

            //2. ActionデリゲートCallbackに、呼び返したいOnCallBackメソッドの参照を登録 

            cbI.Callback += cbI.OnCallBack; //⚠呼び出し側は呼び出され側のCallbackフィールドが、Callback用デリゲートかどうかを確認しなければならない

            //3. Callback用デリゲートを持っていますメソッドをコール
            cbI.Callback用デリゲートを持っています();

            #endregion

            /*　イベントの実行制限
　　　　　
              イベントはそのイベント変数が宣言されているクラス内にしか置くことができない
              
　　　　　　　　イベントを発生させるクラスの中にイベント宣言も持っているべきという仕様から
　　　　　　　　例えイベント宣言されたクラスの派生クラス内からであっても、実行はできないようになっている

           　　・デリゲート：別クラスから実行可能 
           　　・イベント　：同一クラスのみ実行可能　　　　　　　　
             
　　　　　　　　例）クリックイベントは、それが宣言されているボタンクラスの中で実行されるべきであって、別のボタンクラス等から実行されるべきではない
　　　　　　　　　
            */

            #region ★標準EventHandlerサンプル------------------------------------

            //1. 呼び出されるメソッドが所属するクラスのインスタンス生成
            var cbI1 = new 標準EventHandler();

            //2. OnEventイベントに、OnEventメソッドの参照を登録
            //エディタのヘルプマークに⚡マークが表示される
            cbI1.OnEvent += OnEvent;

            //3. イベントを持っていますメソッドをコール
            cbI1.OnEventを持っています();

            #endregion

            #region ★カスタムEventAgrsサンプル-------------------------------------非推奨

            //1. 呼び出されるメソッドが所属するクラスのインスタンス生成
            var cbI2 = new CustomEventAgrs();

            //2. OnEventイベントに、OnEventメソッドの参照を登録
            //エディタのヘルプマークに⚡マークが表示される
            cbI2.OnEvent += OnEvent;

            //3. イベントを持っていますメソッドをコール
            cbI2.OnEventを持っています();

            #endregion

            #region ★EventAgrs<T>サンプル----------------------------------------推奨

            //1. 呼び出され側クラスのインスタンスを生成
            var cbI3 = new EventArgs_T();

            //2. 各イベントに呼び返したいメソッドの参照を登録
            cbI3.OnEvent1 += NastEa_string;
            cbI3.OnEvent2 += NestEa_int;
            cbI3.OnEvent3 += NestEa_List_string;
            cbI3.OnEvent4 += NestEa_List_int;
            cbI3.OnEvent5 += NestEa_List_string;

            //3. 呼び出されるメソッドをコール
            cbI3.OnEvent1と5を持っています();
            cbI3.OnEvent2を持っています();
            cbI3.OnEvent3を持っています();
            cbI3.OnEvent4を持っています();

            #endregion
        }

        //呼び返される(Callback)静的メソッド群：引数が同じクラスに対し、どのような処理を行いたいのか？   

        #region ★標準EventHandlerサンプル------------------------------------

        //5. OnEventメソッドが呼び返される
        private static void OnEvent(object sender, EventArgs e)
        {
            Console.WriteLine("★標準EventHandlerサンプル：OnEventメソッドが呼ばれた");
            Console.ReadLine();
        }

        #endregion

        #region ★カスタムEventAgrsサンプル-------------------------------------非推奨

        //5. OnEventメソッドが呼び返される
        public static void OnEvent(object sender, CustomEventAgrs.NestEa e) //e：CsharpEventSample_1.CustomEventAgrs.NestEa
        {
            var x = e.S1;
            var y = e.S2;
            Console.WriteLine("★カスタムEventAgrsサンプル：" + x + " " + y);
            Console.ReadLine();
        }

        #endregion

        #region ★EventAgrs<T>サンプル----------------------------------------推奨

        //5. 呼び返されたメソッド
        public static void NastEa_string(object sender, EventArgs_T.NestEa<string> e)
        {
            Console.WriteLine("---NastEa_stringメソッド---");
            var x = e.S1;
            var y = e.S2;
            Console.WriteLine(x + " " + y);
            Console.ReadLine();
        }

        public static void NestEa_int(object sender, EventArgs_T.NestEa<int> e)
        {
            Console.WriteLine("---NestEa_intメソッド---");
            var x = e.S1;
            var y = e.S2;
            Console.WriteLine(x + " " + y);
            Console.ReadLine();
        }

        public static void NestEa_List_string(object sender, EventArgs_T.NestEa<List<string>> e)
        {
            Console.WriteLine("---NestEa_List_stringメソッド---");
            Console.WriteLine("S1：");
            foreach (var list1 in e.S1)
            {
                Console.WriteLine(list1);
            }

            Console.WriteLine("S2：");
            foreach (var list2 in e.S2)
            {
                Console.WriteLine(list2);
            }
            var @equals = e.S1.Equals(e.S2); //S1とS2の比較
            Console.WriteLine(@equals == false
                                  ? "S1はS2と異なります"
                                  : "S1はS2と同じです");
            Console.ReadLine();
        }

        public static void NestEa_List_int(object sender, EventArgs_T.NestEa<List<int>> e)
        {
            Console.WriteLine("S1：リスト内容");
            e.S1.Sort(); //並べ替え(元のリストは 1000, 10, 100, 1)
            foreach (var list1 in e.S1)
            {
                Console.WriteLine(list1);
            }

            var list2 = e.S2.Count.ToString(); //要素数の取得 string型に変換
            Console.WriteLine("S2：要素数");
            Console.WriteLine(list2);
            Console.ReadLine();
        }

        #endregion
    }

    //ここから各クラスの定義

    #region ★標準EventHandlerサンプル------------------------------------

    /// <summary>
    /// 呼び出され側クラス
    /// </summary>
    public class 標準EventHandler
    {
        //標準のEventHandler：呼び返されるメソッドにはないも無いという条件でのみ使用可能　※Actionデリゲートと同じ   
        public event EventHandler OnEvent; //OnEvent という宣言　イベントの名前は「On」で始めることが多い　

        /// <summary>
        /// 呼び出されるメソッド：イベントの参照を持っている
        /// </summary>
        //4. イベントに参照が登録されているメソッドを呼び返す(マルチキャストデリゲート)
        public void OnEventを持っています()
        {
            if (OnEvent != null) OnEvent(this, null); //第一引数…誰がこのEventを発したか　第二引数…nullでOK
        }
    }

    #endregion

    #region ★カスタムEventAgrsサンプル-------------------------------------非推奨

    /// <summary>
    /// 呼び出され側クラス
    /// </summary>
    public class CustomEventAgrs
    {
        public class NestEa : EventArgs //入れ子のクラス
        {
            public string S1;
            public string S2;
        }

        public event EventHandler<NestEa> OnEvent;

        /// <summary>
        /// 呼び出されるメソッド：イベントの参照を持っている
        /// </summary>
        //4. イベントに参照が登録されているメソッドを呼び返す(マルチキャストデリゲート)
        public void OnEventを持っています()
        {
            var eargs = new NestEa
                        {
                            S1 = "Eventメソッド2のS1",
                            S2 = "Eventメソッド2のS2"
                        };

            if (OnEvent != null) OnEvent(this, eargs); //第一引数…誰がこのEventを発したか　第二引数…nullでOK
        }
    }

    #endregion

    #region ★EventAgrs<T>サンプル----------------------------------------推奨

    /// <summary>
    /// 呼び出され側クラス
    /// </summary>
    public class EventArgs_T
    {
        public class NestEa<T> : EventArgs
        {
            public T S1;
            public T S2;
        }

        //イベント宣言で型を指定：呼び返される(Callback)メソッドに伝える情報がある
        public event EventHandler<NestEa<string>> OnEvent1;

        public event EventHandler<NestEa<int>> OnEvent2;

        public event EventHandler<NestEa<List<string>>> OnEvent3;

        public event EventHandler<NestEa<List<int>>> OnEvent4;

        public event EventHandler<NestEa<List<string>>> OnEvent5;

        /// <summary>
        /// 呼び出されるメソッド：イベントの参照を持っている
        /// </summary>
        //4. イベントに参照が登録されているメソッドを呼び返す(マルチキャストデリゲート)
        public void OnEvent1と5を持っています()
        {
            var eargs = new NestEa<string>
                        {
                            S1 = "OnEvent1@S1",
                            S2 = "OnEvent1@S2"
                        };

            var eargs2 = new NestEa<List<string>>
                         {
                             //new忘れずに！
                             S1 = new List<string>
                                  {
                                      "OnEvent5@S1"
                                  },
                             S2 = new List<string>
                                  {
                                      "OnEvent5@S2"
                                  }
                         };

            if (OnEvent1 != null) OnEvent1(this, eargs);
            if (OnEvent5 != null) OnEvent5(this, eargs2);
        }

        /// <summary>
        /// 呼び出されるメソッド：イベントの参照を持っている
        /// </summary>
        public void OnEvent2を持っています()
        {
            var eargs = new NestEa<int>
                        {
                            S1 = 100,
                            S2 = 200
                        };

            if (OnEvent2 != null) OnEvent2(this, eargs);
        }

        /// <summary>
        /// 呼び出されるメソッド：イベントの参照を持っている
        /// </summary>
        public void OnEvent3を持っています()
        {
            var eargs = new NestEa<List<string>> //TはList<string>型になる
                        {
                            S1 = new List<string>
                                 {
                                     "OnEvent3@S1",
                                     "a",
                                     "b",
                                     "c",
                                     "d",
                                     "e"
                                 },
                            S2 = new List<string>
                                 {
                                     "OnEvent3@S2",
                                     "f",
                                     "g",
                                     "h",
                                     "i",
                                     "j"
                                 }
                        };

            if (OnEvent3 != null) OnEvent3(this, eargs);
        }

        /// <summary>
        /// 呼び出されるメソッド：イベントの参照を持っている
        /// </summary>
        public void OnEvent4を持っています()
        {
            var eargs = new NestEa<List<int>> //TはList<int>型になる
                        {
                            S1 = new List<int>
                                 {
                                     1000,
                                     10,
                                     100,
                                     1
                                 },
                            S2 = new List<int>
                                 {
                                     2,
                                     20,
                                     200,
                                     2000
                                 }
                        };

            if (OnEvent4 != null) OnEvent4(this, eargs);
        }
    }

    #endregion
}