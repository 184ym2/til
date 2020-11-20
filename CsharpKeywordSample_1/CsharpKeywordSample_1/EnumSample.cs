using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpKeywordSample_1
{
    internal enum 年号
    {
        明治,
        大正,
        昭和,
        平成
    }

    internal enum Month : byte
    {
        January = 1,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December
    }

    /// <summary>
    /// 属性あり 
    /// </summary>
    [Flags]
    internal enum Xyz
    {
        X = 1, // 001
        Y = 2, // 010
        Z = 4 // 100
    }

    /// <summary>
    /// 属性なし
    /// </summary>
    internal enum Xyz2
    {
        X = 1, // 001
        Y = 2, // 010
        Z = 4 // 100
    }

    internal class EnumSample
    {
        /// <summary>
        /// 和暦を西暦に変換する
        /// </summary>
        public void Enumサンプル()
        {
            var era = new[]
                      {
                          年号.昭和,
                          年号.大正,
                          年号.明治,
                          年号.平成,
                          年号.昭和
                      };
            var jYear = new[]
                        {
                            33,
                            12,
                            20,
                            10,
                            54
                        };
            var year = new int[5];

            Console.Write("★★★EnumSample　和暦を西暦に変換する★★★\r\n");
            Console.Write("和暦      西暦\n");
            for (var i = 0; i < 5; ++i)
            {
                switch (era[i])
                {
                    case 年号.明治:
                        year[i] = jYear[i] + 1863;
                        break;
                    case 年号.大正:
                        year[i] = jYear[i] + 1911;
                        break;
                    case 年号.昭和:
                        year[i] = jYear[i] + 1925;
                        break;
                    case 年号.平成:
                        year[i] = jYear[i] + 1988;
                        break;
                }

                Console.Write("{0}{1:d2}年  {2:d4}年\n", era[i], jYear[i], year[i]);
            }
        }

        /// <summary>
        /// 列挙型はプログラムの内部では整数として扱われている
        /// 整数型に変換するとその値を取り出せる
        /// 特に指定がない場合はint型
        /// 明示的に指定することもできる
        /// 1つ目のメンバーだけに値をセットすると、1つめの値から1ずつ増加していく
        /// </summary>
        public void Enumサンプル2()
        {
            Console.Write("\r\n★★★EnumSample2　列挙型を文字列化★★★\r\n");
            for (var i = 1; i < 12; ++i)
                Console.Write("{0}月  {1}\n", i, (Month) i);
            Console.ReadKey();
            // 列挙型を文字列化（ToString）すると、列挙型のメンバー名が表示される
        }

        /// <summary>
        /// フラグとしての列挙型活用
        /// 条件が n 個ある（例えば X, Y, Z の3つ）
        /// 「X かつ Y」とか「Y かつ Z」というような条件もありうる
        /// </summary>
        public void Enumサンプル3() // x=001 y=010 z=100 2進数
        {
            Console.Write("\r\n★★★Enumサンプル3　Flags属性あり★★★\r\n");
            var xy = Xyz.X | Xyz.Y;
            Console.Write("{0}\n", xy);

            var yz = Xyz.Y | Xyz.Z;
            Console.Write("{0}\n", yz);

            var zx = Xyz.Z | Xyz.X;
            Console.Write("{0}\n", zx);

            var xyz = Xyz.X | Xyz.Y | Xyz.Z;
            Console.Write("{0}\n", xyz);
            Console.ReadKey();
        }

        public void Enumサンプル4()
        {
            Console.Write("\r\n★★★Enumサンプル4　Flags属性なし★★★\r\n");

            Console.Write("{0}\n", Xyz2.X); //1 001
            Console.Write("{0}\n", Xyz2.Y); //2 010
            Console.Write("{0}\n", Xyz2.Z); //4 100

            var xy = Xyz2.X | Xyz2.Y; // xかつy 3=011 論理和で計算される
            var xz = Xyz2.X | Xyz2.Z; // xかつz 5=101 
            Console.Write("{0}\n", xy);
            Console.Write("{0}\n", xz);
            Console.ReadKey();
        }
    }
}