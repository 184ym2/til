using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpDelegateEventSample_1
{
    public class 未定義delegate
    {
        // イベント駆動型で例えるとこの部分は、Sender(送信者/イベント元)

        // ★デリゲート型は「デリゲートの定義時に指定した物と[同じ戻り値と引数リストを持つメソッド](メソッドのメモリ番地)」を参照する事が可能
        internal delegate void GenericsDelegateA<in T>(T t);

        internal delegate T GenericsDelegateB<T>(T t);

        internal delegate void NoneGenericsDelegateC();

        internal delegate string NoneGenericsDelegateD(int i);

        /*
          デリゲート型はジェネリックで作成していても、非ジェネリックのメソッドを追加可能
          ジェネリックの有無関係なく、デリゲートの型と登録するメソッドの型が一致されていることが重要
          
          例）Q. GenericsDelegateA<T>を、<T>▶string型に決めた場合
         　　 A. 登録するメソッド(＝デリゲートのインスタンス)はstring型であれば追加できる
         */

        public void show()
        {
            Console.WriteLine("--------------------未定義デリゲート：非ジェネリック--------------------");

            //A 
            var a = new GenericsDelegateA<string>(staticMethod1);
            a += staticMethod3;
            a += staticMethod5;
            a("GenericsDelegateA<string>");

            //B　
            GenericsDelegateB<string> b = staticMethod2; // C# 2.0 以降：newを省略した書き方も可能になった(糖衣構文)
            b("GenericsDelegateB<string>");

            //C　
            var pm = new 参照先publicMethod();
            NoneGenericsDelegateC c = pm.publicMethod1;
            c += pm.publicMethod2<int>;
            c += pm.publicMethod2<decimal>;
            c += staticMethod4;
            c();

            //D　
            NoneGenericsDelegateD d = pm.publicMethod3;
            d(12345);
        }

        #region 登録対象のメソッド

        private static void staticMethod1<T>(T n)
        {
            Console.Write("staticメソッド1({0}) が呼ばれました。\n", n);
            Console.ReadLine();
        }

        public static T staticMethod2<T>(T n)
        {
            Console.Write("staticメソッド2({0}) が呼ばれました。\n", n);
            Console.ReadLine();
            return n;
        }

        public static void staticMethod3<T>(T n)
        {
            Console.Write("staticメソッド3({0}) が呼ばれました。\n", n);
            Console.ReadLine();
        }

        public static void staticMethod4()
        {
            Console.Write("staticメソッド4が呼ばれました\n");
            Console.ReadLine();
        }

        public static void staticMethod5(string n)
        {
            Console.Write("staticメソッド5({0}) が呼ばれました。\n", n);
            Console.ReadLine();
        }
    }

    internal class 参照先publicMethod
    {
        public void publicMethod1()
        {
            Console.Write("publicメソッド1が呼ばれました\n");
            Console.ReadLine();
        }

        public void publicMethod2<T>()
        {
            var a = default(T);
            Console.Write("publicメソッド2({0}) が呼ばれました\n", a);
            Console.ReadLine();
        }

        public string publicMethod3(int i)
        {
            Console.Write("publicメソッド3({0}) が呼ばれました\n", i);
            return "publicメソッド3";
        }

        private static void staticMethod1<T>(T n)
        {
            Console.Write("staticメソッド1({0}) が呼ばれました。\n", n);
            Console.ReadLine();
        }

        public static T staticMethod2<T>(T n)
        {
            Console.Write("staticメソッド2({0}) が呼ばれました。\n", n);
            Console.ReadLine();
            return n;
        }

        public static void staticMethod3<T>(T n)
        {
            Console.Write("staticメソッド3({0}) が呼ばれました。\n", n);
            Console.ReadLine();
        }

        public static void staticMethod4()
        {
            Console.Write("staticメソッド4が呼ばれました\n");
            Console.ReadLine();
        }

        public static void staticMethod5(string n)
        {
            Console.Write("staticメソッド5({0}) が呼ばれました。\n", n);
            Console.ReadLine();
        }

        #endregion
    };
}