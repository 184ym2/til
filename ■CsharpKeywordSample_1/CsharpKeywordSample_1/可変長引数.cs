using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpKeywordSample_1
{
    //C# params キーワードを用いることでメソッドの引数の数を可変にすることができる

    public class 可変長引数
    {
        public void 可変長引数を使用する()
        {

            /* 
            以下の方法では、1度値を配列に格納してからメソッドを呼び出すという操作が必要になる
            このメソッドを呼び出すたびに一時的に配列を作成して、 値を格納してという作業を行うのは大変
             
            そこで、この作業を自動化しようというのが C# の可変長引数の考え方
             * 
             * 
            ※可変長引数を使用しない場合※
            
            int a = 314, b = 159, c = 265, d = 358, e  = 979;　これらの最大値を探したいときは、一度配列に格納し最大値メソッドを呼び出す必要がある
            int[] tmp = new int[]{a, b, c, d, e};　　　　　　　          
            int max = 最大値(tmp);　　　　　　　　　　　　       
            
            Console.Write("{0}\n", max); 
            
            */

            //※可変長引数を使用する場合※
            Console.Write("\r\n★★★可変長引数★★★\r\n");
            int a = 314, b = 159, c = 265, d = 358, e = 979;// これらの最大値を探したいとき
            var max = 最大値(a, b, c, d, e);　// 自動的に配列を作成し、値を格納してくれる　※呼び出すときに、任意の引数をセットできる！！！    
            Console.Write("{0}\n", max);


            Console.Write("\r\n★★★可変長引数_引数なし★★★\r\n");
            var noth = 引数なしで呼ぶ();　//引数なしで呼ぶと、空配列(長さ0の配列)が渡る
            //.NET Framework 4.5 以前は　var noth = Sum(new int[0]);
            //.NET Framework 4.6 以降は　var x = Sum(Array.Empty<int>());　Array.Emptyという空配列を作るためのメソッドが用意されている　パフォーマンス◎
            Console.WriteLine(noth);


            Console.Write("\r\n★★★可変長引数_引数null★★★\r\n");
            var nl = 引数なしで呼ぶ(null);　//null だけを引数に渡すと 配列であるはずの引数自体が null として渡る
            Console.WriteLine(nl);

            引数なしで呼ぶ2(1, 2, 3);
            引数なしで呼ぶ2(DateTime.Now);
            引数なしで呼ぶ2(1, "b", null);
            引数なしで呼ぶ2(null);
            引数なしで呼ぶ2((object)null);
            Console.ReadKey();

            //現状のC#では、params をつけられるのは配列のみ → 配列は具象的(わかりやすい)なため　
            //IEnuemrable<T>などは不可 → どういう型が良いかでもめる

        }

        //メソッド定義側の変更点　　・・・配列型引数をparamsで修飾した
        //メソッド呼び出し側の変更点・・・手動で配列を用意して値を格納しなくても、可変個の引数を与えてメソッドを呼び出すことができる
        
        public int 最大値(params int[] a)
        {
            var max = a[0];
            for (var i = 1; i < a.Length; ++i)
            {
                if (max < a[i])
                    max = a[i];
            }
            return max;
        }

        public int 引数なしで呼ぶ(params int[] b)　//引数無しで呼ばれた場合、bには空配列が入る = nullにならない
        {
            try
            {
                return b.Sum();
            }
            catch (Exception)
            {
                Console.WriteLine("引数にnullが渡りました");
                Console.ReadKey();
            }

            return 1; //エラー回避
        }


        static void 引数なしで呼ぶ2(params object[] c)　
        {          
            try
            {
                Console.WriteLine(c);
            }
            catch (Exception)
            {
                Console.WriteLine("引数にnullが渡りました");
                Console.ReadKey();
            }
        }

        
    }

}
