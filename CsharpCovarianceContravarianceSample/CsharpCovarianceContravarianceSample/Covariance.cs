using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace CsharpCovarianceContravarianceSample
{
    /// <summary>
    /// out 修飾子を定義して共変性（コーバリアンス）を持つ型パラメーターを定義します
    /// 共変性：広い型（継承元/基底クラス）から狭い型（継承先/派生クラス）へ変換する　※最初に指定されたものよりも強い派生した型（= 狭い型）を使用できるようにします
    /// </summary>
    public class Covariance
    {
        // Func および Action 汎用デリゲート (Visual Basic) の変性の使用 https://docs.microsoft.com/ja-jp/dotnet/csharp/programming-guide/concepts/covariance-contravariance/using-variance-for-func-and-action-generic-delegates
        public void Covarianceメソッド()
        {
            var clF = new First_Covariance();
            var clS = new Second_Covariance();
            var clT = new Third_Covariance();
            var clFo = new Fourth_Covariance();

            // public delegate TResult Func<out TResult>();
            // 共変性（out）を持つ型引数は、デリゲートの戻り値の型パラメーター として指定できる
            Func<First_Covariance> actionCovariance = () => new First_Covariance(); // 指定した型と同じ型を返すことができる  
            Func<First_Covariance> actionCovariance2 = () => new Second_Covariance(); // 指定した型よりも、強い派生をした型を返すことができる      
            var actionCovariance3 = actionCovariance; // 指定した型よりも、強い派生をした型を返すデリゲートを代入できる

            actionCovariance();
            actionCovariance2();
            actionCovariance3();

            // public delegate TResult Func<in T,out TResult>(T arg);        
            // 反変性（in）を持つ型引数は、デリゲートの引数の型パラメーター として指定できる
            // 共変性（out）を持つ型引数は、デリゲートの戻り値の型パラメーター として指定できる
            Func<Second_Covariance, First_Covariance> actionCovarianceContravariance = second /* 指定した型と同じ型の引数を持つ */ =>
                                                                                           {
                                                                                               return new Second_Covariance(); // 指定した型よりも、強い派生をした型を返すことができる
                                                                                           };

            Func<Second_Covariance, First_Covariance> actionCovarianceContravariance2 = First; // 指定した型よりも、弱い派生をした型を引数に持てる

            // 呼出対象になっているデリゲート型の、引数<型パラメーター>に合わせてインスタンスを渡す必要がある
            // ただし、引数<型パラメーター>の<型パラメーター>と同じクラスを継承した派生クラスのインスタンスは、引数として渡すことができる
            // 基底クラスの変数に派生クラスの変数を渡すこと = アップキャスト（upcast）

            actionCovarianceContravariance(clS);  // 型パラメーターは<Second_Covariance>
            actionCovarianceContravariance(clT);
            actionCovarianceContravariance(clFo);

            actionCovarianceContravariance2(clS);

            
        }

        private Second_Covariance First(Second_Covariance second)
        {
            return new Second_Covariance(); // 指定した型よりも、強い派生をした型を返すことができる
        }
    }

    public class First_Covariance
    {
        public int Number;
        public string Name;
    }

    public class Second_Covariance : First_Covariance
    {
    }

    public class Third_Covariance : Second_Covariance
    {
    }

    public class Fourth_Covariance : Second_Covariance
    {
    }
}