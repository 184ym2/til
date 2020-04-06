using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpKeywordSample_1 /*対象キーワード[abstract][override]*/
{
    /// <summary>
    /// インスタンス(実体)を作成できない(abstract)抽象クラス 継承を前提に作成する
    /// </summary>
    internal abstract class AbstractSample
    {
        /// <summary>
        ///抽象プロパティ abstractがついているものは、継承先で必ずoverrideしなければならない
        /// </summary>
        public abstract int x { get; set; }

        public abstract int y { get; set; }

        //protected そのクラス内部+派生クラスのインスタンスからアクセス可能
        protected AbstractSample(int x, int y)
        {
            this.x = x;
            this.y = y;

        }

        /// <summary>
        ///抽象メソッド 意味のみを定義 実装なし 処理は継承先で記述
        /// </summary>
        public abstract int aSub1();

        //普通のメソッドも記述可能
        public int aMain()
        {
            return x + y;
        }
    }

    internal class ASubclass : AbstractSample
    {
        public override int x { get; set; }

        public override int y { get; set; }

        public override int aSub1()
        {
            return x*y;
        }

        public ASubclass(int x, int y) : base(x, y)
        {

        }
    }
}
