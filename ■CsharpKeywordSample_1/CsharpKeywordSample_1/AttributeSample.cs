using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;

namespace CsharpKeywordSample_1
{

    internal class AttributeSample //Attribute=属性 アトリビュート
    {
        public void Attributeメソッド()
        {
            Console.Write("\r\n★★★AttributeSample★★★\r\n");
            var array = new double[]
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
            BubbleSort(array);
            Output(array);
        }

        /// <summary>
        /// バブルソートを行う。
        /// </summary>
        private static void BubbleSort(double[] array)
        {
            var n = array.Length - 1;

            for (var i = 0; i < n; ++i)
            {
                for (var j = n; j > i; --j)
                    if (array[j - 1] > array[j])
                        Swap(ref array[j - 1], ref array[j]);

                IntermediateOutput(array); // ソートの途中段階のデータを表示。
            }
        }

        private static void Swap(ref double x, ref double y)
        {
            var tmp = x;
            x = y;
            y = tmp;
        }

        /// <summary>
        /// 配列の内容をコンソールに表示する。
        /// </summary>
        private static void Output(IEnumerable<double> array)
        {
            foreach (var x in array)
            {
                Console.Write("{0} ", x);
            }

            Console.Write("\r\n");
        }

        /// <summary>
        /// Conditional属性…特定の条件下でのみ実行されるメソッドを定義するために使用
        /// SHOW_INTERMEDIATE というシンボルが定義されているときのみ
        /// 配列の内容をコンソールに表示する。
        /// </summary>
        [Conditional("SHOW_INTERMEDIATE")]
        private static void IntermediateOutput(IEnumerable<double> array)
        {
            Output(array);
        }

    }

    internal class XAttribute : Attribute
    {

    }

    /// <summary>
    /// プロパティ、イベントと属性の対象について
    /// </summary>
    internal class AttributeSample2
    {
        private int _property; //手動のプロパティ実装

        [X] // プロパティ自体
        public int Property
        {
            [method: X] // get に対応するメソッド                       
            get { return _property; }
            /*public int GetP()
               {
                   return this._property;
               } 
             と同じ=メソッドと同じように扱える*/

            [method: X]  // set に対応するメソッド
            [param: X]    // set が受け取っている value 引数          
            set { _property = value; }

            /*public void SetP(int value)
               {
                   this._property = value;
               } 
             と同じ=メソッドと同じように扱える*/
        }

        //[field:X] //★(C# 7.3 から使用可能) 自動で生成されるフィールドに属性付与
        //public int AutoProperty { get; }　

        [X] // イベント自体
        public event Action Event
        {
            [method: X] // add に対応するメソッド
            [param: X]   // add が受け取っている value 引数

            add { }

            [method: X] // remove に対応するメソッド
            [param: X]   // remove が受け取っている value 引数
            remove { }
        }

        //[field: X] //★(C# 7.3 から使用可能) 自動で生成されるフィールドに属性付与
        //public event Action AutoEvent;
    }


    /// <summary>
    /// 属性Authorを作成する AttributeClassを継承している
    /// </summary>
    /// 
    //AttributeUsage：カスタム属性クラスの使用方法を決定する 
    //AttributeTargets：属性を適用できるアプリケーション要素を指定する
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Method,
        AllowMultiple = true, Inherited = false)] //AttributeUsageのプロパティ

    public class AuthorAttribute : Attribute
    {
        private string name;
        public AuthorAttribute(string name) { this.name = name; }
        public string Name { get { return name; } }
    }

    /// <summary>
    /// テスト用のクラス。
    /// メソッドごとに違う人が開発するなんてほとんどありえないけど、
    /// その辺は目をつぶってください。
    /// </summary>
    [Author("Author属性付与の作者")] //コンストラクタに"AuthorTestの作者"が渡される
    [Author("Author属性付与の作者2")] //コンストラクタに"AuthorTestの作者2"が渡される
    internal class Author属性付与
    {
        [Author("Aの作者")]
        public static void A()
        {
        }

        [Author("Bの作者")]
        public static void B()
        {
        }

        [Author("Cの作者")]
        public static void C()
        {
        }

        [Author("Dの作者")]
        public static void D()
        {
        }
    }

    /// <summary>
    /// テストプログラム。
    /// </summary>
    class AttributeSample3
    {
        public void Attributeメソッド3()
        {
            Console.Write("\r\n★★★AttributeSample2★★★\r\n");
            GetAllAuthors(typeof(Author属性付与));//この場合typeofの検索対象はAuthor属性付与
            //GetAuthors < GetAllAuthors < Attributeメソッド3
        }

        /// <summary>
        /// クラス自体の名前とクラス中の public メソッドの名前を取得する。
        /// </summary>
        /// <param name="t">クラスの Type</param>
        private static void GetAllAuthors(Type t)
        {
            Console.Write("\r\nクラス名: {0}\n", t.Name);
            GetAuthors(t);//クラスのTypeオブジェクトを取得

            foreach (var methodInfo in t.GetMethods())//取得したTypeオブジェクトのメソッドを取得する
            {
                Console.Write("  メソッド名: {0}\n", methodInfo.Name);
                GetAuthors(methodInfo);
            }
        }

        /// <summary>
        /// クラスやメソッドの属性情報を取得する。
        /// </summary>
        /// <param name="info">クラスやメソッドの MemberInfo</param>
        private static void GetAuthors(MemberInfo info)//引数：メンバーの属性に関する情報を取得し、メンバーのメタデータにアクセスできるようにする
        {
            //★AllowMultipleパラメーターがtrueなので、GetCustomAttributesメソッドを使用し属性を取得する
            var authors = Attribute.GetCustomAttributes(info, typeof(AuthorAttribute));
            　　　　　　　　　　　　　　　　　　　　　　　　/*typeof：型の System.Type オブジェクトを取得するために使用する
                                   
            　　　　　　　　　　　　　　　　　　　　　　　　　 この場合typeofの検索対象         →AuthorAttribute(カスタム属性を作成したクラス)
            　　　　　　　　　　　　　　　　　　　　　　　  　 AuthorAttributeは何の型かを取得　→Class型*/

            //GetCustomAttributesメソッドの戻り値：typeに適用された element型のカスタム属性を格納する Attribute"配列"
            //authorsにはAttribute[]配列が入っている

            //★配列なのでforeachが使用可能
            //OfTypeはLINQの一種
            foreach (var author in authors.OfType<AuthorAttribute>())//Attribute[]配列の中でAuthorAttribute型(属性)に変換できる要素を取得する
            {            
                Console.Write("    属性名(作者名): {0}\n", author.Name);
            }
        }
    }
}
