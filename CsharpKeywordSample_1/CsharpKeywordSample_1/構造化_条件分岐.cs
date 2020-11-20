using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpKeywordSample_1
{
     class 構造化_条件分岐
    {
        public void if文()
        {
            Console.Write("\r\n★★★条件分岐_if文★★★\r\n");

            int x;
            Console.Write("整数を入力してください : ");
            x = int.Parse(Console.ReadLine());

            if (x == 0)
            {
                // 0が入力された場合、エラーメッセージだけ表示
                Console.Write("0が入力されました");
            }
            else
            {
                // 0以外が入力された場合、入力された数値の逆数を求めて表示
                var xInv = 1.0/x;
                Console.Write("1/{0} = {1}", x, xInv);
                Console.ReadKey();
            }

            Console.ReadKey();
        }

        public void switch文(int swt)
        {
            Console.Write("\r\n★★★条件分岐_switch文★★★\r\n");

            switch (swt)
            {
                case 1:
                    Console.WriteLine("1です");
                    break;
                case 2:
                    Console.WriteLine("2です");
                    break;
                default:
                    Console.WriteLine("その他の数字です");
                    break;
            }

            Console.ReadKey();

            //C#6.0まで　caseに書ける条件は値のみ

            //C#7以降　　型による分岐ができる　さらに、各caseに対してwhen句で条件を付けることが可能になった　→　型スイッチについて

            //C#8.0以降　複数の値をまとめてswitch文に書くことができる（正確に言うと、「タプルに対する位置パターン」）
            //C#8.0以降　switchの式版が追加
        }

        public void フォールスルーの禁止(int flt)
        {
            Console.Write("\r\n★★★条件分岐_switch文_フォールスルーの禁止★★★\r\n");

            /*　フォールスルーとは　
              　switch 文中の case ラベルを超えてコードが実行されること　C/C++ではこれが許されている */

            //基本はフォールスルーして欲しくない場合がほとんどなので、braek を挿入して、 case ラベルを超えてコードが実行されないようにする

            /*　C/C++では、braek を忘れるミスが頻繁に起こっていたため、⚠C#ではフォールスルーを禁止している⚠
              　case ラベル毎に必ず、break, 「goto」, 「戻り値return」 のいずれかを記述する必要がある　*/


            //ただし以下のように、case ラベルが連続している場合に限りフォールスルー可能で、 break 等が必須ではない
            switch (flt)
            {
                case 1:
                case 2:
                    Console.Write("flt == 1 か flt == 2 のときに実行される\n");
                    break;
                // case ラベルが連続している場合のみ OK
                // case 1: と case 2: の間にコードを書いてはいけない
            }
            Console.ReadKey();
        }



        /*　goto 文とは
              if 文や switch 文と異なり、無条件に処理の流れを変える文　*/

        public void goto文_1(int gt)
        {
            Console.Write("\r\n★★★条件分岐_goto文_1★★★\r\n");

            //　1.　switch 文で、x の値が1のときも2の時も同じ処理を行いたいという場合
            switch (gt)
            {
                case 1:
                    goto case 2; // gotoを使って処理を移す
                case 2:
                    // x の値が1か2だった場合の処理
                    Console.WriteLine("goto文でcase2に処理を移した");
                    Console.ReadKey();               
                    break;
                case 3:
                    // x の値が3だった場合の処理
                    break;
                default:
                    // そのほかの場合の処理
                    break;
            }        
             
        }

        public void goto文_2()
        {
            //　2.　多重ループから抜け出す場合
            Console.Write("\r\n★★★条件分岐_goto文_2★★★\r\n");

            var x = 10;
            var y = 2;

            while (x != 0)
            {
                while (y != 0)
                {
                    // 繰り返し行いたい処理

                    if (x == y)
                        Console.Write("goto文でループを抜けた");
                    Console.ReadKey();
                    goto LOOPEND; // break では while(y != 0) の方のループしか抜けられない
                }
            }
            LOOPEND:
            ;

        }



    }
}
