using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpKeywordSample_1
{
    //オーバーフロー（overflow）
    //コンピュータの内部で扱える値の範囲は限られている　そのため、計算を行っている途中で計算結果がこの範囲を超えてしまうことがある

    class オーバーフローのチェックSample
    {
        //オーバーフローを起こされるとまずい場合、 何らかの方法でオーバーフローを検出する必要がある
        public void checkedSample()
        {
            try
            {
                checked　//★checked：checked文中の式や、checked演算子の後の式の中でオーバーフローが起きた場合、例外をスローする　
                         //checked {ブロック} はchecked文,checked(式) はchecked演算子と呼ぶ
                {
                    sbyte a = 64;           // 2進表現では 0100 0000
                    sbyte b = 65;           // 2進表現では 0100 0001
                    var c = (sbyte)(a + b); // 2進表現では 1000 0001 ←sbyteでは -127 を表す ★64 + 65 = -127になる=オーバーフロー
                }
            }
            catch (OverflowException ex)
            {
                Console.Write(ex.Message);
                Console.ReadKey();
            }
        }

        //あえてオーバーフローを無視したい場合
        //★unchecked：unchecked文中の式や、 unchecked演算子の後の式の中ではオーバーフローは無視され、 例外はスローされない


        //浮動小数点数型のオーバーフロー
        //オーバーフローを起こした場合、値は無限大(infinity)になる
        //絶対値が浮動小数点数で表せる値の範囲を下回った場合(このような状況をアンダーフローと呼ぶ)、 値は0になる
        public void 浮動小数点数型のオーバーフロー()
        {
            var x = 1e30f;
            var y = 1e-30f;
            Console.Write("\r\t★★★浮動小数点数型のオーバーフロー★★★　{0}, {1}", x * x, y * y); // +∞, 0 と表示される
            Console.ReadKey();
            //★浮動小数点数の場合、例えchecked文中であっても、 オーバーフローによる例外は発生しない
        }


    }
}
