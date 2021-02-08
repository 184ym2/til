using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Windows.Forms;

namespace GetFolder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //ui表示.Click += (sender, args) =>
            //                  {
            //                      uiフォルダ表示.Items.Clear();
            //                      uiフォルダ表示.Refresh();
            //                      取得したフォルダを表示();
            //                  };

            uiコピー.Click += (sender, args) =>
                               {
                                   var sb = new StringBuilder();

                                   foreach (var selectedItems in uiフォルダ表示.SelectedItems)
                                   {
                                       sb.Append(selectedItems).Append(Environment.NewLine);
                                   }

                                   Clipboard.SetText(sb.ToString());
                               };

            ui表示更新();
        }

        private void ui表示更新()
        {
            // 間違っていたコード：イベント名が"KeyDown"ではなく"Click"になっている
            // 例外：The second parameter of the event delegate must be assignable to 'System.Windows.Forms.KeyEventArgs'.
            // 訳　：イベントデリゲートの2番目のパラメータは、'System.Windows.Forms.KeyEventArgs'に代入可能である必要があります。
            // Observable.FromEventPattern<KeyEventArgs>(this, "Click").Where(e => e.EventArgs.KeyCode == Keys.F5);

            // 理由：Clickイベント(public event EventHandler Click;)は、public delegate void EventHandler(object? sender, EventArgs e); の第2引数にpublic class EventArgs というイベントデータを渡す(イベント データを含まないイベントに使用する値を提供します)
            // 　　　KeyDownイベント(public event System.Windows.Forms.KeyEventHandler KeyDown;)は、public delegate void KeyEventHandler(object? sender, KeyEventArgs e); の第2引数にpublic class public class KeyEventArgs : EventArgs というというイベントデータを渡す

            Observable.FromEventPattern<EventArgs>(ui表示, "Click").Select(_ => Unit.Default) //OK
                      .Merge(Observable.FromEventPattern<KeyEventArgs>(this, "KeyDown").Where(e => e.EventArgs.KeyCode == Keys.F5).Select(_ => Unit.Default)) //NG
                      .Throttle(new TimeSpan(100))
                      .ObserveOn(new WindowsFormsSynchronizationContext())
                      .Subscribe(_ =>
                                     {
                                         uiフォルダ表示.Items.Clear();
                                         uiフォルダ表示.Refresh();
                                         取得したフォルダを表示();
                                     });
        }

        // 省略可能な引数：メソッド呼び出し時に引数を省略でき、=で指定した値が規定値となる
        // https://docs.microsoft.com/ja-jp/dotnet/csharp/programming-guide/classes-and-structs/named-and-optional-arguments#optional-arguments
        public string[] GetDirectories(string path, string searchPattern = "*")
        {
            // Directory.EnumerateDirectoriesメソッド(.NET Framwork 4.0以降)
            // https://docs.microsoft.com/ja-jp/dotnet/api/system.io.directory.enumeratedirectories?view=net-5.0
            // 絶対・相対パス, 検索文字列, ディレクトリ指定
            // 全探索ではなく、見つかり次第結果を返すため、サブフォルダを一つ一つ列挙する場合はこちらのほうが早い
            return System.IO.Directory.EnumerateDirectories(path, searchPattern, System.IO.SearchOption.AllDirectories).ToArray();

            // Directory.GetDirectoriesメソッド(.NET Framwork 2.0以降)
            // https://docs.microsoft.com/ja-jp/dotnet/api/system.io.directory.getdirectories?view=net-5.0
            // 絶対・相対パス, 検索文字列, ディレクトリ指定
            return System.IO.Directory.GetDirectories(path, searchPattern, System.IO.SearchOption.AllDirectories);
        }

        public void 取得したフォルダを表示()
        {
            uiフォルダ表示.Items.AddRange(GetDirectories(@"" + uiパス入力.Text, ui検索文字列入力.Text));
        }
    }
}