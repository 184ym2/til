using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpKeywordSample_1
{
    public class Escape文字
    {
        public void 改行文字列()
        {
            /*
               OSの差異を意識せずに改行コードを利用するには、Environmentクラスの静的プロパティであるNewLineプロパティを使用する
               CR「\r」           
               LF「\n」(Linux)        
               CR＋LF「\r\n」(Windows)
             * 
               補足：コンソールへの出力、Label、Buttonコントロール：ラインフィード「\n」でも改行可
               　　　MessageBox.Showメソッドによるメッセージの表示、ToolTipコントロールなど：ラインフィード「\n」キャリッジリターン「\r」でも改行可
               　　　TextBoxコントロール：キャリッジリターン + ラインフィード「\r\n」のみ改行可
               　　　RichTextBoxコントロール：キャリッジリターン「\r」ラインフィード「\n」のみでも改行可　※ただしRichTextBoxのTextプロパティが返す文字列では、改行はラインフィード「\n」のみ
             */
            var rt = Environment.NewLine;
            Console.Write("\n★★★改行文字列★★★\n");
            Console.WriteLine(rt.Equals("\r"));
            Console.WriteLine(rt.Equals("\n")); //Linux
            Console.WriteLine(rt.Equals("\r\n")); //Windows
            Console.ReadKey();
        }
    }
}