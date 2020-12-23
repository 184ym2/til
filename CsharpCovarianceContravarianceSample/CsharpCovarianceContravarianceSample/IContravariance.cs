using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpCovarianceContravarianceSample
{
    // https://docs.microsoft.com/ja-jp/dotnet/csharp/language-reference/keywords/in-generic-modifier
    /// <summary>
    /// in 修飾子を定義して反変性（コントラバリアンス）を持つ型パラメーターを定義します　
    /// </summary>
    internal interface IContravariance<in T>
    {
        // 反変性を持つ型引数は、メソッドの引数に使用できる
        void Covarianceメソッド(T param);

        // 反変性を持つ型引数は、値変更時の処理に使用できる
        T Covarianceプロパティ { set; }
        // private T _Covarianceプロパティ;
        // set { this._Covarianceプロパティ = value; }


        // 反変性を持つ型引数は、メソッドの戻り値には使えない：エラー
        // T Covarianceメソッド2(T param);

        // 反変性を持つ型引数は、値取得時の処理には使えない：エラー　
        // T Covarianceプロパティ2 { get; }
        // private T _Covarianceプロパティ2;
        // get { return _Covarianceプロパティ2; }
    }
}