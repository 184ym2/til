using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpGenericSample_1
{
    internal class Program
    {
        /*メソッドEqual…ジェネリックを使って作成する*/
        public static bool Equal<T1>(T1 v1) where T1 : ITest /*where…<T>に入る型の条件を指定できる*/
        {
            /*T1は必ずITestを継承しなければならない*/
            return v1.value1 == v1.value2; /*ITestにはvalue1とvalue2が存在するため return以降が成立する*/
        }

        // 配列の要素を Console.Write で画面に出力する

        static void 型引数を使用して他のジェネリッククラスをインスタンス化<T>(IList<T> list)
            　　　　　　　　　　　　　　　　　　　　　　　　　　　//IList<T>を実装している配列をインスタンス化する
            　　　　　　　　　　　　　　　　　　　　　　　　　　　//戻り値なし,引数IList<T>を継承しているすべてのものを受け付ける

        //インターフェースを実装しているクラスは実装しているインターフェースの型の変数にいれることができる = ここでいうlist = 配列
        {
            //foreach…コレクションのすべての要素を1回ずつ読み出すための構文
            foreach (var x in list)
                Console.Write("{0}\n",x);//xに配列の値を一つずつ入れている
            Console.ReadLine();
        }


        static void Main(string[] args)
        {
            /*クラスC1とC2をnewする*/
            var c1I = new C1();
            var c2I = new C2();

            //var r1 = Equal<C1>(c1I);
            //var r2 = Equal<C2>(c2I);

            Equal(c1I);/*C1のvalue1とvalue2は等しい*/
            Equal(c2I);/*C2のvalue1とvalue2は等しい*/


            //C# 2.0 以降、下限が0の一次元配列は自動的に IList<T> を実装する = メソッドの引数に指定されているIList<T>が使える理由       
            var ints = new[] //intsにintの配列が入っている <int>で配列をインスタンス化している
                       {
                           1,
                           25,
                           3,
                           456
                       };

            ints.Count();
            ints.First(); //LINQを記述できる

            //ジェネリックメソッドを呼び出し 引数はints=IList<T> このメソッドがないとintsに入っている配列はnewされない
            型引数を使用して他のジェネリッククラスをインスタンス化(ints);


            var list = new GenericList<int>();//GenericListをint型でインスタンス化,GenericListコンストラクタ呼び出し

            for (var x = 0; x < 10; x++)
            {
                list.追加(x);//xはint型
            }

            foreach (var i in list)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("\nDone");
            Console.ReadLine();
           
        }

        public class C1 : ITest/*クラスC1はITestを継承している*/
        {

            public int value1 { get; set; }

            public long value2 { get; set; }

        }

        public class C2 : ITest/*クラスC2はITestを継承している*/
        {

            public int value1 { get; set; }

            public long value2 { get; set; }

        }

    }

    public interface ITest /*ITestというインターフェース*/
    {
        int value1 { get; set; }/*プロパティ1*/

        long value2 { get; set; }/*プロパティ2*/
    }
}
