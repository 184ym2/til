using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpDelegateCastSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var dcex = new DelegateSampleEx();//サンプルコードの実行
            dcex.DelegateSample1();
            dcex.DelegateSample2();
            dcex.DelegateSample3();

            var dc = new DelegateCast();//分解したコードの実行
            dc.resultに値を直接セットする();
            dc.DelegateCast1();
            dc.DelegateCast2();
            dc.DelegateCast3();
            dc.DelegateCast4();

        }
    }
}
