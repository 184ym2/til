using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpクラスメンバーSample
{
    class Other　//Form1を参照する
    {
        /// <summary>
        /// Form1を示すメンバ変数(フィールド)
        /// </summary>
        public Form1 Form1Obj;

        /// <summary>
        /// コンストラクタでは、引数として渡された Form1型の変数 Form1Obj を自分(Other_2.cs)の★メンバ変数(フィールド) Form1Obj に格納している
        /// </summary>
        /// <param name="form1Obj"></param>
        public Other(Form1 form1Obj)
        {
            //form1ObjはForm1の先頭アドレスを持っており、それを自分のメンバ変数(Form1Obj)に格納する
            Form1Obj = form1Obj;
        }

        public void test()
        {
            this.Form1Obj.Form1_Method();
            Form1Obj.label1.AutoSize = true;
            Form1Obj.Form1_Method();
            Form1Obj.A = 1;
            Form1Obj.B = true;
            Form1Obj.S = "あいうえお";
        }
    }
}
