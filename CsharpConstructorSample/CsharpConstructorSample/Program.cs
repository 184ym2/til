using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpConstructorSample
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Action 改行 = () =>
                            {
                                Console.WriteLine("\r\n");
                            };

            var sm = new ConstructorSampleClass();
            改行();

            var sm2 = new ConstructorSampleClass("★");
            改行();

            var sm3 = new ConstructorSampleClass("★", "★");
            改行();

            var sm4 = new ConstructorSampleClass("★", "★", "★");


            var sc = new StructConstructor();
        }
    }
}