using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CsharpクラスメンバーSample
{
    public partial class Form1 : Form
    {

        private readonly Other _other;

        public int A;
        public bool B;
        public string S;

        public Form1()
        {
            InitializeComponent();

            //this：インスタンス自身(Form1)を格納する特別な変数
            //otherインスタンスに対して自分の参照(先頭アドレス)を渡すことで、other内から自分（Form1）を操作できるようにするため
            _other = new Other(this);

            this.Form1_Method();

        }

        public void Form1_Method()
        {
            //何かの処理
        }
        

    }
}
