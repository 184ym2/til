using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpKeywordSample_1
{
    //　複合型: 複数のデータを1つにまとめて使うための型　クラス(class)または構造体(struct)

    /*　■構造体ができること(これらはクラスでも可能)■　値型　継承できない　多態性使用可能
    　　引数なしコンストラクター、デストラクター以外のメンバー定義
    　　インターフェイスの実装(複数も可)
    　　(構造体自身にはstatic修飾子を付けれないものの)静的メンバーの定義自体は可能　*/

    /*　構造体は以下の条件が揃っている場合のみ使用する
    　　　1.データのサイズが小さい（目安としては16バイト程度以下）
    　　　2.絶対に継承しないと分かっている
    　　　3.変数への代入がコピーを生むというのが許容できる　*/

    /*　クラス(newするまでメモリ領域を確保しない)と違って、構造体は宣言した時点でデータを記録するためのメモリ領域が確保される
    　　構造体の場合、いわゆる「0初期化」状態になっている　全てのメンバーに対して、0、もしくはそれに類する以下のような値が入る　*/



    internal struct データの構造化_SturctSample
    {
        // ※構造体の規定値(default value)※
        public int I; // 1.数値型(int, doubleなど)の場合は0　列挙型も、0 に相当する値
        public double D;
        public bool B; // 2.bool 型の場合は false
        public string S; // 3.参照型(string、配列、クラス、デリゲートなど)やNull許容型の場合は null       　

    }


    internal struct データの構造化_SturctSample2
    {
        /*　構造体のメンバーとして、引数なしのコンストラクターを書くことはできない　
        　  これは、引数なしのコンストラクターを規定値(0初期化)として使うせい　　　*/
        public int X;

        public int Y;

        public データの構造化_SturctSample2(int x, int y) //コンストラクタ
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return X + "　" + Y + "\n";
        }

    }
  
    internal struct データの構造化_SturctSample3
    {
        /*　new T() やdefault(T)で作る「既定値」とは違って、 
       引数付きのコンストラクターを使う場合は、コンストラクター内で全てのメンバーをきっちり自分の手で初期化する必要がある　*/

        private int _a;
        private int _b; //一つでも初期化し忘れるとコンパイルエラー　※classの場合は制限なし

        public データの構造化_SturctSample3(int a, int b)
        {
            //確実な初期化();  コンパイルエラー　全てのフィールドを初期化するまでプロパティやメソッドなどが呼べない　※classの場合は制限なし
            _a = a;
            _b = b;
            確実な初期化(); // この順ならOK
        }

        public void 確実な初期化()
        {

        }

    }

    //C#5.0 までは自動プロパティの初期化が非常に面倒だった　C#6 以降自動プロパティも初期化できるようになった
     /*　　こんな感じ C#6 以降～

     public struct Point
     {
         public int X { get; }

         public int Y { get; }

         public Point(int x, int y)
         {
             X = x;
             Y = y;
         }
     }

     */

    public class SturctSample
    {
        private static データの構造化_SturctSample s;

        public void 構造体の既定値()
        {
            Console.Write("\r\n★★★データの構造化：構造体の既定値★★★\r\n");
            Console.WriteLine("int型の既定値　" + s.I);
            Console.WriteLine("\ndouble型の既定値　" + s.D);
            Console.WriteLine("\nbool型の既定値　" + s.B);
            Console.WriteLine("\nstring型の既定値　" + s.S);
            Console.ReadKey();
        }


        //引数なしのコンストラクタは作成できないが、newやdefaultを使い引数なしで呼び出すことは可能
        //C#2.0 以降default(T) で既定値を作れる仕様が入ったので、実は、「C# の構造体には引数なしのコンストラクターが定義できない」仕様は今となっては不要だったり・・・
        public void 引数なしコンストラクタ()
        {
            var p1 = new データの構造化_SturctSample2(); // 既定値、つまり、「XもYも0に初期化」という意味で使用　※この場合はコンストラクターが呼ばれて欲しい
            var p2 = new データの構造化_SturctSample2(10, 20); // X=10, Y=20
            var p3 = default(データの構造化_SturctSample2); // C# 2.0 以降 p1と同じ意味　※こいつは既定値(0埋め)

            Console.Write("\r\n★★★データの構造化：引数なしコンストラクタ★★★\r\n");
            Console.WriteLine(p1);
            Console.WriteLine(p2);
            Console.WriteLine(p3);
            Console.ReadKey();
        }

    }



}
