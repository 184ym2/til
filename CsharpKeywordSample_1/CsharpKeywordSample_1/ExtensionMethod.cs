using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CsharpKeywordSample_1 /*拡張メソッド*/
{
    public class 拡張メソッド呼び出し
    {
        //配列版とIEnumerable版どちらも配列を引数にして呼び出すことはできる
        //だが配列版では、List<T>を引数にして呼び出すことができない
        //つまり、IEnumerable版のほうが受けられる型が多い

        public void 拡張メソッドさんぷる()
        {
            Console.Write("\r\n★★★拡張メソッドさんぷる1★★★\r\n");
            /*↓引数↓*/
            IEnumerable<int> enumerable = new[] { 1, 2, 3, 4, 5, 6 }; //IEnumerable<int> ints にはint配列が入っている
            //配列の初期化「var ints = new int[];」 と同じ

            /*メソッド呼び出し 戻り値(data)…IEnumerable<int>型*/
            enumerable = enumerable.拡張メソッド1();
            foreach (var x in enumerable)
                Console.Write("{0}\n", x);
            
        }

        public void 拡張メソッドさんぷる2()
        {
            /*静的(static)メソッドをインスタンスメソッドと同じ書式で呼び出せる*/
            Console.Write("\r\n★★★拡張メソッドさんぷる2★★★\r\n");
            const string s = "This Is a Test String.\n";
            Console.Write("\r\nToggleCaseの s を拡張　" + s.拡張メソッド2());
            Console.ReadKey();
        }
    }
    
    /// <summary>
    ///拡張メソッドを記述するための静的クラス①
    /// </summary>
    static class 拡張メソッド記載の静的クラス1
    {
        /// <summary>
        /// 拡張メソッド：既に存在する(IEnumerable<T/>)を拡張する
        /// 戻り値の型…IEnumerable<T/> 第一引数のIEnumerable<T/>…拡張したいインターフェース
        /// </summary>
        public static IEnumerable<T> 拡張メソッド1<T>(this IEnumerable<T> array)//array = IEnumerable<T>
        {
            foreach (var x in array)
            {
                //呼び出し元に値を返しつつ繰り返し処理を継続する 2回yield returnすると値が2回表示される
                yield return x;
                yield return x;
            }
        }

    }

    /// <summary>
    ///拡張メソッドを記述するための静的クラス②
    /// </summary>
    static class 拡張メソッド記載の静的クラス2
    {
        /// <summary>
        /// 拡張メソッド：文字列の大文字と小文字を入れ替える。
        /// </summary>
        /// <param name="s">変換元</param>
        /// <returns>変換結果</returns>
        /// 
        public static string 拡張メソッド2(this string s)//ToggleCaseメソッドのsを拡張する
        {
            //StringBuilderクラス(既存のクラス) 文字列に変更を加えたい場合に使用する
            var sb = new StringBuilder();

            //StringBuilderクラスにあるメソッド
            foreach (var c in s)
            {
                if (char.IsUpper(c))
                    sb.Append(char.ToLower(c));
                else if (char.IsLower(c))
                    sb.Append(char.ToUpper(c));
                else
                    sb.Append(c);
            }
            return sb.ToString();
        }
    }




    /// <summary>
    ///自作インターフェース
    /// </summary>
    public interface INterface1
    {
        int x { get; set; }
        int y { get; set; }

        //通常は定義(規約)しか記述できない
        int 通常Method1();

    }

    /// <summary>
    ///拡張メソッドを記述するための静的クラス③
    /// </summary>
    public static class ExtensionMethod
    {
        /// <summary>
        ///拡張メソッド:自分で作成したINterface1を拡張する
        /// </summary>
        public static int 加算(this INterface1 if1)
        {
            return if1.x + if1.y;
        }

    }

    //自分で作成したインターフェースを継承したクラス
    internal class SampleClass : INterface1
    {
        public int x { get; set; }

        public int y { get; set; }

        //通常のメソッド実装はここ
        public int 通常Method1()//クラスごとに実装が異なる
        {
            return x + y;

        }
    }

}
