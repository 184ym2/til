using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpInterfaceSample
{
    /// <summary>
    /// 規定の実装を与える(オーバーライドしなければ、基底クラスのメソッド/プロパティが呼び出される)
    /// メンバ名にvirtual修飾子を付ける　※仮想メンバは、通常クラスに置ける
    /// </summary>
    public class VirtualClass
    {
        //静的メンバは仮想メンバにできない      
        //仮想メンバにはprivateアクセス修飾子を付けられない(public/internal/protectedのみ)
        public virtual string VirtualMethodA()
        {
            return "基底クラス_virtualなMethodです";
        }

        internal virtual string VirtualMethodB()
        {
            return "基底クラス_virtualなMethodです";
        }


        public virtual string VirtualプロパティA { get; set; }

        internal virtual string VirtualプロパティB { get; set; }

    }

    class 仮想クラスの継承 : VirtualClass
    {
        //継承先でオーバーライドするメンバのアクセス修飾子は、継承元と同じでなければならない
        public override string VirtualMethodA()
        {
            return "派生クラス_overrideされたMethodです";
        }

        public override string VirtualプロパティA { get { return "VirtualプロパティAです"; } }

    }
}
