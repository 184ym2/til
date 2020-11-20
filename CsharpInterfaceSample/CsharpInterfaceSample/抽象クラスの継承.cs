using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CsharpInterfaceSample
{
    /// <summary>
    /// 規定の実装を与えない(派生クラス毎に実装したい)　
    /// 抽象クラスはインスタンス化不可　クラス名・メンバ名にabstract修飾子を付ける　※抽象メンバは、抽象クラスだけに置ける
    /// </summary>  
    internal abstract class AbstractClass
    {
        //静的メンバは抽象メンバにできない
        //抽象メンバにはprivateアクセス修飾子を付けられない(public/internal/protectedのみ)
        public abstract string AbstractMethodA();

        internal abstract Func<string, string> AbstractMethodB(string s);

        internal abstract void AbstractMethodC();

        public abstract string propertyA { get; set; }

        internal abstract int propertyB { get; set; }

        //基底の抽象クラスに（抽象メンバの他に）実装を持つメソッド／プロパティも追加できる

        public string 通常Method()
        {
            return "基底クラス_通常Methodです";
        }

        private Func<string, string> delegateA;

        /// <summary>
        /// 型：戻り値string,引数stringのMethod/Method参照　※値変更時は、delegateA(戻り値string,引数string)をreturnする
        /// </summary>
        public Func<string, string> propertyC { get { return delegateA; } set { delegateA = value; } }
    }

    /// <summary>
    /// AbstractClassを継承している
    /// </summary>
    internal class 抽象クラスの継承 : AbstractClass
    {
        //継承先でオーバーライドするメンバのアクセス修飾子は、継承元と同じでなければならない
        //継承先のクラスでは、全ての抽象メンバをオーバーライドしなければ、インスタンス化できない　※オーバーライドしなかった抽象メンバが残っている場合は、継承先のクラスも抽象クラスにしなければならない
        public string 通常Method(string s)
        {
            return "派生クラスの通常Methodです";
        }

        public Func<string, string> DelegateB = s => s;

        #region Overrides of AbstractClass

        /// <summary>
        /// 基底クラスからオーバーライドされたMethod
        /// </summary>
        /// <returns>string型</returns>
        public override string AbstractMethodA()
        {
            base.通常Method();

            //型：戻り値string,引数stringのMethod/Method参照なので、AbstractMethodBがセット可能
            base.propertyC = AbstractMethodB("AbstractMethodB");

            return "派生クラス_overrideされたAbstractMethodAです";
        }

        /// <summary>
        /// 基底クラスからオーバーライドされたMethod
        /// </summary>
        /// <param name="s">string型</param>
        /// <returns>戻り値string,引数stringのMethod</returns>
        internal override Func<string, string> AbstractMethodB(string s)
        {
            var 匿名Methodがsにセットされる = s == "AbstractMethodB"
                                        ? DelegateB
                                        : 通常Method;

            var 通常Methodがsにセットされる = s == "AbstractMethodB"
                                        ? 通常Method
                                        : DelegateB;

            return 通常Methodがsにセットされる;
        }

        internal override void AbstractMethodC()
        {
            Console.WriteLine("派生クラス_overrideされたMethodCです");
        }

        public override string propertyA { get; set; }

        internal override int propertyB { get; set; }

        #endregion
    }
}