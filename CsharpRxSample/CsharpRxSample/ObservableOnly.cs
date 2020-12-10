using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;

namespace CsharpRxSample
{
    /// <summary>
    /// IObserver[T](観測者)を自動生成し、1~5の値を発行するIObservable[T](観測対象)を生成
    /// </summary>
    internal class ObservableOnly
    {
        public void Observable_Only()
        {
            Console.WriteLine("\r\n---Observer(観測者)は自動生成し、observable(観測対象)を手動で生成します：1---\r\n");

            // ★観測者：★わざわざ Observer.Create を使用してObserver(観測者)を作るのは面倒

            #region IObservable<T>(観測対象)を実装する：Subscribeメソッドの適切な実装

            // https://docs.microsoft.com/en-us/previous-versions/dotnet/reactive-extensions/hh211896(v=vs.103)
            // ★観測対象：public static IObservable<int> Range(int start, int count)
            // 指定された範囲内で観測可能(オブザーバブル)な積分数列を生成します
            // 引数　：int
            // 戻り値：連続する整数の範囲を含む観測可能なシーケンス
            var observable = Observable.Range(1, 5);

            // 1. オブザーバーブル(プロパイダ)を生成します
            // 2. オブザーバーブル(プロパイダ)のメンバーであるSubscribeメソッドの処理を記述します
            // ※ オブザーバーブルは自身が変化した適切なタイミングで、OnXXXメソッドを適切に呼び出すことが求められます(= Subscribeメソッドの処理)

            // Observable.Range(int, int)内で、OnXXXメソッドを呼び出している

            #endregion

            #region IObservable<T>(観測対象)のSubscribeメソッドに、IObservar<T>(観測者)を生成するために必要な引数(デリゲート)をセットする：(= Subscribeメソッド呼び出し)

            // https://github.com/dotnet/reactive/blob/main/Rx.NET/Source/src/System.Reactive/Observable.Extensions.cs
            // ObservableExtensions.cs：観測可能なデリゲートをサブスクライブするための静的メソッドのセットを提供します

            // https://github.com/dotnet/reactive/blob/main/Rx.NET/Source/src/System.Reactive/Observable.Extensions.cs#L140
            // ObservableExtensions.cs 内に定義されている拡張メソッド：public static IDisposable Subscribe<T>(this IObservable<T> source, Action<T> onNext, Action<Exception> onError, Action onCompleted);           
            // ここでSubscribeの引数としてデリゲート(メソッドの処理内容)を渡すと、IObservable<T>.Subscribe経由でObserver<T>(観測者)を自動生成する
            /*
             * public static IDisposable Subscribe<T>(this IObservable<T> source, Action<T> onNext, Action<Exception> onError, Action onCompleted)
             * {
             *     ~省略
             *     return source.Subscribe(new AnonymousObserver<T>(onNext, onError, onCompleted)); 
             *     ここで AnonymousObserver<T> が生成されているため、Observer<T>(観測者)を手動生成しなくても良い
             * }
             * 
             */

            // ★IObservable<T>(観測対象)は自身の状態の変化に応じてOnXXXメソッドを適切に呼び出すことが求められる
            // ★IObserver<T>(観測者)の実装ではそれに適切に応答することが求められる

            // Q. IObservable<T>(観測対象)Subscribeに引数を渡す(IObserver<T>またはObserverを適切に実装するためのデリゲート)とは？
            // 1. 拡張メソッドのSubscribeを呼び出すと、さらにIObservable<T>.Subscribeが呼び出される
            // 2. IObservable<T>.Subscribeで新しいObserver<T>(観測者)を生成する

            // オブザーバーブル：IObservable<T>(観測対象)が変化する(= OnXXXメソッドの呼び出し)
            // オブザーバー　　：IObserver<T>(観測者).OnXXXメソッド内で、IObservable<T>(観測対象).Subscribeで渡したデリゲートが呼び出される

            observable.Subscribe(
                                 // ここで受け取ったデリゲート(Action<T>)がオブザーバーのOnNext(T)内で実行される：値が発生した
                                 x =>
                                     {
                                         Console.WriteLine(Message.OnNextMessage + x);
                                         Console.ReadKey();
                                     },
                                 // ここで受け取ったデリゲート(Action<Exception>)がオブザーバーのOnError(Exception error)内で実行される：エラーが発生した
                                 ex =>
                                     {
                                         throw ex;
                                     },
                                 // ここで受け取ったデリゲート(Action)がオブザーバーのOnCompleted()内で実行される：正常に終了した
                                 () =>
                                     {
                                         Console.WriteLine(Message.OnCompletedMessage);
                                         Console.ReadKey();
                                     });

            #endregion
        }
    }
}