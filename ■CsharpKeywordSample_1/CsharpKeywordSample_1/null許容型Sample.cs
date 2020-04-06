using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpKeywordSample_1
{
    //ポイント
    //★値型Tに対して、T?という書き方で null許容型になる　★null許容型は、元となる値型の値か nullを保持できる型
    //★参照型には?をつけることが出来ない

    class Null許容型Sample
    {
        //★例1：以下の変数は同じ型の変数である　T?という書き方で得られるnull許容型は、コンパイルするとNullable<T>構造体と等価になる
        //リフレクションで型情報を取り出した場合、null許容型はNullable<T>構造体に見える
        int? x;
        Nullable<int> y;


        //このNullable<T>構造体は、 [HasValue]というbool型のプロパティ + [Value]というT型のプロパティを持っている

        //戻り値：boll　プロパティ：HasValue	有効な（nullでない）値を持っていれば true、 値が null ならば false を返す      
        //戻り値：T     プロパティ：Value	有効な値を返す。 もし、HasValue が false（値がnull）だった場合、 例外 InvalidOperationException を投げる

        //★例2：T → T? の暗黙の型変換は常に可能　基になる値型の場合と同様に Null許容型に値またはnull値を代入できる　
        double? pi = 3.14;
        char? letter = 'a';

        private const int M2 = 10;
        int? M = M2;

        bool? flag = null;

        // NULL可能タイプの配列
        int?[] arr = new int?[10];  

        //★例3：T? → T の変換は、HasValue が true のときのみ可能　 HasValue が false の時には InvalidOperationException を投げる
        static int? Null許容型int = null;

        //Null 許容型の値を Null 非許容型に代入する必要がある場合,
        //Null 合体演算子 ?? を使用して、Null 許容型の値が null の場合に代入される値を指定する

        public int Null非許容型int = Null許容型int ?? -1;　 // c = nullでない場合はd = c  c = nullである場合はd = -1

        public void Null許容型変換さんぷる()
        {
            Console.Write("\r\n★★★Null許容型★★★\r\n");
            Console.Write("int型m2：" + M2);
            Console.Write("\r\nnull許容型 int? mに int型m2(10)を代入：" + M);
            Console.Write("\r\nnull許容型 bool? flagに bool型nullを代入：" + flag);

            Console.Write("\r\nnull許容型 int?配列 arrに 10個の領域を作成：" + arr + "\r\n");
            Console.Write("\r\nint?型cがnullでない場合d = c,nullならば-1\r\n" + Null非許容型int + "\r\n");
        }       

    }
}
