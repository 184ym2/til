using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpObjectの複製Sample
{
    internal class Program
    {
        private static void Main(string[] args)
        {



          

            var shallowSimple = new ShallowCopy_Simple();
            shallowSimple.simpleCopy();

            var shallowCopy = new ShallowCopy();
            shallowCopy.stractCopy();
            shallowCopy.classCopy();
            shallowCopy.stractCopy2();
            shallowCopy.classCopy2();
            shallowCopy.stractCopy3();
            shallowCopy.classCopy3();

            var deepcopy = new DeepCopy();
            deepcopy.stractCopy();
            deepcopy.classCopy();

            var 値渡しと参照渡し = new 値渡しと参照渡し();
            値渡しと参照渡し.値型();

            

        }
    }
}