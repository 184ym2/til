using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpKeywordSample_1
{
    class 組込み型演算子Sample
    {
        //組込み演算子
        //1. 算術演算子
        int a = 9 + 4;
        int a2 = 9 / 2; // 整数の場合あまり切り捨て　A. a=4

        //符号反転
        static int a3 = 1;
        int b = -a3; //A. b=-1

        //2. インクリメント・デクリメント
        //前置きインクリメント
        static int inc = 5;   //←ｺﾚ　結果はインクリメントが行われた後の値(オペランド)になる
        int finc = ++inc;     //A. inc=6, finc=6

        //後置きインクリメント
        static int inc2 = 5;  //←ｺﾚ　結果はインクリメントが行われる前の値(オペランド)になる
        int binc = ++inc2;    //A. inc2=6, binc=5

        //前置きデクリメント
        static int dc = 5;    //←ｺﾚ　結果はデクリメントが行われた後の値(オペランド)になる
        int fdc = --dc;       //A. dc=4, fdc=4

        //後置きデクリメント
        static int dc2 = 5;   //←ｺﾚ　結果はデクリメントが行われる前の値(オペランド)になる
        int bdc = --dc2;      //A. dc2=4, bdc=5

        //3. シフト：左側のオペランドを右側のオペランド分だけ左または右にシフトします
        //シフト演算とは、2進数のビットパターンを右または左にずらす演算である
      
        //左シフト
        int Lshi = 51 << 2;   // a は 204 (0011 0011 << 2 = 1100 1100)　左に2つずらす

        //右シフト
        //※左オペランドが符号付き整数の場合：右シフトは算術シフト演算　※左オペランドが符号無し整数の場合：右シフトは論理シフト演算
        int Rshi = 51 >> 1;   // a は 25  (0011 0011 >> 1 = 0001 1001)  右にひとつずらす


        //4. 文字列連結
        string s = "abc" + "def";

        //5. 論理演算子

        //x&y ：xとyの論理積を計算
        private const bool Rs = true & false; // Rs は false 

        private const byte Rs2 = 201 & 92; // Rs2 は 72      (1100 1001 AND 0101 1100 = 0100 1000) 

        //x|y ：xとyの論理和を計算
        private const bool Rw = true | false; // a は true

        private const byte Rw2 = 201 | 92; // a は 221      (1100 1001 OR 0101 1100 = 1101 1101)

        //x~y ：xとyの排他的論理和を計算
        private const bool Hrw = true ^ true; // a は false 

        private const byte Hrw2 = 201 ^ 92; // a は 149     (1100 1001 XOR 0101 1100 = 1001 0101)

        //!x  ：x の論理否定を計算
        private const bool Rh = !true; // a は false

        //~x  ：x の補数を計算
        private const int Ho = ~201; // a は -202 ~(0000 0000 1100 1001) = 1111 1111 0011 0110

        public void 論理演算子()
        {
            Console.Write("\r\n★★★論理演算子★★★\r\n");
            Console.Write("\r\n【論理積：AND】　" + Rs + "　" + Rs2);
            Console.Write("\r\n【論理和：OR】　" + Rw + "　" + Rw2);
            Console.Write("\r\n【排他的論理和】　" + Hrw + "　" + Hrw2);
            Console.Write("\r\n【論理否定】　" + Rh);
            Console.Write("\r\n【補数】　" + Ho);
            Console.ReadKey();
        }

        //6. 関係演算
        //x==y：xがyと等しいかどうか
        private const bool Bl = "abc" == "abc"; // a は true 
        private const bool Bl2 = 1 == 0; // a は false

        //x!=y：xがyと異なるかどうか
        private const bool Bl3 = "abc" != "abc"; // a は false
        private const bool _bl4 = 1 != 0; // a は true

        //x<y：xがyより小さいかどうか
        //x>y：xがyより大さいかどうか

        //x<=y：xがy以下かどうか
        //x>=y：xがy以上かどうか

        public void 関係演算()
        {
            Console.Write("\r\n\r\n★★★関係演算★★★\r\n");
            Console.Write("\r\n【x==y：xがyと等しいかどうか】　" + Bl + "　" + Bl2);
            Console.Write("\r\n【x!=y：xがyと異なるかどうか】　" + Bl3 + "　" + _bl4);
            Console.ReadKey();
        }

        //7. sizeof 演算子
        //sizeof 演算子は、その型が何バイトのメモリを占めるかを返す 通常引数として与えられる型はサイズが決まっている数値型のみ
        //int（32ビット整数）なら4バイト、 byte（8ビット符号なし整数）なら1バイトなので、 sizeof(int), sizeof(byte) はそれぞれ 4, 1 を返す
        public void sizeof演算子()
        {
            Console.Write("\r\n\r\n★★★sizeof演算子★★★\r\n");
            Console.Write("\r\n{0}, {1}, {2}\n", sizeof (int), sizeof (byte), sizeof (long));
        }

        //8. 短絡評価
        //条件 AND &&、 条件 OR ||、 条件演算子 ?:、および、null 合体演算子 ?? は 短絡評価（short circuit evaluation）と呼ばれる挙動をする
        //短絡評価は、左辺の結果によっては右辺が評価されない（関数などを呼ぼうとしても呼ばれない）というもの

        static string Echo(string message)
        {
            Console.WriteLine(message);
            return message;
        }

        public void 短絡評価()
        {
            Console.Write("\r\n\r\n★★★短絡評価★★★\r\n");
            Console.Write("\r\n短絡評価なし\r\n");
            var x = Echo("a") == "a" | Echo("b") == "b"; // a、b 両方出力。

            Console.Write("\r\n短絡評価あり\r\n");
            var y = Echo("a") == "a" || Echo("b") == "b"; // a のみ出力

            var x2 = true ? Echo("\r\n第2項") : Echo("第3項"); // 第2項だけ表示される
            var y2 = false ? Echo("\r\n第2項") : Echo("第3項"); // 第3項だけ表示される


        }


    }
}
