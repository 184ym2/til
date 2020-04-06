
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpKeywordSample_1
{
    internal class 構造化_反復処理
    {
        public void while文()
        {
            Console.Write("\r\n★★★反復処理_while文★★★\r\n");

            /*　while の後ろの括弧内の条件式が真の間ずっと文が実行される　
               
              　ループを途中で抜けたい場合には、 break を、 ループの先頭に戻りたい場合は continue を使用する　
              　break・continue よりも後ろの処理は実行されない　*/

            Console.Write("1つ目の整数を入力してください : "); // 1. 初期化式
            var a = int.Parse(Console.ReadLine());
            Console.Write("2つ目の整数を入力してください : ");
            var b = int.Parse(Console.ReadLine());

            Console.Write("{0}と{1}の最大公約数は", a, b);

            //aとbの最大公約数を求める
            while (b != 0) // 2. 条件式
            {
                // b が 0 になるまで繰り返し実行される　→　3. 繰り返される処理
                var r = a%b;
                a = b;
                b = r;
            }

            Console.Write("{0}\r\n", a);
            Console.ReadKey();
        }

        public void do_while文()
        {

            Console.Write("\r\n★★★反復処理_do_while文★★★\r\n");

            /*　do-while 文は while 文と異なり、最低1回は文が実行される
              　つまり、while 文は条件式の評価を行ってから文を実行するのに対し、do-while 文は文を実行してから条件式を評価する　*/

            int n;

            do // 1. 繰り返される処理
            {
                Console.Write("1～5のいずれかの数値を入力してください : ");
                n = int.Parse(Console.ReadLine()); // 2. 初期化式
            } while (n < 1 || n > 5); // 3. 条件式　nの値が1～5の範囲に入るまで繰り返し

            Console.Write("あなたの入力した数値は{0}です\r\n", n);
            Console.ReadKey();
        }

        
        public void for文()
        {
            Console.Write("\r\n★★★反復処理_for文★★★\r\n");

            /*　for 文は 反復処理に入る前に1度だけ(1)初期化式が実行される
              その後、(2)条件式を評価し、条件を満たさなければループを抜ける そして、1回の反復が終わるたびに(3)更新式が実行され、次の反復に移る　*/

            for (var x = 1; x <= 9; ++x) // xを1～9まで、1ずつ増やして繰り返し
            {
                for (var y = 1; y <= 9; ++y) // yを1～9まで、1ずつ増やして繰り返し
                {
                    // xy の値を、幅をそろえて表示
                    Console.Write((x*y).ToString().PadLeft(3, ' '));
                }
                Console.Write("\n");
            }
        }


        public double foreach文(double[] a)
        {
            Console.Write("\r\n★★★反復処理_foraech文★★★\r\n");
            // foreach とは、 "for each element in an array" (配列中のそれぞれの要素に対して処理を行う)という意味
            // foreach(型名 変数 in コレクション)

            //double y = 0;

            //foreach (double x in a)
            //{
                //y += x;
            //}

            //配列に格納された値の平均値を求める場合
            var y = a.Sum(); // LINQで書き直したバージョン
            return y / a.Length;

        }
    }
}
