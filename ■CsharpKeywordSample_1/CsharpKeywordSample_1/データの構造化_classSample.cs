using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpKeywordSample_1
{
    //　複合型: 複数のデータを1つにまとめて使うための型　クラス(class)または構造体(struct)

    /*　■クラスのみができること■　参照型　継承できる　多態性使用不可
    　　他のクラスから派生(他のクラスを継承)する　継承に関連する修飾子(abstract, sealed, virtual, overrideなど)を使える
    　　静的クラス
    　　引数なしのコンストラクターの定義　デストラクターの定義*/

    //　★部分クラス：分割された部分に partial というキーワードを付ける

    /*　★部分メソッド（partial method）：部分クラス内限定で、メソッドに partial を付けることでメソッドの宣言と定義を分割できる
    　　利用場面としては、 宣言側は人手で書いて、 定義側はツールで自動生成というようなものを想定している
    　　これと似たようなことは「仮想メソッド」や「イベント」とクラスの継承を使っても可能　
    　　だが部分メソッドのほうがパフォーマンスに関しては非常に優れている　*/

    //　※partialという単語がキーワード扱いされるのは、class、struct、interface、voidの直前のみ※
    partial　class データの構造化_ClassSample
    {
        public void 部分メソッド()
        {
            Console.Write("\r\n★★★データの構造化：部分メソッド★★★\r\n");
            OnBeginProgram();
            Console.Write("program body\n");
            OnEndProgram();
            Console.ReadKey();

            Console.Write("\r\n★★★データの構造化：部分メソッドの引数で起こる副作用★★★\r\n");
            var x = 1;//メソッドの実装がない場合こちらが呼び出し
            部分メソッドの引数で起こる副作用(x = 2);//メソッドの実装がある場合こちらが呼び出し
            Console.Write("{0}\n", x);
            Console.ReadKey();
        }

        static partial void OnBeginProgram();
        static partial void OnEndProgram();

        static partial void 部分メソッドの引数で起こる副作用(int x);
    }

    partial class データの構造化_ClassSample
    {
        static partial void OnBeginProgram()
        {
            Console.Write("check pre-condition\n");
        }

        static partial void OnEndProgram()
        {
            Console.Write("check post-condition\n");
        }

        //ここの実装が同じファイルにあるとは限らない　知らないところで実行結果が変更される恐れがある
        static partial void 部分メソッドの引数で起こる副作用(int x)　
        {
            Console.Write(x);
        }
    }



    //★thisアクセス：このインスタンス自身」を表す特別な変数
    class thisアクセスSample
    {
        int x;　//フィールド
        int y;      

        public thisアクセスSample(int x, int a)　//コンストラクタ
        {
            // this. が付いている方はフィールド
            // ついていない方は引数
            this.x = x;

            // y の方は this. を付けなくても、他に候補がないのでフィールドの y
            y = a;

            // この場合、this. を付けても y と同じ意味
            var b = this.y;
        }

        //またはメソッドの引数に自分自身を渡したりするときに使用
    }

}
