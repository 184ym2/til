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


    internal class DelegateSample
    {
        private static void Main(string[] args)
        {
            var 定義済みdelegate = new 定義済みdelegate();
            定義済みdelegate._定義済みdelegate一覧1();
            
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