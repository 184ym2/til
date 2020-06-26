using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace CsharpInterfaceSample
{
    //規定の実装を与える
    public class 基底Class
    {
        //定義+実装を記述
        public string _基底MethodA()
        {
            return "基底Classの基底Methodです";
        }

        public string 基底フィールド;

        public string 基底プロパティa { get; set; }

        public int 基底プロパティb { get; set; }
    }

    public class 通常Classの継承 : 基底Class
    {
        //基底Classのメンバはoverrideされない：基底Classのmemberは、基底Classのもの
        public string 派生プロパティ;

        public string 派生Method()
        {
            return base.基底プロパティa;
        }
    }
}