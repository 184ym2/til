using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;

namespace CsharpRxSample
{
    internal class SimpleObservable
    {
        /// <summary>
        /// Observerを生成し、1~5の値を出力するObservableを生成
        /// </summary>
        public void ObservableRange()
        {
            // public static IObserver<T> Create<T>(Action<T> onNext, Action<Exception> onError, Action onCompleted);
            // 指定された OnNext、OnError、および OnCompleted アクションからオブザーバを作成します
            // <T>：観測者が受信した要素の型 戻り値：与えられたアクションを使用して実装されたオブザーバーオブジェクト          
            var observer = Observer.Create<int>(
                                                // OnNextアクションの実装 = 値が発生した
                                                // ラムダ式で書くと：x => Console.WriteLine(x)
                                                Console.WriteLine,
                                                ex =>
                                                    {
                                                        // OnErrorアクションの実装 = エラーが発生した
                                                        throw ex;
                                                    },
                                                () =>
                                                    {
                                                        // OnCompletedアクションの実装 = 正常に終了した
                                                    });

            // public static IObservable<int> Range(int start, int count)
            // 指定された範囲内で観測可能(オブザーバブル)な積分数列を生成します
            // 戻り値：連続する整数の範囲を含む観測可能なシーケンス          
            var observable = Observable.Range(1, 5); // シーケンスの最初の整数の値, 生成する連続整数の数

            // 引数として渡されたobserverになんらかの現象が起こったことを通知する = 観測対象に観測者を登録する
            // IDisposable Subscribe(System.IObserver<T> observer);　戻り値:IDisposable
            observable.Subscribe(observer);
        }

        /// <summary>
        /// Observerを自動生成し、1~5の値を出力するObservableを生成
        /// </summary>
        public void ObservableRange_Simple()
        {
            // ★わざわざ Observer.Create を使用してObserver(観測者)を作るのは面倒
            var observable = Observable.Range(1, 5);

            // このSubscribeは ObservableExtensions.cs Observable<T>の拡張メソッド
            // ここでSubscribeの引数としてデリゲート(メソッドの処理内容)を渡すと、内部でObserver(観測者)を自動生成する
            observable.Subscribe(Console.WriteLine /*x => Console.WriteLine(x)*/);

            // 一行で書くとこうなる
            Observable.Range(1, 5).Subscribe(Console.WriteLine);

            // 色々なオーバーロードがある
            Observable.Range(1, 5).Subscribe(Console.WriteLine,
                                             ex => Console.WriteLine("Error"),
                                             () => Console.WriteLine("Completed"));
        }

        /// <summary>
        /// Observerを自動生成し、1, 2, 3,という値を発行して完了する
        /// </summary>
        public void ObservableCreate()
        {
            // public static IObservable<TResult> Create<TResult>(Func<IObserver<TResult>,Action> subscribe) ★Func<T, TResult>
            // 指定されたsubscribeメソッドの実装から、指定されたsubscribeで観測可能なシーケンス(Observable)を作成します

            // 引数：public Action XXX(IObserver<TResult> xxx){ return Dispose(); ※public void Dispose(); ★Disposeされた時に実行される処理 }; 
            // ▶呼び出し XXX(IObserver<TResult> xxx); = ★この呼び出し方をする処理を引数としてラムダ式で書く　
            // ※Subscribe(); と同じ呼び出し方　Subscribeの戻り値はIDisposable

            var observable = Observable.Create<int>(observer /*引数：IObserver<TResult>*/ =>
                                                        {
                                                            // 1, 2, 3と順番に値を発行して終了するIObservable<int>を生成する

                                                            // 引数のIObserver<int>に対してOn****メソッドを呼ぶ
                                                            observer.OnNext(1);
                                                            observer.OnNext(2);
                                                            observer.OnNext(3);
                                                            observer.OnCompleted();

                                                            // 戻り値：Action　Disposeされた時に実行される処理
                                                            return () => Console.WriteLine("Disposable action");
                                                        }) /* 結果のオブザーバブルシーケンスのサブスクライブメソッドの実装で、IDisposableにラップされるアクションデリゲートを返します */;

            // public static IObservable<TResult> Create<TResult>(Func<IObserver<TResult>,IDisposable> subscribe)
            var observable2 = Observable.Create<int>(observer =>
                                                         {
                                                             observer.OnNext(10);
                                                             observer.OnCompleted();
                                                             //observer.OnError();
                                                             return System.Reactive.Disposables.Disposable.Empty;
                                                         });

            // ★わざわざ Observer.Create を使用してObserver(観測者)を作るのは面倒

            // このSubscribeは System.ObservableExtensions.cs Observable<T>の拡張メソッド
            // ここでSubscribeの引数としてデリゲート(メソッドの処理内容)を渡すと、内部でObserver(観測者)を自動生成する

            // ここでonNext,onCompletedの処理を記述
            observable.Subscribe(Console.WriteLine /*x => Console.WriteLine(x)*/,
                                 () => Console.WriteLine("完了"));

            // ここでonNext,onErrorの処理を記述
            observable.Subscribe(Console.WriteLine /*x => Console.WriteLine(x)*/,
                                 e => Console.WriteLine(e.Message));
        }
    }
}