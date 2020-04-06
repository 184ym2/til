using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.Schema;

namespace CsharpDelegateSample_1
{

    #region 未定義デリゲートSample

    // ★★★デリゲート型は「デリゲートの定義時に指定した物と同じ戻り値と引数リストを持つメソッド(メソッドのメモリ番地)」を参照する事が可能

    // 戻り値：void　引数：T型 a
    internal delegate void GenericsDelegateA<in T>(T a);

    // 戻り値：T型　引数：T型 b
    internal delegate T2 GenericsDelegateB<T2>(T2 b);

    // 戻り値：void　引数：なし
    internal delegate void NoneGenericsDelegateC();

    // 戻り値：int型　引数：stringa型 s
    internal delegate string NoneGenericsDelegateD(int i);

    internal class 参照されるメソッドSample
    {
        public void 参照先メソッド1()
        {
            Console.Write("参照されたメソッド1");
            Console.ReadLine();
        }

        public void 参照先メソッド2<T>()
        {
            T a;

            Console.Write("参照されたメソッド2");
            Console.ReadLine();
        }

        public string 参照先メソッド3(int i)
        {
            return "参照されたメソッド3";
        }
    };

    #endregion

    #region 定義済みデリゲート：ジェネリック1

    internal class 定義済みデリゲートSample
    {
        /// <summary>
        /// int型を返すメソッド：登録するメソッドはdelegateの戻り値・引数と一緒でなければならない
        /// </summary>
        /// <param name="s">コメント</param>
        /// <param name="i">計算結果</param>
        public void Number(string s, int i)
        {
            Console.WriteLine(s + i);
            Console.ReadLine();
        }

        /// <summary>
        /// 足し算をするメソッド
        /// </summary>
        public int 加算(int x, int y)
        {
            return x + y;
        }
    }

    #endregion

    internal class Program
    {
        private static void Main(string[] args)
        {
            #region 未定義デリゲートSample

            //★delegate型はジェネリックで作成してあるが非ジェネリックのメソッドも指定可能
            //非ジェネリック,ジェネリック関係なく、型が統一されていることが重要
            //GenericsDelegateA<T>をstring型に決めた場合,代入するメソッドは全てstring型のものでなければいけない

            var a = new GenericsDelegateA<string>(参照先静的メソッド);
            //マルチキャストデリゲート
            a += 参照先静的メソッド3;
            a += 参照先静的メソッド5;
            a("GenericsDelegateA<string>");

            var b = new GenericsDelegateB<string>(参照先静的メソッド2);
            b("GenericsDelegateB<string>");

            //静的でないクラスとメソッドは一度newする
            var 参照されるメソッドを持つクラス = new 参照されるメソッドSample();
            var c = new NoneGenericsDelegateC(参照されるメソッドを持つクラス.参照先メソッド1);

            c += 参照されるメソッドを持つクラス.参照先メソッド2<int>;
            c += 参照されるメソッドを持つクラス.参照先メソッド2<decimal>;
            c += 参照先静的メソッド4;
            c();

            var d = new NoneGenericsDelegateD(参照されるメソッドを持つクラス.参照先メソッド3);
            d(12345);

            #endregion

            #region 定義済みデリゲートSample

            #region 定義済みデリゲート：非ジェネリック

            //void Action()　戻り値(Result)void 引数なし
            Action メッセ表示 = () =>
                               {
                                   Console.Write("message");
                                   Console.ReadLine();
                               };
            //⚠マルチキャストデリゲート：複数のメソッド参照を登録　戻り値のあるメソッドは最後の戻り値のみを取得する
            メッセ表示 += () =>
                         {
                             Console.Write("message2");
                             Console.ReadLine();
                         };

            Console.WriteLine("--------------------定義済みデリゲート：非ジェネリック--------------------");
            メッセ表示();
           
            #endregion

            #region 定義済みデリゲート：ジェネリック1

            var 定義済みデリゲートSample = new 定義済みデリゲートSample();
            //void Action<T>(T obj)　戻り値(Result)void 引数string,int
            Action<string, int> number = 定義済みデリゲートSample.Number;

            //TResult Func<T1, T2, TResult>(T1 arg1, T2 arg2)　戻り値(Result)int 引数int,int
            Func<int, int, int> plus1 = 定義済みデリゲートSample.加算;

            Func<int, int, int, int> func1 = (x, y, z) => x + y + z;

            //TResult Func<T1, T2, TResult>(T1 arg1, T2 arg2)　戻り値(Result)int 引数int,int
            Func<int, int, int> func2 = (x, y) => x - y;
            Func<int, int, int> func3 = (x, y) => x*y;
            Func<int, int, int> func4 = (x, y) => x/y;

            /*
              このメソッドと同じ動きをするが、通常のメソッドと違いラムダ式で書かれたメソッドには名前がない
              public int func2(int x,int y)
              {
                  return x - y;
              }
            */

            //⚠マルチキャストデリゲート：複数のメソッド参照を登録　戻り値のあるメソッドは最後の戻り値のみを取得する
            Action action = () => Console.WriteLine("マルチキャストデリゲートA");
            action += () => Console.WriteLine("マルチキャストデリゲートB");

            //numberというdelegateに登録されたNumberメソッドの引数(int)として、それぞれのメソッドの戻り値を使用している
            //numberだけで複数のメソッドが呼び出せる

            //-----結果同じ：30になる
            Console.WriteLine("--------------------定義済みデリゲート：ジェネリック1--------------------");
            定義済みデリゲートSample.Number("Numberに直接値を書き込み：", 30);
            定義済みデリゲートSample.Number("plus1メソッドを使用：", plus1(10, 20));
            number("plus1delegate：", plus1(10, 20));

            number("plus2加算：", func1(10, 20, 30));
            number("func1減算:", func2(10, 20));
            number("func2乗算:", func3(10, 20));
            number("func3除算:", func4(10, 20));

            action();

            #endregion

            #region 定義済みデリゲート：ジェネリック2

            //void Action<T>(T obj)　戻り値void 引数int
            Action<int> number2 = i =>
                                      {
                                          Console.WriteLine("これはラムダ式を使用しています");
                                      };
            number2 += Console.WriteLine;

            //TResult Func<T1, T2, TResult>(T1 arg1, T2 arg2)　戻り値int 引数int,int 
            Func<int, int, int> 加算2 = (x1, y1) => x1 + y1;

            //TResult Func<T1, T2, TResult>(T1 arg1, T2 arg2)　戻り値int 引数int,int 
            Func<int, int, int> 減算2 = (x2, y2) => x2 - y2;

            Console.WriteLine("--------------------定義済みデリゲート：ジェネリック2--------------------");
            number2(加算2(1000, 2000));
            number2(減算2(2000, 1000));

            #endregion

            #region 定義済みデリゲート：ジェネリック3　ラムダ式

            Console.WriteLine("--------------------定義済みデリゲート：ジェネリック3--------------------");
            //ジェネリック　TResult Func<T1, T2, TResult>(T1 arg1, T2 arg2)
            Func<int, int, int> plus = (p1, p2) => p1 + p2;
            Console.Write("答え　" + plus(5, 2));
            Console.ReadLine();

            //ジェネリック　TResult Func<T1, T2, TResult>(T1 arg1, T2 arg2)
            Func<string, string, string> strFunc = (st1, st2) => st1 + st2;
            Console.Write("答え　" + strFunc("れんしゅう", "AAA"));
            Console.ReadLine();

            //ジェネリック　TResult Func<T1, T2, TResult>(T1 arg1, T2 arg2)
            Func<string, int, string> strFunc2 = (str, i) => str + i;
            Console.Write("答え　" + strFunc2("れんしゅう", 50));
            Console.ReadLine();

            const int f3 = 5;
            Func<int, int, int> intFunc = (f1, f2) => f1 + f2 - f3;
            Console.Write("答え　" + intFunc(10, 2));
            Console.ReadLine();

            #endregion

            #region List<T>の<T>に定義済みデリゲートを使用

            Console.WriteLine("--------------------List<T>の<T>に定義済みデリゲートを使用--------------------");

            var matrix = new List<Action> //List<T>の<T>：Actionのdelegate型　戻り値void 引数なし
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

            const int index = 0;
            const int index1 = 1;

            matrix[index]();
            matrix[index1]();

            var matrix2 = new List<Action<string>> //List<T>の<T>：Action<T>(T obj)のdelegate型　戻り値void 引数string
                          {
                              st1 =>
                                  {
                                      Console.Write("st1：" + st1);
                                      Console.ReadLine();
                                  },
                              st2 =>
                                  {
                                      Console.Write("st2：" + st2);
                                      Console.ReadLine();
                                  }
                          };

            const int i0 = 0;
            const int i1 = 1;

            matrix2[i0]("ステータスは0です");
            matrix2[i1]("ステータスは1です");

            #endregion

            #endregion
        }

        #region 未定義デリゲートSample

        //delegate型の参照に関するメソッド
        private static void 参照先静的メソッド<T>(T n) //戻り値なし,引数T型n
        {
            Console.Write("参照された静的メソッド1({0}) が呼ばれました。\n", n);
            Console.ReadLine();
        }

        public static T2 参照先静的メソッド2<T2>(T2 n) //戻り値T2型,引数T2型n
        {
            Console.Write("参照された静的メソッド2({0}) が呼ばれました。\n", n);
            Console.ReadLine();
            return n;
        }

        public static void 参照先静的メソッド3<T>(T n) //戻り値なし,引数T型n
        {
            Console.Write("参照された静的メソッド3({0}) が呼ばれました。\n", n);
            Console.ReadLine();
        }

        public static void 参照先静的メソッド4() //戻り値なし,引数なし
        {
            Console.Write("参照された静的メソッド4が呼ばれました");
            Console.ReadLine();
        }

        public static void 参照先静的メソッド5(string n) //戻り値なし,引数string型n
        {
            //引数(int n)にするとエラー
            Console.Write("参照された静的メソッド5({0}) が呼ばれました。\n", n);
            Console.ReadLine();
        }

        #endregion
    }
}