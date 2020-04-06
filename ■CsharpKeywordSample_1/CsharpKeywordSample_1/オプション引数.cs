using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpKeywordSample_1
{
    //C#4.0で追加された機能
    public class オプション引数
    {
        //オプション引数は C++にもある機能
        //省略可能なので、オプション引数（optional parameter）
        public int OP引数(int x = 0, int y = 0, int z = 0)
        {
            Console.Write("\r\n★★★オプション引数_必須パラメーターなし★★★\r\n");
            return x + y + z;
        }

        /*呼び出し
         
        op引数.オプション引数();      // オプション引数(0, 0, 0); 
        op引数.オプション引数(1);     // オプション引数(1, 0, 0);
        op引数.オプション引数(1, 2);  // オプション引数(1, 2, 0); 
          
        この方法で省略できるのは、後ろの引数のみ
        x,yを省略して、zをオプションにすることはできない
        op引数.オプション引数(0, 0, 2); → これを省略して書くことはできない
          
         * 
         * 

        定義側でも同じ
        以下のコードはコンパイル エラー 「省略可能なパラメーターはすべての必須パラメーターの後で指定する必要があります」
        
        先に省略可能なパラメーターを書く → NG
        public int オプション引数(int x = 0, int y = 0, int z)
        {
            既定値がある引数(x,y) = 省略可能なパラメーター (呼び出し時、数字を入れなくても良い)
            既定値がない引数(z)   = 必須パラメーター　　　 (呼び出し時、数字が必須)　
         
            return x + y + z;
        }　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　*/

        //先に必須パラメーターを書く → OK
        public int OP引数2(int x, int y, int z = 0)
        {
            Console.Write("\r\n★★★オプション引数_必須パラメーターあり★★★\r\n");
            return x + y + z;
        }

        //ただし、オプション引数の後ろに params（可変長引数）を続けることは可能
        public int OP引数3(int x , int y , int z = 0, params int[] rest)
        {
            Console.Write("\r\n★★★オプション引数_可変長引数あり★★★\r\n");
            return x + y + z + rest.Sum();
        }

        //関数の名前が同じで、引数リストだけが異なる関数を作ることを関数のオーバーロード(overload : 過負荷、上積み)という
        //オプションなし > オプションあり > 可変長引数　の順で優先される
        public void オーバーロードの優先順位()
        {
            Console.Write("\r\n★★★オプション引数_オーバーロードの優先順位★★★\r\n");
            Sum(1);
            Sum(1, 2);
            Sum(1, 2, 3);
            Sum(1, 2, 3, 4);
        }

        public int Sum(int x)//このSumメソッドは引数(必須)が1つで呼び出し可能
        {
            Console.WriteLine("Sum(x)");
            return x;
        }

        public int Sum(int x, int y = 0, int z = 0) //上のSumメソッドが優先されるため、識別として引数(必須)が2つ以上でこのSumメソッドが呼び出し可能　※通常は1つ以上でOK
        {
            Console.WriteLine("Sum(x, y, z)");
            return x + y + z;
        }

        public int Sum(params int[] rest) // 上の引数が3つあるSumメソッドが優先されるため、引数が4つ以上でないと呼び出しができない
        {
            Console.WriteLine("Sum(可変長引数)");
            return rest.Sum();
        }
        
    }
}
