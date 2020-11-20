using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpKeywordSample_1
{
    class 型推論と匿名型
    {
        //型推論：var キーワードを使用　初期値を伴わない宣言はエラー
        public void 型推論()
        {
            var n = 1;
            var x = 1.0;
            var s = "test";
        }


        //匿名型(anonymous type)：自動的に型が生成される
        public void 匿名型()
        {
            var x = new { FamilyName = "匿名", FirstName = "型" };
            Console.Write("\r\n★★★匿名型★★★\r\n");
            Console.Write(x.FamilyName + x.FirstName);
            Console.ReadKey();


            //不変性：自動生成されたクラスの、自動実装されたプロパティには set アクセサーがない = 読み取り専用（immutable: 不変）になる

            //var p = new Point { X = 1, Y = 2 }; 通常の※オブジェクト初期化子
           　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　 /*　初期化子で指定できるのは public なメンバー変数またはプロパティのみ
                　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　初期化子を書く場所によっては protected や internal も可　*/
            // Point p = new Point();
            // p.X = 1;
            // p.Y = 2;
            // と同じ意味。


            //　匿名型のオブジェクト初期化子は、コンストラクター呼び出しに置き換えられる
            var anonymous = new { X = 1, Y = 2 };
            // __Anonymous anonymous = new __Anonymous(1, 2);
            Console.Write("\r\n" + anonymous.X + "\r\n" + anonymous.Y);
            Console.ReadKey();


        }
        
    }

    /*　プロパティ名の省略
    　　他のクラスのプロパティを初期化子に渡す場合、プロパティ名 =」の部分を省略することも可能
    　　　　　　　　　　　　　※初期化子で渡したプロパティの名前がそのまま匿名クラスでも使用される　*/

    struct 構造体Sample
    {
        public int X { set; get; }//struct 構造体Sample のプロパティ
        public int Y { set; get; }
        public int Z { set; get; }
    }


    /*　LINQとの組み合わせ
      　その場限りの使い捨てクラスとなるため、普段はあまり使用しない
      　基本的にはLINQのために存在する機能だと考えて良い　*/
    class 匿名型Sample
    {
        public void 匿名型2()
        {
            var a = new 構造体Sample //aにstruct 構造体Sample のインスタンスがある
                    {
                        X = 0,
                        Y = 1,
                        Z = 2
                    };

            var anonymous2 = new     //anonymous2に匿名型のインスタンスがある　struct 構造体SampleからXとYを持ってきている
                             {
                                 a.X,
                                 a.Y
                             };
　　　　　　　　
            //↑ new { X = a.X, Y = a.Y } と同じ意味
            //anonymous2に入っている匿名型はXとYを持っており、X=0,Y=1 である

            Console.Write("\r\n" + anonymous2.X + "\r\n" + anonymous2.Y + "\r\n");
            Console.ReadKey();

        }

    }
}
