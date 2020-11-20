using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpInterfaceSample
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var clA = new 通常Classの継承();
            clA._基底MethodA();
            clA.派生Method();
            clA.基底フィールド = "基底Classのフィールドです";
            clA.基底プロパティa = "基底Classのプロパティです";
            clA.基底プロパティb = 100;
            clA.派生プロパティ = "派生ClassAのプロパティです";

            var clB = new インターフェースの継承();
            clB._基底MethodA();
            clB._基底MethodB("IBaseのMethodです");
            clB.基底プロパティa = "IBaseのプロパティです";
            clB.基底プロパティb = 100;

            var clD = new 抽象クラスの継承();
            clD.DelegateB("派生クラスのDelegateBです");
            clD.AbstractMethodA();
            clD.AbstractMethodB("派生クラス_overrideされたMethodBです");
            clD.AbstractMethodC();
        }
    }
}