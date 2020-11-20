using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpKeywordSample_1
{
    /*　何度も出てくる処理は関数化する　メソッド ＝ 関数　
     *  「関数」的な動作：何らかの値を受け取って、処理して、結果の値を返すような挙動をするもの 
     *  
　　　　1.メソッド
　　　　　拡張メソッド(参考:「拡張メソッド」)
　　　　2.コンストラクター(参考:「コンストラクターとデストラクター」)
　　　　3.プロパティ(参考:「プロパティ」)
　　　　4.インデクサー(参考:「インデクサー」)
　　　　5.イベント(参考:「イベント」)
　　　　6.演算子(参考:「演算子のオーバーロード」)
　　　　7.ユーザー定義の型変換(参考:「演算子のオーバーロード」)
　　　　8.デストラクター(参考:「コンストラクターとデストラクター」)　→ これら全てを関数メンバー(function member)と呼ぶ
     * 
     */

    class 構造化_関数
    {
        public double 関数定義(string message)//double：戻り値　関数定義：メソッド名　(double x)：引数(入力の型と入力された値を保持するための変数)
        {
            Console.Write("\r\n★★★関数定義★★★\r\n");
            double x;
            while (true)
            {
                try
                {
                    // 入力を促すメッセージを表示して、値を入力してもらう
                    Console.Write(message);
                    x = double.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    // 不正な入力が行われた場合の処理
                    Console.Write(
                                  "error : 正しい値が入力されませんでした\n入力しなおしてください\n");
                    continue;
                }
                break;
            }
            return x;//出力にしたい値：戻り値(return value)
            /* return ・関数の途中に書く
                      ・1つの関数内に複数書く 複数個のreturn → 条件分岐など */

            Console.WriteLine("ここは実行されない"); //retuenよりも後ろの文は実行されない
        }

        public double 引数が複数(double x, double y, double z)//引数リスト
        {
            // ノルムの計算
            return x * x + y * y + z * z;
        }

        ulong _seed = 4275646295673547UL;
        public ulong 引数が無い()//引数リストを空にする
        {
            // 線形合同法による疑似乱数の生成
            unchecked { _seed = _seed * 1566083941UL + 1; }
            return _seed;
        }

       
        public void 戻り値なし(int x)//戻り値の型をvoidにする
        {
            if (x <= 0) return;
            //returnは書けるが、returnの後ろには何も値を書かず、途中でメソッドを抜けるという意味になる

            Console.WriteLine("x が正の時だけ実行される");

            //戻り値のないものでも「関数(メソッド)」と呼ぶのはC言語やC++言語から受け継いだ習慣
            //その他の言語では「サブルーチン」「プロシージャ」と呼んで関数と区別する場合もある
        
        }


        //delegate 戻り値がある場合：Funk　ない場合：Action 

        public void 戻り値なし2(int x)
        {

            Action x1 = X1; // X1は戻り値がないので、Func<void> とは書けない
            Action<int> x2 = X2;
            Func<int> y1 = Y1; 
            Func<int, int> y2 = Y2;

            //ActionとFunkでバラバラになってしまう
        }

        static void X1()// 戻り値がないと、=> 記法も使えない
        {
        } 

        static void X2(int x)
        {
        }

        //private static int Y1() => 0;
        static int Y1()
        {
            return 0;

        }

        //private static int Y2(int x) => x; 簡略化した書き方(C#6.0~) 戻り値の型 関数名(引数一覧) => 関数本体の式
        static int Y2(int x)
        {
            return x;
        }


        //unit (単位元)：数学用語
        //0 = { }   … 0とは空っぽ(0要素)の集合 
        //1 = { 0 } … 1とは0のみを持つ(1要素の)集合 → unit 
            
        struct Unit { }//意味のない値を1つだけ持つ型(構造体)　
                       //構造体の場合、宣言した時点でいわゆる「0初期化」状態
                       //全てのメンバーに対して、0、もしくはそれに類する値が入る
        public void 戻り値なし3(int x)
        {
            //voidの代わりにUnitを使うことで、全てFunkに統一できる
            Func<Unit> a1 = A1;
            Func<int, Unit> a2 = A2;
            Func<int> f1 = F1;
            Func<int, int> f2 = F2;
        }
        
        //static Unit A1() => default(Unit); 
        static Unit A1()
        {
            return default(Unit);// 空っぽの値を返しておく
        }

        //static Unit A2(int x) => default(Unit);
        static Unit A2(int x)
        {
            return default(Unit);
        }

        //static int F1() => 0;
        static int F1()
        {
            return 0;
        }

        //static int F2(int x) => x;
        static int F2(int x)
        {
            return x;
        }


        //C#では、基本的に戻り値は1つだけを返す
        //複数の値(多値)を返したいこともあるが、その場合(C# 6以前)は複合型を1つ作って返していた
        struct SumCount
        {
            //複合型
            public int sum;
            public int count;
        }

        static SumCount 複数の戻り値(IEnumerable<int> items)
        {
            var sum = 0;
            var count = 0;
            foreach (var x in items)
            {
                sum += x;
                count++;
            }
            return new SumCount { sum = sum, count = count };
        }

        //C#7 より以下の書き方が可能になった
        //static (int sum, int count)

        //private Tally(int[] items)
        //{
        //    var sum = 0;
        //    var count = 0;
        //    foreach (var x in items)
        //    {
        //        sum += x;
        //        count++;
        //    }
        //    return (sum, count);
        //}

        //実際には、(int sum, int count)という「名前のない型」(これをタプルと呼ぶ)を1つ作り、その値を返している
    }
}
