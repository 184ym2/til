using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpKeywordSample_1 /*代入検証*/
{
    internal class EtcSample
    {
        public int A;

        public void 代入検証サンプル()
        {
            var etcClass = new EtcSample
                           {
                               A = 6
                           };

            var i = 5; /* 代入検証のステップ実行はここから */
            etcClass.A = 20;
            i = 10; //i=10

            Console.Write("\n★★★代入検証★★★\n" + i + "\n");
            Console.ReadKey();
        }

        public void show()
        {
            代入検証サンプル();
        }
    }
}