using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;

namespace CsharpKeywordSample_1 /* 対象キーワード[Attribute] */
{
    internal class AttributeSample // Attribute=属性 アトリビュート
    {
        public void show()
        {
            Console.Write("\n★★★AttributeSample★★★\n");
            var doubles = new double[]
                          {
                              9,
                              4,
                              5,
                              2,
                              7,
                              1,
                              6,
                              3,
                              8
                          };
            BubbleSort(doubles);
            Output(doubles);
            Console.ReadKey();
        }

        private static void Swap(ref double x, ref double y)
        {
            var tmp = x;
            x = y;
            y = tmp;
        }

        /// <summary>
        /// バブルソートを行う
        /// </summary>
        private static void BubbleSort(double[] array)
        {
            var n = array.Length - 1;

            for (var i = 0; i < n; ++i)
            {
                for (var j = n; j > i; --j)
                    if (array[j - 1] > array[j])
                        Swap(ref array[j - 1], ref array[j]);

                IntermediateOutput(array); // ソートの途中段階のデータを表示
            }
        }

        /// <summary>
        /// 配列の内容をコンソールに表示する
        /// </summary>
        private static void Output(IEnumerable<double> enumerable)
        {
            foreach (var x in enumerable)
            {
                Console.Write("{0} ", x);
            }

            Console.Write("\n");
        }

        /// <summary>
        /// Conditional属性：特定の条件下でのみ実行されるメソッドを定義するために使用　Conditional属性を適用するメソッドは値を返さないメソッドのみ(void型/Subプロシージャ)
        /// ビルド：条件付きコンパイル シンボル(Y) に "SHOW_INTERMEDIATE" というシンボルが定義されているときのみ、以下のメソッドを実行する
        /// 配列の内容をコンソールに表示する
        /// </summary>
        [Conditional("SHOW_INTERMEDIATE")]
        private static void IntermediateOutput(IEnumerable<double> enumerable)
        {
            Output(enumerable);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    internal class TargetAttribute : Attribute
    {
        private readonly string author; // 名前付きパラメータ 

        public TargetAttribute(string author)
        {
            // コンストラクタにauthorがあるため、[]内でフィールド名を指定する必要はない
            this.author = author;
        }

        public string Author { get { return this.author; } }
    }

    /// <summary>
    /// プロパティ・イベントと属性の対象：プロパティやイベントは、内部的にはフィールドやメソッドも作成されるため、属性の指定先も増加する
    /// </summary>
    internal class AttributeSample2
    {
        private int _property;

        /// <summary>
        /// [属性の対象 : 属性名(属性のオプション)]
        /// </summary>
        [Target("P")] // プロパティ自体の属性
        public int Property
        {
            [method: Target("gat")] // getに対応するメソッドに対する属性                       
            get { return _property; }

            [method: Target("set")] // setに対応するメソッドに対する属性 
            [param: Target("value")] // setが受け取っているvalue引数に対する属性          
            set { _property = value; }
        }

        /* 
           上記のget/setは以下の書き方と全く同じである
           public int GetP()
           {
               return this._property;
           }
         * 
           public void SetP(int value)
           {
               this._property = value;
           } 
         */

        //[field:X] ★(C# 7.3 から使用可能) 自動で生成されるフィールドに属性付与
        //public int AutoProperty { get; }

        /// <summary>
        /// 定義済みデリゲートを使用したEvent
        /// </summary>
        [Target("E")] // イベント自体の属性
        public event Action Event
        {
            [method: Target("add")] // addに対応するメソッドに対する属性
            [param: Target("value")] // addが受け取っているvalue引数に対する属性
            add
            {
                /*_X += value;*/
            }

            [method: Target("remove")] // removeに対応するメソッドに対する属性
            [param: Target("value")] // removeが受け取っているvalue引数に対する属性
            remove
            {
                /*_X -= value;*/
            }
        }

        //[field: X] ★(C# 7.3 から使用可能) 自動で生成されるフィールドに属性付与
        //public event Action AutoEvent;
    }

    /// <summary>
    /// 属性の自作:Attribute.csを継承
    /// </summary>
    // 属性の用途を指定
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
    public class AuthorAttribute : Attribute
    {
        private readonly string author; // 位置指定パラメーター Positional Parameter
        public string Member; // 名前付きパラメータ Named Parameter

        public AuthorAttribute(string author)
        {
            // コンストラクタにauthorがあるため、[]内でフィールド名を指定する必要はない
            this.author = author;
        }

        public string Author { get { return this.author; } }
    }

    /// <summary>
    /// 属性を付与するクラス
    /// </summary>
    // 属性パラメータで指定した引数は属性クラスのコンストラクタに渡される
    [Author("作者1", Member = "Microsoft")]
    [Author("作者2")]
    internal class Author属性付与
    {
        [Author("Aの作者")]
        public static void Method_A()
        {
        }

        [Author("Bの作者")]
        public static void Method_B()
        {
        }

        [Author("Cの作者")]
        public static void Method_C()
        {
        }

        [Author("Dの作者")]
        public static void Method_D()
        {
        }

        //Equals(),GetHashCode(),GetType(),Tostring()
    }

    /// <summary>
    /// 属性情報の取得
    /// </summary>
    internal class AttributeSample3
    {
        public void show()
        {
            Console.Write("\n★★★AttributeSample3★★★");
            GetAllAuthors(typeof (Author属性付与));
            Console.ReadKey();
        }

        /// <summary>
        /// クラス名とクラス中のメソッド名を取得
        /// </summary>
        /// <param name="T">クラスの Type</param>
        private static void GetAllAuthors(Type T)
        {
            // リフレクション：取得したTypeオブジェクト名を取得する
            Console.Write("\nTypeName: {0}\n", T.Name);
            GetAttribute(T); //TのAttributeを取得

            foreach (var methodInfo in T.GetMethods())
            {
                // リフレクション：取得したTypeオブジェクトのメソッド名を取得する
                Console.Write("　MethodName: {0}\n", methodInfo.Name);
                GetAttribute(methodInfo); //Tに属するメソッドのAttributeを取得
            }
        }

        /// <summary>
        /// クラスやメソッドの属性情報を取得
        /// </summary>
        /// <param name="info">MemberInfo：メンバーの属性に関する情報を取得し、メンバーのメタデータにアクセスできるようにする</param>
        private static void GetAttribute(MemberInfo info)
        {
            // ★typeof(xxx)：クラス名から型宣言（Typeクラス）を取得
            var type = typeof (AuthorAttribute);

            // GetCustomAttributesメソッドの戻り値：typeに適用された element型のカスタム属性を格納する Attribute[]
            var authors = Attribute.GetCustomAttributes(info, type);

            // OfTypeはLINQの一種：Attribute[] の中で AuthorAttribute.cs に変換できる要素を取得する
            foreach (var author in authors.OfType<AuthorAttribute>())
            {
                Console.Write("    ・AttributeName: {0} {1}\n", author.Author, author.Member);
            }
        }
    }
}