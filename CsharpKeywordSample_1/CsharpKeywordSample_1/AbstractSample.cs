using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpKeywordSample_1 /* 対象キーワード[abstract][override] */
{
    /// <summary>
    /// インスタンス(実体)を作成できない(abstract)抽象クラス 継承を前提に作成する
    /// </summary>
    public abstract class AbstractSample
    {
        /// <summary>
        /// 抽象プロパティ abstractがついているものは、継承先で必ずoverrideしなければならない
        /// </summary>
        public abstract int x { get; set; }

        public abstract int y { get; set; }

        private int _number = 5;

        /// <summary>
        /// 通常プロパティ
        /// </summary>
        public int Number { get { return _number; } set { _number = value; } }

        // protected そのクラス内部+派生クラスのインスタンスからアクセス可能
        protected AbstractSample(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// 抽象メソッド 意味のみを定義 実装なし 処理は継承先で記述
        /// </summary>
        public abstract void Ab1();

        /// <summary>
        /// 普通のメソッドも記述可能
        /// </summary>
        /// <returns></returns>
        public void Ab2()
        {
            Console.WriteLine("\n★★★AbstractSample Ab2★★★\n" + "x:" + x + " y:" + y + " Number:" + Number);
        }
    }

    public class Subclass : AbstractSample
    {
        public override int x { get; set; }

        public override int y { get; set; }

        public Subclass(int x, int y) : base(x, y)
        {
        }

        public override void Ab1()
        {
            Console.WriteLine("\n★★★Subclass Ab1 : AbstractSample★★★\n" + "x:" + x + " y:" + y);
        }

        public void Ab3()
        {
            Console.WriteLine("\n★★★Subclass Ab3 : AbstractSample★★★\n" + "x:" + x + " y:" + y);
        }
    }

    public class AbstractSample2
    {
        public void show()
        {
            var ab = new Subclass(5, 10);
            ab.Ab1();
            ab.Ab2();
            ab.Ab3();
        }

        public void show2()
        {
            AbstractSample ab = new Subclass(5, 10);
            ab.Ab1();
            ab.Ab2();
            //ab.Ab3(); AbstractSample.csにAb3()が無いため、コンパイルエラー
        }
    }
}