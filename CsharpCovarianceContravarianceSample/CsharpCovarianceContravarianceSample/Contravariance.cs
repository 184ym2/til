// =======================================================
// 株式会社UR PCOMシリーズ VER 6 REV16~
// CsharpCovarianceContravarianceSample.Contravariance.cs
// 
// 最終更新日:2021/01/12 15:42
// =======================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpCovarianceContravarianceSample
{
    /// <summary>
    /// in 修飾子を定義して反変性（コントラバリアンス）を持つ型パラメーターを定義します
    /// 反変性：狭い型（継承先/派生クラス）から広い型（継承元/基底クラス）へ変換する　※最初に指定されたものよりも一般的な（弱い派生の）型（= 広い型）を使用できるようにします
    /// </summary>
    internal class Contravariance
    {
        // Func および Action 汎用デリゲート (Visual Basic) の変性の使用 https://docs.microsoft.com/ja-jp/dotnet/csharp/programming-guide/concepts/covariance-contravariance/using-variance-for-func-and-action-generic-delegates
        public void Contravarianceメソッド()
        {
            var fir = new 基底クラス_Cv();
            var sec = new 派生クラス2_Cv();
            var thi = new 派生クラス3_Cv();
            var fou = new 派生クラス4_Cv();

            // 反変性（in）を持つ型引数は、デリゲートの引数の型パラメーター として指定できる
            // public delegate void Action<in T>(T obj); 
            Action<基底クラス_Cv> contravariance = 基底クラスCv =>
                                                  {
                                                  };

            Action<派生クラス2_Cv> contravariance2 = 派生クラス2Cv =>
                                                    {
                                                    };

            Action<派生クラス3_Cv> contravariance3 = 派生クラス3Cv =>
                                                    {
                                                    };

            // 1. 指定した型よりも、弱い派生をした型を引数に持つデリゲートを代入できる
            Action<派生クラス2_Cv> 引数は派生クラス2 = contravariance;
            Action<派生クラス3_Cv> 引数は派生クラス3 = contravariance;
            Action<派生クラス4_Cv> 引数は派生クラス4 = contravariance2;

            // 2. 指定した型よりも、弱い派生をした型を引数に持つメソッドを代入できる
            Action<派生クラス2_Cv> _引数は派生クラス2 = First;
            Action<派生クラス3_Cv> _引数は派生クラス3 = First;
            Action<派生クラス4_Cv> _引数は派生クラス4 = Second;

            #region デリゲートの実行時 -UpCast-

            // 呼出対象になっているデリゲート型の、引数<型パラメーター>に合わせてインスタンスを渡す必要がある
            // ただし、引数<型パラメーター>の<型パラメーター>と同じクラスを継承した派生クラスのインスタンスは、引数として渡すことができる
            // 基底クラスの変数に派生クラスの変数を渡すこと = アップキャスト（UpCast）

            // 型パラメーターが基底クラスの場合：基底クラスから派生した型を渡せる
            contravariance(fir);
            contravariance(sec);
            var thirdcast = (派生クラス3_Cv) fou; // 派生クラス4型の変数fouを派生クラス3型にキャストしている
            contravariance(thirdcast);

            // 型パラメーターが派生クラス2の場合：派生クラス2から派生した型を渡せる
            contravariance2(sec);
            contravariance2(thi);
            contravariance2(fou);

            // 型パラメーターが派生クラス3の場合：派生クラス3から派生した型を渡せる
            contravariance3(thi);
            contravariance3(fou);

            #endregion
        }

        private static void First(基底クラス_Cv 基底クラス)
        {
        }

        private static void Second(派生クラス2_Cv 派生クラス2)
        {
        }
    }

    public class 基底クラス_Cv
    {
        public string Name;
        public int Number;
    }

    public class 派生クラス2_Cv : 基底クラス_Cv
    {
    }

    public class 派生クラス3_Cv : 派生クラス2_Cv
    {
    }

    public class 派生クラス4_Cv : 派生クラス3_Cv
    {
    }
}