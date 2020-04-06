using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpKeywordSample_1 /*代入検証*/
{
    class EtcSample
    {
        public int A;

        public void 代入検証サンプル()
        {
            var etcClass = new EtcSample
            {
                A = 6
            };

            int i;　/*代入検証のステップ実行はここから ステップ実行F5→F10→コンソールの表示が終了するとこちらに飛ぶ*/
            etcClass.A = 20;
            i = 10; //i=10

            Console.Write("\r\n★★★代入検証★★★\r\n" + i + "\r\n");
            
        }
    }
}
