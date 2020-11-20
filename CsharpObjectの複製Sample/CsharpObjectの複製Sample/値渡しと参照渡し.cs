using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpObjectの複製Sample
{
    internal class 値渡しと参照渡し
    {
        public void 値型()
        {
            var x = 10;

            var y1 = 値型の値渡し(x);

            //Console.WriteLine(x); //=> 10

            var y2 = 値型の参照渡し(ref x);

            //Console.WriteLine(x); //=> 20
        }

        //値型の値渡し
        public int 値型の値渡し(int y)
        {
            y = 20;
            var g = Guid.NewGuid();
            return y;
        }

        //値型の参照渡し
        public int 値型の参照渡し(ref int y)
        {
            y = 20;
            return y;
        }
    }
}