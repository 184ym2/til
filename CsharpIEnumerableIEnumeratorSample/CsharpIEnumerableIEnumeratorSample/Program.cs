using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpIEnumerableIEnumeratorSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var multiple = new MultipleEnumeration();
            multiple.複数列挙の可能性();

            var lazy = new LINQ即時評価();
            lazy.即時評価();
        }
    }
}
