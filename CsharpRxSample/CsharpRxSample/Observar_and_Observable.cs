using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;

namespace CsharpRxSample
{
    /// <summary>
    /// IObserver[T](観測者)を生成し、5個の値を発行するIObservable[T](観測対象)を生成
    /// </summary>
    internal class Observar_And_Observable
    {
        /// <summary>
        /// IDisposable Subscribe(IObserver<T> observer); の実装をしている
        /// </summary>
        /// <param name="observer"></param>
        /// <returns></returns>
        public static Action HandmadeSubscribe(IObserver<int> observer)
        {
            // ★IObservable<T>(観測対象)は自身の状態の変化に応じてこれら(OnXXXメソッド)を適切に呼び出すことが求められる
            // ★IObserver<T>(観測者)の実装ではそれに適切に応答することが求められます = OnXXXメソッド内で渡されたデリゲートを実行する

            observer.OnNext(1);
            observer.OnNext(3);
            observer.OnNext(4);
            observer.OnNext(2);
            observer.OnNext(5);
            observer.OnCompleted();

            return () => Console.WriteLine(Message.DisposeMessage);
        }

        public void ObservarAndObservablel()
        {
            Console.WriteLine("---IObservar<T>(観測者)とIObservarble<T>(観測対象)を手動で生成します---\r\n");

            #region IObservar<T>(観測者)を実装する：OnNext(T), OnError(ex), OnCompleted()の適切な実装

            // ★観測者：public static IObserver<T> Create<T>(Action<T> onNext, Action<Exception> onError, Action onCompleted);
            // 指定された OnNext、OnError、および OnCompleted アクションからオブザーバを作成します
            // 引数　：Action<T>, Action<Exception>, Action OnXXX()内で実行するデリゲート
            // 戻り値：IObservar<T> 与えられたアクションを使用して実装されたオブザーバー(観測者)オブジェクト 

            // 1. オブザーバーを生成します
            // 2. オブザーバーのコンストラクタにそれぞれのメソッドに対応したデリゲートをセットします
            // 3. セットしたデリゲートは、オブザーバーのメンバーであるOnNextメソッド/OnErrorメソッド/OnCompletedメソッド内で呼び出されます

            /* public _Observer(Action<T> onNext, Action<Exception> onError, Action onCompleted)
               {
                   this.onNext = onNext;
                   this.onError = onError;
                   this.onCompleted = onCompleted;
               }
            */

            var observer = Observer.Create<int>(
                                                // ここで受け取ったデリゲート(Action<T>)がOnNext(T)内で実行される：値が発生した
                                                x =>
                                                    {
                                                        Console.WriteLine(Message.OnNextMessage + x);
                                                        Console.ReadKey();
                                                    },

                                                // ここで受け取ったデリゲート(Action<Exception>)がOnError(Exception error)内で実行される：エラーが発生した
                                                ex =>
                                                    {
                                                        throw ex;
                                                    },

                                                // ここで受け取ったデリゲート(Action)がOnCompleted()内で実行される：正常に終了した
                                                () =>
                                                    {
                                                        Console.WriteLine(Message.OnCompletedMessage);
                                                        Console.ReadKey();
                                                    });

            #endregion

            #region IObservable<T>(観測対象)を実装する：Subscribeメソッドの適切な実装 

            // https://docs.microsoft.com/en-us/previous-versions/dotnet/reactive-extensions/hh229122(v=vs.103)
            // ★観測対象：public static IObservable<TResult> Create<TResult>(Func<IObserver<TResult>,Action> subscribe) ★Func<T, TResult>
            // 指定されたsubscribeメソッドの実装から、指定されたsubscribeで観測可能なシーケンス(Observable：観測対象)を作成します　
            // 引数　：Func<IObserver<TResult>,Action>　結果として得られる observable シーケンスの subscribe メソッドの実装で、IDisposable でラップされるアクションデリゲートを返します
            // 戻り値：IObservable<TResult>　subscribeメソッドに指定された実装を持つ観測可能なシーケンス

            // 1. オブザーバーブル(プロパイダ)を生成します
            // 2. オブザーバーブル(プロパイダ)のメンバーであるSubscribeメソッドの処理を記述します
            // ※ オブザーバーブルは自身が変化した適切なタイミングで、OnXXXメソッドを適切に呼び出すことが求められます(= Subscribeメソッドの処理)

            // 順番に値を発行して終了する観測対象(IObservable<int>)を生成する
            var observable = Observable.Create<int>(
                                                    // Observable.Create<T>の戻り値：IObservable<TResult>のメンバーであるSubscribeメソッドの処理を記述します
                                                    observerArguments => // Subscribeメソッドの引数：IObserver<TResult>
                                                        {
                                                            // ★Subscribeメソッドは自身の状態の変化に応じてOnXXXメソッドを適切に呼び出すことが求められる

                                                            observerArguments.OnNext(1);
                                                            observerArguments.OnNext(3);
                                                            observerArguments.OnNext(4);
                                                            observerArguments.OnNext(2);
                                                            observerArguments.OnNext(5);

                                                            //observer.OnError(new Exception());

                                                            observerArguments.OnCompleted();

                                                            // Subscribeメソッドの戻り値：Action　Disposeされた時に実行される処理
                                                            return () => Console.WriteLine(Message.DisposeMessage);
                                                        });

            // 上のコードと同じ：手動生成したHandmadeSubscribe()を引数が求める Func<IObserver<int>, Action> に変換
            var observable2 = Observable.Create<int>((Func<IObserver<int>, Action>) HandmadeSubscribe);

            // 上のコードと
            var observable3 = Observable.Range(1, 5);

            #endregion

            #region IObservable<T>(観測対象)のSubscribeメソッドにIObservar<T>(観測者)をセット：(= Subscribeメソッド呼び出し)

            // ★Subscribe：IDisposable Subscribe(System.IObserver<T> observer);
            // IObservable<T>.Subscribe：オブザーバーが通知を受け取ることをプロバイダーに通知します
            // 観測対象オブジェクト(Observable)に観測者オブジェクト(Observer)を登録して、観測対象が変化したときに観測者に変更を通知する

            // ★IObservable<T>(観測対象)は自身の状態の変化に応じてOnXXXメソッドを適切に呼び出すことが求められる
            // ★IObserver<T>(観測者)の実装ではそれに適切に応答することが求められる

            // Q. IObservable<T>(観測対象)Subscribeに引数を渡す(IObserver<T>またはObserverを適切に実装するためのデリゲート)とは？
            // 1. 拡張メソッドのSubscribeを呼び出すと、さらにIObservable<T>.Subscribeが呼び出される
            // 2. IObservable<T>.Subscribeで新しいObserver<T>(観測者)を生成する

            // オブザーバーブル：IObservable<T>(観測対象)が変化する(= OnXXXメソッドの呼び出し)
            // オブザーバー　　：IObserver<T>(観測者).OnXXXメソッド内で、IObservable<T>(観測対象).Subscribeで渡したデリゲートが呼び出される

            observable.Subscribe(observer);

            #endregion
        }
    }
}