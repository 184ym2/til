using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpKeywordSample_1 /*対象キーワード[virtual][base]*/
{
    class VirtualSample
    {
        /*クラス内メソッド外に記述する*/
        /*外部に公開するインスタンス変数は[フィールド] */ 
        /*外部に公開しないインスタンス変数は[インスタンス変数]のまま*/
        public string Name;
        public int Age;
       
        /*コンストラクタ(初期化)引数付き newしたときに呼び出される クラス名と同じ名前で定義*/
        public VirtualSample(string Name, int Age)
        {
            this.Name = Name;
            this.Age = Age;       
        }
        /*プロパティ クラス外部から見るとインスタンス変数のように振る舞い、クラス内部から見るとメソッドのように振舞うもの*/
        public string 名前 { get { return Name; } }

        /*仮想プロパティ 継承先でoverrideできる(任意) overrideしなければここの処理が実行される*/
        public virtual int 年齢 { get { return Age; } }

    }

    class そのまま返す : VirtualSample
    {
        public そのまま返す(string Name, int Age)
            : base(Name, Age)　//virtualSampleコンストラクタにアクセス
            //base：派生クラス内から基底クラスのメンバーにアクセス可能
        {
        }

        public override int 年齢 { get { return this.Age; } } /*年齢をそのまま返す*/

    }

    class いいかげんに返す : VirtualSample
    {
        public いいかげんに返す(string Name, int Age)
            : base(Name, Age) //virtualSampleコンストラクタにアクセス
        {
        }

        public override int 年齢 { get { return ((this.Age + 5) / 10) * 10; } }/*年齢を四捨五入して返す*/

    }

    class 毎日17歳 : VirtualSample
    {
        public 毎日17歳(string Name, int Age)
            : base(Name, Age) //virtualSampleコンストラクタにアクセス
        {
        }

        public override int 年齢 { get { return 17; } }/*年齢を四捨五入して返す*/

    }

    public class VirtualSample呼び出し
    {
        //こちらだけMainで呼び出す
        public void VirtualSample継承済みクラスをインスタンス化()
        {
            /*インスタンス化 メモリ上にクラスがコピーされる */
            /*クラスは参照型 実体をヒープに保存し 実体が保存された先頭のメモリアドレスをスタックに保存する*/

            //↓このメソッド内で各クラスをnewする
            Console.Write("\r\n★★★VirtualSample★★★\r\n");
            答えをコンソールに表示(new そのまま返す("ursys", 25));
            答えをコンソールに表示(new いいかげんに返す("ursys", 25));
            答えをコンソールに表示(new 毎日17歳("ursys", 25));
        }


        //newしなくても使用可能
        static void 答えをコンソールに表示(VirtualSample v)
        {
            Console.Write("\r\n私の名前は{0}です\n", v.名前);
            Console.Write("私は{0}歳です\r\n", v.年齢);
            
        }

    }

    
}
