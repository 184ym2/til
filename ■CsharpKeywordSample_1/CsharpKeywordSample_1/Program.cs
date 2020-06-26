using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpKeywordSample_1
{
    class Program
    {
        static void Main(string[] args)
        {

            //var enumSample = new EnumSample();
            //enumSample.Enumサンプル();
            //enumSample.Enumサンプル2();
            //enumSample.Enumサンプル3();
            //enumSample.Enumサンプル4();

            //var etcSample = new EtcSample();
            //etcSample.代入検証サンプル();

            var コレクションクラスの比較Sample = new コレクションクラスの比較Sample();
            コレクションクラスの比較Sample.各コレクションを比較する();

            //var attributeSample = new AttributeSample();
            //attributeSample.Attributeメソッド();

            //var attributeSample3 = new AttributeSample3();
            //attributeSample3.Attributeメソッド3();

            //var 組込み型演算子Sample = new 組込み型演算子Sample();
            //組込み型演算子Sample.論理演算子();
            //組込み型演算子Sample.関係演算();
            //組込み型演算子Sample.sizeof演算子();
            //組込み型演算子Sample.短絡評価();

            //var null許容型Sample = new Null許容型Sample();
            //null許容型Sample.Null許容型変換さんぷる();

            //var 拡張メソッド呼び出し = new 拡張メソッド呼び出し();
            //拡張メソッド呼び出し.拡張メソッドさんぷる();
            //拡張メソッド呼び出し.拡張メソッドさんぷる2();

            //var virtualSample呼び出し = new VirtualSample呼び出し();
            //virtualSample呼び出し.VirtualSample継承済みクラスをインスタンス化();

            //var 型推論と匿名型 = new 型推論と匿名型();
            //型推論と匿名型.匿名型();

            //var 匿名型Sample = new 匿名型Sample();
            //匿名型Sample.匿名型2();

            //var データの構造化ClassSample = new データの構造化_ClassSample();
            //データの構造化ClassSample.部分メソッド();

            //var sturctSample = new SturctSample();
            //sturctSample.構造体の既定値();
            //sturctSample.引数なしコンストラクタ();

            //var 構造化条件分岐 = new 構造化_条件分岐();
            //構造化条件分岐.switch文(1);
            //構造化条件分岐.フォールスルーの禁止(1);
            //構造化条件分岐.goto文_1(1);
            //構造化条件分岐.goto文_2();

            //var 構造化反復処理 = new 構造化_反復処理();
            //構造化反復処理.while文();
            //構造化反復処理.do_while文();

            //var 構造化関数 = new 構造化_関数();
            //// x, y にユーザーの入力した値を代入
            //var x = 構造化関数.関数定義("input x : ");
            //var y = 構造化関数.関数定義("input y : ");
            //// 入力された値を元に計算
            //var z = x * x + y * y;

            //x /= z;           // x =  x / z; と同じ。
            //y /= -z;          // y = -y / z; と同じ

            //// 計算結果を出力
            //Console.Write("({0}, {1})", x, y);
            //Console.ReadKey();
            
            //var ck =new オーバーフローのチェックSample();
            //ck.checkedSample();
            //ck.浮動小数点数型のオーバーフロー();

            var op引数 = new オプション引数();
            op引数.OP引数();      // オプション引数(0, 0, 0); 
            op引数.OP引数(1);     // オプション引数(1, 0, 0);
            op引数.OP引数(1, 2);  // オプション引数(1, 2, 0);
            op引数.OP引数2(1, 2); // オプション引数(1, 2, 0);
            op引数.OP引数3(1, 2);

            var 可変 = new 可変長引数();
            可変.可変長引数を使用する();
            
            


        }
        
    }
}
