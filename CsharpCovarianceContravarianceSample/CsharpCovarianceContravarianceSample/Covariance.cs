// =======================================================
// 株式会社UR PCOMシリーズ VER 6 REV16~
// CsharpCovarianceContravarianceSample.Covariance.cs
// 
// 最終更新日:2021/01/12 15:42
// =======================================================

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
            var fir = new 基底クラス_Ca();
            var sec = new 派生クラス2_Ca();
            var thi = new 派生クラス3_Ca();
            var fou = new 派生クラス4_Ca();

            // 共変性（out）を持つ型引数は、デリゲートの戻り値の型パラメーター として指定できる
            // public delegate TResult Func<out TResult>();
            Func<派生クラス2_Ca> covariance2 = () => new 派生クラス2_Ca();
            Func<派生クラス3_Ca> covariance3 = () => new 派生クラス3_Ca();

            // 1. 指定した型よりも、強い派生をした型を返すことができる
            Func<基底クラス_Ca> 引数は基底クラス = () => new 派生クラス2_Ca();
            Func<派生クラス2_Ca> 引数は派生クラス2 = () => new 派生クラス3_Ca();
            Func<派生クラス3_Ca> 引数は派生クラス3 = () => new 派生クラス4_Ca();

            // 2. 指定した型よりも、強い派生をした型を返すデリゲートを代入できる
            Func<基底クラス_Ca> _引数は基底クラス = covariance2;
            Func<派生クラス2_Ca> _引数は派生クラス2 = covariance3;

            // 3. 指定した型よりも、強い派生をした型を返すメソッドを代入できる
            Func<派生クラス3_Ca> _引数は派生クラス3 = ReturnForth;

            covariance2();
            covariance3();

            // 反変性（in）を持つ型引数は、デリゲートの引数の型パラメーター として指定できる
            // 共変性（out）を持つ型引数は、デリゲートの戻り値の型パラメーター として指定できる
            // public delegate TResult Func<in T,out TResult>(T arg);

            // 1.
            // out TResult：指定した型よりも、強い派生をした型を返すことができる
            Func<派生クラス2_Ca, 基底クラス_Ca> covariancecontravariance = second =>
                                                                     {
                                                                         // 指定した型と同じ型の引数を持つ
                                                                         // 指定した型よりも、強い派生をした型を返すことができる
                                                                         return new 派生クラス2_Ca();
                                                                     };

            // 2.             
            // in T       ：指定した型よりも、弱い派生をした型を引数に持つデリゲートを代入できる
            // out TResult：指定した型よりも、強い派生をした型を返すデリゲートを代入できる
            Func<派生クラス3_Ca, 基底クラス_Ca> covariancecontravariance2 = covariancecontravariance;

            // 3. 
            // in T       ：指定した型よりも、弱い派生をした型を引数に持つメソッドを代入できる
            // out TResult：指定した型よりも、強い派生をした型を返すメソッドを代入できる
            Func<派生クラス3_Ca, 基底クラス_Ca> covariancecontravariance3 = ArgFirstReturnSecond;

            #region デリゲートの実行時 -UpCast-

            // 呼出対象になっているデリゲート型の、引数<型パラメーター>に合わせてインスタンスを渡す必要がある
            // ただし、引数<型パラメーター>の<型パラメーター>と同じクラスを継承した派生クラスのインスタンスは、引数として渡すことができる
            // 基底クラスの変数に派生クラスの変数を渡すこと = アップキャスト（UpCast）

            // 型パラメーターが派生クラス2の場合：派生クラス2から派生した型を渡せる
            covariancecontravariance(sec);
            covariancecontravariance(thi);
            covariancecontravariance(fou);

            covariancecontravariance3(thi);
            covariancecontravariance3(fou);

            #endregion
        }

        /// <summary>
        /// 指定した型よりも、強い派生をした型を返すことができる
        /// </summary>
        private static 基底クラス_Ca ArgFirstReturnSecond(基底クラス_Ca second)
        {
            return new 派生クラス2_Ca();
        }

        /// <summary>
        /// 指定した型よりも、強い派生をした型を返すことができる
        /// </summary>
        private static 派生クラス3_Ca ReturnForth()
        {
            return new 派生クラス4_Ca();
        }
    }

    public class 基底クラス_Ca
    {
        public string Name;
        public int Number;
    }

    public class 派生クラス2_Ca : 基底クラス_Ca
    {
    }

    public class 派生クラス3_Ca : 派生クラス2_Ca
    {
    }

    public class 派生クラス4_Ca : 派生クラス3_Ca
    {
    }
}