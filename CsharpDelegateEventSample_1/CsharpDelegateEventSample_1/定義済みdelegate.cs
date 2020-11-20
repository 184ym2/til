using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpDelegateEventSample_1
{
    public class 定義済みdelegate
    {
        public void show()
        {
            var calc1 = new Calculation_1();
            var calc2 = new Calculation_2();

            // イベント駆動型で例えるとこの部分は、Sender(送信者/イベント元)

            // ★デリゲート型は「デリゲートの定義時に指定した物と[同じ戻り値と引数リストを持つメソッド](メソッドのメモリ番地)」を参照する事が可能

            // ★メソッド本体が１文の場合、{ }とreturnを省略できる　※Actionは戻り値がないのでそもそもreturn不要
            // ★引数が１つの場合は( )を省略できる

            #region　定義済みデリゲート：ラムダ式内で単一の処理を行う

            Console.WriteLine("--------------------定義済みデリゲート：ラムダ式内で単一の処理を行う--------------------");

            Action<string, int> action1 = calc1._Action1;
            Action<string, int> action3 = (x, y) => Console.WriteLine(x + y);

            Func<int, int, int> func1 = calc1._Func1;
            Func<int, int, int> func2 = (x, y) => x - y;
            Func<int, int, int> func3 = (x, y) => x*y;

            /*
               このメソッドと同じ動きをするが、通常のメソッドと違いラムダ式で書かれたメソッドには名前がない
               public int func2(int x, int y)
               {
                   return x - y;
               }
             */

            Func<int, int, int, int> func4 = (x, y, z) => x + y + z;

            Func<int, int> func5 = x => x + 2;

            // デリゲートの実行：xxx();で実行可能
            // 結果は全て同じ：30になる
            calc1._Action1("calc1._Action1：", 30);
            calc1._Action1("func1：", func1(10, 20));

            calc2._Action2("calc1._Action2：", 30);
            calc2._Action2("func1：", func1(10, 20));

            Console.WriteLine("calc2._Func2：" + calc2._Func2(30, 0));

            action1("func1：", func1(10, 20));
            action1("func2：", func2(10, 20));
            action1("func3：", func3(10, 20));
            action1("func4：", func4(10, 10, 10));
            action1("func5：", func5(30));

            action3("calc1._Func1：", calc1._Func1(10, 20));

            #endregion

            #region　定義済みデリゲート/★マルチキャストデリゲート：複数のメソッド参照を登録　戻り値のあるメソッドは最後の戻り値のみを取得する

            Console.WriteLine("--------------------定義済みデリゲート：マルチキャストデリゲート--------------------");

            // Action 戻り値：void　引数：なし
            Action mCdelegate1 = () => Console.WriteLine("引数なし：マルチキャストデリゲートA");
            mCdelegate1 += () => Console.WriteLine("引数なし：マルチキャストデリゲートB");
            mCdelegate1();

            // Action 戻り値：void　引数：なし
            Action<string> mCdelegate2 = s => Console.WriteLine(s + "マルチキャストデリゲートA");
            mCdelegate2 += s => Console.WriteLine(s + "マルチキャストデリゲートB");
            mCdelegate2("引数あり：");

            //Action 戻り値：void　引数：なし
            Action action = () =>
                                {
                                    Console.Write("Action：message");
                                    Console.ReadLine();
                                };
            action += () =>
                          {
                              Console.Write("Action：message2");
                              Console.ReadLine();
                          };
            action();

            // Func 戻り値：string　引数：なし
            Func<string> func = () =>
                                    {
                                        Console.Write("Func：message1");
                                        return "あああ";
                                    };
            func += () =>
                        {
                            // ★マルチキャストデリゲートで複数のメソッド参照を登録すると、戻り値のあるメソッドは最後の戻り値のみを取得する
                            Console.Write("Func：message2");
                            return "あああ";
                        };
            func();

            #endregion

            #region　定義済みデリゲート：ラムダ式内で複数の処理を行う

            Console.WriteLine("--------------------定義済みデリゲート：ラムダ式内で複数の処理を行う--------------------");

            // Action　戻り値：void　引数：int
            Action<int> action2 = i =>
                                      {
                                          Console.WriteLine("1回目の回答です：" + i);
                                          Console.WriteLine("2回目の回答です：" + i);
                                          Console.WriteLine("3回目の回答です：" + i);
                                      };

            action2 += i => Console.WriteLine("合計した回答です：" + i + i + i);

            // Func　戻り値：int　引数：int,int       
            Func<int, int, int> puls = (x1, y1) => x1 + y1;
            Func<int, int, int> minus = (x2, y2) => x2 - y2;

            action2(puls(10, 2));
            action2(minus(5, 1));

            #endregion
        }

        public void show2()
        {
            #region List<T>の<T>に定義済みデリゲートを使用

            Console.WriteLine("--------------------List<T>の<T>に定義済みデリゲートを使用--------------------");

            var list1 = new List<Action> // Action　戻り値：void　引数：なし
                        {
                            () =>
                                {
                                    Console.Write("0番目");
                                    Console.ReadLine();
                                },
                            () =>
                                {
                                    Console.Write("1番目");
                                    Console.ReadLine();
                                }
                        };

            const int index0 = 0;
            const int index1 = 1;
            list1[index0]();
            list1[index1]();

            var list2 = new List<Action<string>> // Action　戻り値：void　引数：string
                        {
                            s =>
                                {
                                    Console.Write("0番目：" + s);
                                    Console.ReadLine();
                                },
                            s =>
                                {
                                    Console.Write("1番目：" + s);
                                    Console.ReadLine();
                                }
                        };

            const int st0 = 0;
            const int st1 = 1;
            list2[st0]("ステータスは0です");
            list2[st1]("ステータスは1です");

            #endregion
        }
    }

    #region 登録対象のメソッド

    public class Calculation_1
    {
        /// <summary>
        /// 戻り値なし/引数string,int：Action[T1, T2]の参照先になる
        /// </summary>
        public void _Action1(string s, int i)
        {
            Console.WriteLine(s + i);
            Console.ReadLine();
        }

        /// <summary>
        /// 戻り値int/引数int,int：Func[T1, T2, TResult]の参照先になる
        /// </summary>
        public int _Func1(int x, int y)
        {
            return x + y;
        }
    }

    public class Calculation_2
    {
        /// <summary>
        /// 戻り値なし/引数string,int：Action[T1, T2]の参照先になる
        /// </summary>
        public void _Action2(string s, int i)
        {
            Console.WriteLine(s + i);
            Console.ReadLine();
        }

        /// <summary>
        /// 戻り値int/引数int,int：Func[T1, T2, TResult]の参照先になる
        /// </summary>
        public int _Func2(int x, int y)
        {
            return x + y;
        }
    }

    #endregion
}