using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpKeywordSample_1
{
    ///<remarks>
    ///★★★参照型のフィールドに対して readonly★★★
    ///</remarks>    
    internal class MutableClass
    {
        // フィールドを直接公開
        public int X;

        // 書き換え可能なプロパティ
        public int Y { get; set; }

        // フィールドの値を書き換えるメソッド
        public void 書き換える(int value)
        {
            X = value;
        }
    }

    internal class Readonlyの注意点Sample
    {
        //MutableClassをインスタンス化
        private static readonly MutableClass C = new MutableClass();

        public void readonlyの注意点()
        {
            //↓これは許されない C は readonly なので、C 自体の書き換えはできない
            //c = new MutableClass();

            //CのXとY,メソッドには readonly がついていないので書き換え放題
            C.X = 1;
            C.Y = 2;
            C.書き換える(5); //X=5

            //Q.クラスを書き換えられないようにするには？
            //A.フィールドをreadonly にするか、プロパティをget-only(C#6 以降)にする
        }
    }

    ///<remarks>
    ///★★★値型のフィールドに対して readonly★★★
    ///</remarks>
    internal struct MutableStruct
    {
        // フィールドを直接公開
        public int X;

        // フィールドの値を書き換えるメソッド
        public void 書き換え2(int value)
        {
            X = value;
        }
    }

    internal class Readonlyの注意点Sample2
    {
        //MutableStructをインスタンス化
        private static readonly MutableStruct C = new MutableStruct();

        public void readonlyの注意点2()
        {
            Allowed();
        }

        private static void NotAllowed()
        {
            //↓これは許されない C は readonly なので、C 自体の書き換えはできない
            //C = new MutableStruct();

            // 構造体の場合、フィールドに関しては readonly な性質を引き継ぐ
            //そのため↓これも許されない
            //C.X = 1;
        }

        private static void Allowed()
        {
            // でも、メソッドは呼べてしまう
            C.書き換え2(3); // X を 3 で上書きしているはず？

            Console.WriteLine(C.X); // でも、X=0 のまま
            //↑のコードは、実はコピーが発生している　※コピーは常に発生する

            //readonlyであることを保証しつつメソッドを呼び出せるように
            //フィールドを一度コピーしてから、そのコピーに対してメソッドを呼ぶということをしている

            // 以下のコードと同じ意味になる

            var copy = C;
            copy.書き換え2(3);

            Console.WriteLine(C.X); // 書き換わるのは copy (コピー)の方なので、C.X は書き換わらない(=0)
            Console.WriteLine(copy.X); // もちろんこっちは書き換わる(=3)
        }
    }

    ///<remarks>
    ///★★★構造体の this 書き換え★★★
    ///</remarks>
    internal struct Point
    {
        // フィールドに readonly を付けているものの…
        public readonly int X;
        public readonly int Y;

        public Point(int x, int y) //C#7.0からは => 記号でコンストラクタなどを書くことができる
        {
            X = x;
            Y = y;
        }

        // this の書き換えができてしまうので、実は X, Y の書き換えが可能
        public void 書き換え3(int x, int y)
        {
            // X = x; Y = y; とは書けない
            // でも、this 自体は書き換えられる
            this = new Point(x, y);
        }
    }

    internal class Readonlyの注意点Sample3
    {
        public void readonlyの注意点3()
        {
            var point = new Point(1, 2);

            // p.X = 0; とは書けない。これはちゃんとコンパイル エラーになる

            // でも、このメソッドは呼べるし、X, Y が書き換わる
            point.書き換え3(3, 4);

            Console.WriteLine(point.X); // 3
            Console.WriteLine(point.Y); // 4
        }
    }

    //C#7.2 で構造体自体にreadonly修飾を付けられるようになった　7.2以降は書き換えを意図していない構造体に対してはreadonly修飾を付けるのが無難

    /*　⚠全てのフィールドに対して readonly を付けなければならなくなる⚠
      　get-onlyプロパティは使用可能(自動生成されるフィールドがreadonlyなので問題ない)
      　this参照もreadonly扱い
      　thisがreadonly扱いになるので、前節のようなthis書き換えの問題は起きない
      　⚠また readonly struct であれば、コピーは発生しない⚠　*/


    /*　フィールド直接参照なら問題ないが、メソッドを(プロパティも)呼ぶとコピー発生　という性質上、
      　書き換えが発生する構造体は、プロパティよりも、フィールドを直接publicにしてしまう方が都合がいいことがある　*/
    




}
