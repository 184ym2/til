using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CsharpCovarianceContravarianceSample
{
    // https://docs.microsoft.com/ja-jp/dotnet/csharp/language-reference/keywords/out-generic-modifier
    /// <summary>
    /// out 修飾子を定義して共変性（コーバリアンス）を持つ型パラメーターを定義します
    /// 共変性：広い型（継承元/基底クラス）から狭い型（継承先/派生クラス）へ変換する　※最初に指定されたものよりも強い派生した型（= 狭い型）を使用できるようにします
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal interface ICovariance<out T>
    {
        // 共変性を持つ型引数は、メソッドの戻り値に使用できる
        T Covarianceメソッド();

        // 共変性を持つ型引数は、値取得時の処理に使用できる
        T Covarianceプロパティ { get; }
        // private T _Covarianceプロパティ;
        // get { return this._Covarianceプロパティ; }


        // 共変性を持つ型引数は、メソッドの引数には使えない：エラー
        // T Covarianceメソッド2(T param);

        // 共変性を持つ型引数は、値変更時の処理には使えない：エラー　
        // T Covarianceプロパティ2 { set; }
        // private T _Covarianceプロパティ2;
        // set { this._Covarianceプロパティ2 = value; }　
    }
}