using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpObjectの複製Sample
{
    /// <summary>
    /// 参照渡しを使うと、メソッド内からメソッド外にある変数を書き換えることができます
    /// </summary>
    internal class 値渡しと参照渡し
    {
        public void 値型()
        {
            #region

            Action 参照型Simple = () =>
                                   {
                                       Console.WriteLine("--値型--\r\n");
                                       var x = 10; // x=0x0730edf0(値：0x0000000a)
                                       var z = 10;

                                       var y1 = 値型の値渡し(x, z);
                                       Console.WriteLine("値型の値渡し：{0} {1}", x, z);

                                       var y2 = 値型の参照渡し(ref x, ref z);
                                       Console.WriteLine("値型の参照渡し [ref]：{0} {1}", x, z);

                                       var y3 = 値型の参照渡し2(out x, out z);
                                       Console.WriteLine("値型の参照渡し2 [out]：{0} {1}", x, z);
                                   };

            #endregion

            参照型Simple();
        }

        public int 値型の値渡し(int y, int z)
        {
            // 引数は値型の★値　y(参照：&500　値：10) z(参照：&510　値：10)       

            // 新しいインスタンスの★値を(y 参照：&520　値：20 z 参照：&530　値：30)を 引数の★値 y(値：10),z(値：10) に代入
            // 渡された引数は変更されない

            y = 20;
            z = 30;

            // y = (参照：&520　値：30)
            // z = (参照：&530　値：40)

            return y;
        }

        public int 値型の参照渡し(ref int y, ref int z)
        {
            // 引数は値型の☆参照　y(参照：&500　値：10) z(参照：&510　値：10)       

            // 新しいインスタンスの★値を(y 参照：&540　値：30 z 参照：&550　値：40)を 引数の☆参照 y(参照：&500),z(参照&510) に代入
            // 渡された引数は変更される

            y = 40;
            z = 50;

            // 値の代入は必須ではない
            // y = (参照：&500　値：30)
            // z = (参照：&510　値：40)

            return y;
        }

        public int 値型の参照渡し2(out int y, out int z)
        {
            // 引数は値型の☆参照　y(参照：&500　値：10) z(参照：&510　値：10)       

            // 新しいインスタンスの★値を(y 参照：&560　値：50 z 参照：&570　値：60)を 引数の☆参照 y(参照：&500),z(参照&510) に代入
            // 渡された引数は変更される

            y = 60;
            z = 70;

            // ここで必ず値を代入する必要があるため、出力引数と呼ばれている
            // y = (参照：&500　値：50)
            // z = (参照：&510　値：60)

            return y;
        }

        public void 参照型()
        {
            #region

            Action 参照型Simple = () =>
                                   {
                                       Console.WriteLine("\r\n---参照型---\r\n");
                                       var x = "X";

                                       var y1 = 参照型の値渡し(x);
                                       Console.WriteLine("参照型の値渡し：{0}", x);

                                       var y2 = 参照型の参照渡し(ref x);
                                       Console.WriteLine("参照型の参照渡し [ref]：{0}", x);

                                       var x2 = new[]
                                                {
                                                    "X",
                                                    "X",
                                                    "X"
                                                };

                                       var y3 = 参照型の値渡し2(x2);
                                       //引数に影響はない
                                       Console.WriteLine("参照型の値渡し2：{0}", string.Join(", ", x2));

                                       var y4 = 参照型の参照渡し2(ref x2);
                                       //引数に影響がある
                                       Console.WriteLine("参照型の参照渡し2 [ref]：{0}", string.Join(", ", x2));

                                       参照型の参照渡し3(out x2);
                                       Console.WriteLine("参照型の参照渡し3 [out]：{0}", string.Join(", ", x2));

                                       Console.ReadKey();
                                   };

            Action 参照型Swapメソッド = () =>
                                     {
                                         Console.WriteLine("\r\n---参照型：Swapメソッド [ref]---\r\n");
                                         var x3 = "Hello"; //s1=&500(値：0x02db8e3c) Hello=0x02db8e3c(値：0x02db8f10)
                                         var x4 = "World!"; //s2=&600(値：0x02db8e54) World=0x02db8e54(値：0x02db8f28)
                                         Console.WriteLine("メソッド呼び出し前： {0} {1}", x3, x4);
                                         SwapStrings(ref x3, ref x4);
                                         Console.WriteLine("メソッド呼び出し後： {0} {1}", x3, x4);
                                         //s1=&600 s2=&500
                                         Console.ReadKey();
                                     };

            #endregion

            参照型Simple();
            参照型Swapメソッド();
        }

        public string 参照型の値渡し(string y)
        {
            // 引数は参照型の★値　y(参照：&500　値：$1000 "X")       

            // 新しいインスタンスの★値を(参照：&550　値：$1500 "Y")を 引数の★値 y(値：$1000 "X")に代入
            // 渡された引数は変更されない

            y = "Y";

            // y = (参照：&550　値：$1500 "Y")

            return y;
        }

        public string 参照型の参照渡し(ref string y)
        {
            // 引数は参照型の☆参照　y(参照：&500　値：$1000 "X")       

            // 新しいインスタンスの★値を(参照：&550　値：$1500 "Y")を 引数の☆参照 y(値：$500)に代入
            // 渡された引数は変更される

            y = "Y";

            // 値の代入は必須ではない
            // y = (参照：&500　値：$1500 "Y")

            return y;
        }

        public string[] 参照型の値渡し2(string[] y)
        {
            // 引数は参照型の★値　y(参照：&500　値：$1000 "X","X","X")  

            // ※ここで新しいインスタンスを生成せずに、渡された引数(参照：&500　値：&1000 "X","X","X")のメンバーを変更すると、その変更は引数に反映される
            // 例） y[0] = "Y";

            // 新しいインスタンスの★値(参照：&510　値：$1100 "Y","Y","Y")を 引数の★値 y(値：&1000)に代入
            // 渡された引数は変更されない

            y = new[]
                {
                    "Y",
                    "Y",
                    "Y"
                };

            // y = (参照：&510　値：$1100 "Y","Y","Y")

            return y;
        }

        public string[] 参照型の参照渡し2(ref string[] y)
        {
            // 引数は参照型の☆参照　y(参照：&500　値：$1000 "X","X","X")

            // 新しいインスタンスの★値(参照：&510　値：$1100 "Y","Y","Y")を 引数の☆参照 y(参照：&500)に代入
            // 渡された引数は変更される
            y = new[]
                {
                    "Y",
                    "Y",
                    "Y"
                };

            // 値の代入は必須ではない
            // y = (参照：&500　値：$1100 "Y","Y","Y")
            return y;
        }

        public string[] 参照型の参照渡し3(out string[] y)
        {
            // 引数は参照型の☆参照　y(参照：&500　値：$1000 "X","X","X")

            // 新しいインスタンスの★値(参照：&510　値：$1100 "Y","Y","Y")を 引数の☆参照 y(参照：&500)に代入
            // 渡された引数は変更される
            y = new[]
                {
                    "Z",
                    "Z",
                    "Z"
                };

            // ここで必ず値を代入する必要があるため、出力引数と呼ばれている
            // y = (参照：&500　値：$1100 "Y","Y","Y")
            return y;
        }

        /// <summary>
        /// 文字列パラメータは参照で渡されます
        /// パラメータの変更は元の変数に影響を与えます
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        public void SwapStrings(ref string s1, ref string s2)
        {
            // 引数は参照型の☆参照　s1(参照：&500) s2(参照：&600)

            var temp = s1; // temp = &500
            s1 = s2; // s1 = &600
            s2 = temp; // s2 = &500

            Console.WriteLine("メソッド内部： {0} {1}", s1, s2);

            // s1 = &600 s2 = &500
        }
    }
}