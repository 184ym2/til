using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpConstructorSample
{
    internal class ConstructorSampleClass
    {
        //コンストラクタ初期化子　:this() ← 初期化子に当てはまるコンストラクタが先に実行される

        /// <summary>
        /// ☆：this(string x) → ☆(呼び出された本体)
        /// </summary>
        public ConstructorSampleClass()
            : this("★")
        {
            Console.WriteLine("SampleClass()：");
            Console.ReadKey();
        }

        /// <summary>
        /// ★：★のみ(呼び出された本体)
        /// </summary>
        public ConstructorSampleClass(string x)
        {
            this.X = x;
            Console.WriteLine("SampleClass(string x)：" + x);
            Console.ReadKey();
        }

        /// <summary>
        /// ★★：this() → ★★(呼び出された本体)
        /// </summary>
        public ConstructorSampleClass(string x, string y) : this()
        {
            this.X = x;
            this.Y = y;
            Console.WriteLine("SampleClass(string x, string y)：" + x + y);
            Console.ReadKey();
        }

        /// <summary>
        /// ★★★：this(string x) → this() → this(string x, string y) → ★★★(呼び出された本体)
        /// </summary>
        public ConstructorSampleClass(string x, string y, string z)
            : this("★", "★")
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            Console.WriteLine("SampleClass(string x, string y, string z)：" + x + y + z);
            Console.ReadKey();
        }

        public string X { get; set; }

        public string Y { get; set; }

        public string Z { get; set; }
    }
}