using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ConsoleApplication1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            MethodA();
            Debug.Print("piyopiyo3"); /*呼ばれない*/
        }

        public static void MethodA()
        {
            Console.WriteLine("メソッドAです");
            Console.ReadKey();
            Debug.Print("piyopiyo");

            MethodA();
            /*ReadKey();のあとに"piyopiyo"が走り、再度AAAメソッドを呼び出すループ構造になる*/

            Debug.Print("piyopiyo2"); /*呼ばれない*/
        }
    }
}