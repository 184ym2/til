using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GetFolder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            ui表示.Click += (sender, args) =>
                              {
                                  uiフォルダ表示.Items.Clear();
                                  uiフォルダ表示.Refresh();
                                  フォルダ表示();
                              };

            uiコピー.Click += (sender, args) =>
                               {
                                  
                                   foreach (var selectedItem in uiフォルダ表示.SelectedItems)
                                   {
                                                                            
                                   }
                               };
        }

        public string[] GetDirectories(string path)
        {
            // 全てのフォルダを意味する「*」
            return System.IO.Directory.GetDirectories(path, "*", System.IO.SearchOption.AllDirectories);
        }

        public void フォルダ表示()
        {
            uiフォルダ表示.Items.AddRange(GetDirectories(@"" + uiパス入力.Text));
        }
    }
}