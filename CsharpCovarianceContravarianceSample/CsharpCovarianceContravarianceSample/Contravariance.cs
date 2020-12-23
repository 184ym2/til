using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpCovarianceContravarianceSample
{
    /// <summary>
    /// in 修飾子を定義して反変性（コーバリアンス）を持つ型パラメーターを定義します
    /// 反変性：狭い型（継承先/派生クラス）から広い型（継承元/基底クラス）へ変換する　※最初に指定されたものよりも一般的な（弱い派生の）型（= 広い型）を使用できるようにします
    /// </summary>
    internal class Contravariance
    {
        // Func および Action 汎用デリゲート (Visual Basic) の変性の使用 https://docs.microsoft.com/ja-jp/dotnet/csharp/programming-guide/concepts/covariance-contravariance/using-variance-for-func-and-action-generic-delegates
        public void Contravarianceメソッド()
        {
            var clF = new First_Contravariance();
            var clS = new Second_Contravariance();
            var clT = new Third_Contravariance();
            var clFo = new Fourth_Contravariance();

            // public delegate void Action<in T>(T obj);
            // 反変性（in）を持つ型引数は、デリゲートの引数の型パラメーター として指定できる
            Action<First_Contravariance> actionContravariance = first /* 指定した型と同じ型の引数を持つ */ =>
                                                                    {

                                                                    };

            var actionContravariance2 = actionContravariance; // 指定した型よりも、弱い派生をした型を引数に持つデリゲートを代入できる

            Action<Second_Contravariance> actionContravariance3 = First; // 指定した型よりも、弱い派生をした型を引数に持つメソッドを代入できる

            // 呼出対象になっているデリゲート型の、引数<型パラメーター>に合わせてインスタンスを渡す必要がある
            // ただし、引数<型パラメーター>の<型パラメーター>と同じクラスを継承した派生クラスのインスタンスは、引数として渡すことができる
            // 基底クラスの変数に派生クラスの変数を渡すこと = アップキャスト（upcast）

            actionContravariance(clF); // 型パラメーターは<First_Contravariance>
            actionContravariance(clS);
            actionContravariance(clT);

            actionContravariance2(clS); // 型パラメーターは<Second_Contravariance>
            actionContravariance2(clT);
            actionContravariance2(clFo);


            actionContravariance3(clS); // 型パラメーターは<Second_Contravariance>
            actionContravariance3(clT); // ★と同じ
            actionContravariance3(clFo);

            var secondcast = (Second_Contravariance)clT; 
            actionContravariance3(secondcast); // ★  

        }

        private void First(First_Contravariance first)
        {
        }

        public class First_Contravariance
        {
            public int Number;
            public string Name;
        }

        public class Second_Contravariance : First_Contravariance
        {
        }

        public class Third_Contravariance : Second_Contravariance
        {
        }

        public class Fourth_Contravariance : Second_Contravariance
        {
        }
    }
}