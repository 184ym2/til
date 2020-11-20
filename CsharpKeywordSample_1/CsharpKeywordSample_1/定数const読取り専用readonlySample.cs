using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpKeywordSample_1
{
    //全く変化しない値を、異なる場所で何度も使いたい事がある場合、「リテラル」を何箇所にも分散させて書くのではなく、
    //const というキーワードを用いて定義した定数を使うべき

    //書き換えが一気にできる,リテラルと同等の処理速度を保てる,定数であることがひと目で分かる

    class 定数const読取り専用readonlySample
    {
        //const キーワードを使って、定数（値が絶対に変わらない / 変えれない変数）を定義できる
        //定数は、宣言時に値をリテラルで初期化できるもののみ使用可能（new できない）
        //例：int などの数値型、string 型、または列挙型　値が null 限定で参照型

        //constメンバー
        //public の場合はconstメンバー変数の使用は非推奨　本当に不変で、 絶対に変わることのない値以外は public const なメンバー変数にすべきではない
        public const double P1 = 3.1415926535897932;

        private const double P2 = 3.1415926535897932;

        //※constのバージョニング問題
        //定数は、コンパイル時にリテラルと全く同じように値が展開されてしまう
        //そのため定数を定義しているライブラリの方だけでなく、参照しているアプリ側も再コンパイルしないと、値の変化が反映されない


        //const キーワード
        //1. ローカル変数にも使える ※ローカル変数に対するconstはOK  
        //2. 常に静的変数と同じ扱い　　　　　3.　宣言時のみ初期化可能　　　　　　　
        //4. コンパイル結果はリテラルと同等　5. インスタンスを new で生成するようなものは使用不可

        //readonly キーワード　
        //1.　クラスのメンバー変数のみ　　　 2.　staticの有無を変更可能　　3.　コンストラクタ内で値を書き換え可能　
        //4.　コンパイル結果は変数と同等　　 5.　new 可能


        readonly int read;

        public 定数const読取り専用readonlySample(int read)
        {
            this.read = read;   // コンストラクタ内では書き換え可能
        }

        public void readonlyさんぷる(int num)
        {
            var x = this.read;  // 読み取りは可能
            //this.read = num;   // 書き込み不可 エラー！
        }


    }
}
