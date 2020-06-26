using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpInterfaceSample
{
    /// <summary>
    /// 規定の実装を与えない(汎用)
    /// </summary>
    internal interface IBase
    {
        //記述後全てが public abstract 扱いになる

        //定義のみ記述
        string _基底MethodA();
        string _基底MethodB(string b);

        //メンバー変数(フィールド)を持つことが出来ない
        string 基底プロパティa { get; set; }

        int 基底プロパティb { get; set; }
    }

    public class インターフェースの継承 : IBase
    {
        #region Implementation of ITest

        //IBaseのmemberは強制的にoverrideされる：IBaseのmemberは、派生ClassBのものになる
        public string _基底MethodA()
        {
            return "IBaseの_基底MethodAを実装";
        }

        public string _基底MethodB(string b)
        {
            return "IBaseの_基底MethodBを実装" + b;
        }

        public string 基底プロパティa { get; set; }

        public int 基底プロパティb { get; set; }

        #endregion
    }
}