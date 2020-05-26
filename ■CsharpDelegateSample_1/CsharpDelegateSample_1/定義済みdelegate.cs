using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpDelegateSample_1
{
    internal class Calculation_1
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

    internal class Calculation_2
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

    internal class 定義済みdelegate
    {
        public void _定義済みdelegate一覧1()
        {
            var calc1 = new Calculation_1();
            var calc2 = new Calculation_2();

            #region　定義済みデリゲート：ラムダ式内で単一の処理を行う

            //★メソッド本体が１文の場合、{ }とreturnを省略できる　※Actionは戻り値がないのでそもそもreturn不要
            //★引数が１つの場合は( )を省略できる

            //void Action<T1, T2>(T1 _t1, T2 _t2)　戻り値void/引数string,int
            Action<string, int> action1 = calc1._Action1;
            Action<string, int> action2 = (x, y) => Console.WriteLine(x + y);

            //TResult Func<T1, T2, TResult>(T1 _t1, T2 _t2)　戻り値int/引数int,int
            Func<int, int, int> func1 = calc1._Func1;
            Func<int, int, int> func2 = (x, y) => x - y;
            Func<int, int, int> func3 = (x, y) => x*y;

            /*
             * このメソッドと同じ動きをするが、通常のメソッドと違いラムダ式で書かれたメソッドには名前がない
            public int func2(int x, int y)
            {
                return x - y;
            }
             */

            //TResult Func<T1, T2, T3, TResult>(T1 _t1, T2 _t2, T3 _t3)　戻り値int/引数int,int,int
            Func<int, int, int, int> func4 = (x, y, z) => x + y + z;

            //TResult Func<T1, TResult>(T1 _t1)　戻り値int/引数int
            Func<int, int> func5 = x => x + 2;

            Console.WriteLine("--------------------定義済みデリゲート：ラムダ式内で単一の処理を行う--------------------");

            //結果は全て同じ：30になる
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

            action2("calc1._Func1：", calc1._Func1(10, 20));

            #endregion

            #region　★マルチキャストデリゲート：複数のメソッド参照を登録　戻り値のあるメソッドは最後の戻り値のみを取得する

            Action mCdelegate1 = () => Console.WriteLine("引数なし：マルチキャストデリゲートA");
            mCdelegate1 += () => Console.WriteLine("引数なし：マルチキャストデリゲートB");

            Action<string> mCdelegate2 = s => Console.WriteLine(s + "マルチキャストデリゲートA");
            mCdelegate2 += s => Console.WriteLine(s + "マルチキャストデリゲートB");

            mCdelegate1();
            mCdelegate2("引数あり：");

            #endregion

            #region　定義済みデリゲート：ラムダ式内で複数の処理を行う

            //★メソッド本体が１文の場合、{ }とreturnを省略できる　※Actionは戻り値がないのでそもそもreturn不要
            //★引数が１つの場合は( )を省略できる

            Action<int> action = i =>
                                     {
                                         Console.WriteLine("1回目の回答です：" + i);
                                         Console.WriteLine("2回目の回答です：" + i);
                                         Console.WriteLine("3回目の回答です：" + i);
                                     };

            action += i => Console.WriteLine("合計した回答です：" + i + i + i);

            //TResult Func<T1, T2, TResult>(T1 _t1, T2 _t2)　戻り値int 引数int,int 
            Func<int, int, int> puls = (x1, y1) => x1 + y1;

            //TResult Func<T1, T2, TResult>(T1 _t1, T2 _t2)　戻り値int 引数int,int 
            Func<int, int, int> minus = (x2, y2) => x2 - y2;

            Console.WriteLine("--------------------定義済みデリゲート：ラムダ式内で複数の処理を行う--------------------");
            action(puls(1000, 2000));
            action(minus(2000, 1000));

            #endregion
        }

        public void _定義済みdelegate一覧2()
        {
            #region List<T>の<T>に定義済みデリゲートを使用

            Console.WriteLine("--------------------List<T>の<T>に定義済みデリゲートを使用--------------------");

            var list1 = new List<Action> //List<T>の<T>：Action() 戻り値なし/引数なし
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

            var list2 = new List<Action<string>> //List<T>の<T>：Action<T>(T _t) 戻り値なし/引数string
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
}