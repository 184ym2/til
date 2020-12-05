using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;

namespace CsharpRxSample
{
    /// <summary>
    /// 監視対象のオブジェクト(観測対象)に観測者オブジェクト(Observer)を登録して、監視対象が変化したときに観測者に変更を通知する
    /// </summary>
    internal class SimpleObservable
    {
        /// <summary>
        /// Observer(観測者)を生成し、1~5の値を出力するObservable(観測対象)を生成
        /// </summary>
        public void ObservableRange()
        {
            Console.WriteLine("---Observer(観測者)とObservarble(観測対象)を手動で生成します---\r\n");

            #region 観測者：Observar
            // 観測者：public static IObserver<T> Create<T>(Action<T> onNext, Action<Exception> onError, Action onCompleted);
            // 指定された OnNext、OnError、および OnCompleted アクションからオブザーバを作成します
            // Create<T>：観測者が受信した要素の型 戻り値：与えられたアクションを使用して実装されたオブザーバー(観測者)オブジェクト 
            var observer = Observer.Create<int>(
                                               // OnNextが起こった時に実行される動作 = 値が発生した Action<T>  
                                               x =>
                                                    {
                                                        Console.WriteLine(string.Format("値が発生した：{0}", x));
                                                        Console.ReadKey();
                                                    },
                                               // OnErrorが起こった時に実行される動作 = エラーが発生した Action<Exception>
                                               ex =>
                                                    {
                                                        throw ex;
                                                    },
                                               // OnCompletedが起こった時に実行される動作 = 正常に終了した Action
                                               () =>
                                                    {
                                                        Console.WriteLine("正常に終了しました");
                                                        Console.ReadKey();

                                                    });

            #endregion

            #region 観測対象：Observable

            // https://docs.microsoft.com/en-us/previous-versions/dotnet/reactive-extensions/hh211896(v=vs.103)
            // 観測対象：public static IObservable<int> Range(int start, int count)
            // 指定された範囲内で観測可能(オブザーバブル)な積分数列を生成します
            // 戻り値：連続する整数の範囲を含む観測可能なシーケンス
            var observable = Observable.Range(1, 5); // シーケンスの最初の整数の値, 生成する連続整数の数

            // ★IObservable<T>(観測対象)は自身の状態の変化に応じてこれら(OnXXXメソッド)を適切に呼び出すことが求められる
            // ★IObserver<T>(観測者)の実装ではそれに適切に応答することが求められます = OnXXXメソッド内で渡されたデリゲートを実行する

            #endregion

            // 今回のSubscribe：IDisposable Subscribe(System.IObserver<T> observer);
            // IObservable<T>のメンバー Subscribe：オブザーバーが通知を受け取ることをプロバイダーに通知します
            // 引数として渡されたobserver(観測対象)になんらかの現象が起こったことを通知する = observer(観測対象)にobservable(観測者)を登録する
            observable.Subscribe(observer);
        }

        /// <summary>
        /// Observer(観測者)を自動生成し、1~5の値を発行するObservable(観測対象)を生成
        /// </summary>
        public void ObservableRange_Simple()
        {
            Console.WriteLine("\r\n---Observer(観測者)は自動生成し、observable(観測対象)を手動で生成します---\r\n");
            // 観測者：★わざわざ Observer.Create を使用してObserver(観測者)を作るのは面倒

            #region 観測対象：Observable

            // https://docs.microsoft.com/en-us/previous-versions/dotnet/reactive-extensions/hh211896(v=vs.103)
            // 観測対象：public static IObservable<int> Range(int start, int count)
            var observable = Observable.Range(1, 5);

            // ★IObservable<T>(観測対象)は自身の状態の変化に応じてこれら(OnXXXメソッド)を適切に呼び出すことが求められる
            // ★IObserver<T>(観測者)の実装ではそれに適切に応答することが求められます = OnXXXメソッド内で渡されたデリゲートを実行する

            #endregion

            // 今回のSubscribe：public static IDisposable Subscribe<T>(this IObservable<T> source, Action<T> onNext, Action<Exception> onError, Action onCompleted);
            // IObservable<T>のメンバー Subscribe：オブザーバーが通知を受け取ることをプロバイダーに通知します
            // 引数として渡されたobserver(観測対象)になんらかの現象が起こったことを通知する = observer(観測対象)にobservable(観測者)を登録する
            // ★IObservable<T>のメンバーは引数なしのSubscribeだけ　ここで使用している Subscribe<T> は ObservableExtensions.cs Observable<T>の拡張メソッド

            // ここでSubscribeの引数としてデリゲート(メソッドの処理内容)を渡すと、内部でObserver<T>(観測者)を自動生成する

            /* public static IDisposable Subscribe<T>(this IObservable<T> source, Action<T> onNext, Action<Exception> onError, Action onCompleted)
            * { 
            *   return　source.Subscribe(new Observer<T>(onNext, onError, onCompleted)); 
            * }  
            */

            Observable.Range(1, 5).Subscribe(
                                             // OnNextが起こった時に実行される動作 = 値が発生した Action<T> 
                                             x =>
                                                  {
                                                      Console.WriteLine(string.Format("OnNext 値が発生した：{0}", x));
                                                      Console.ReadKey();
                                                  },
                                             // OnErrorが起こった時に実行される動作 = エラーが発生した Action<Exception>
                                             ex =>
                                                  {
                                                      throw ex;
                                                  },
                                             // OnCompletedが起こった時に実行される動作 = 正常に終了した Action
                                             () =>
                                                  {
                                                      Console.WriteLine("OnCompleted 正常に終了しました");
                                                      Console.ReadKey();

                                                  });
        }

        /// <summary>
        /// Func<IObserver<TResult>,Action> subscribe をメソッドとして実装 = IDisposable Subscribe(IObserver<T> observer); の処理を書いている
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

            return () => Console.WriteLine("Disposable action");
        }

        /// <summary>
        /// Observer(観測者)を自動生成し、1~5の値を発行するObservable(観測対象)を生成
        /// </summary>
        public void ObservableCreate()
        {
            Console.WriteLine("\r\n---Observer(観測者)は自動生成し、observable(観測対象)を手動で生成します---\r\n");
            // 観測者：★わざわざ Observer.Create を使用してObserver(観測者)を作るのは面倒

            #region 観測対象

            // https://docs.microsoft.com/en-us/previous-versions/dotnet/reactive-extensions/hh229122(v=vs.103)
            // 観測対象：public static IObservable<TResult> Create<TResult>(Func<IObserver<TResult>,Action> subscribe) ★Func<T, TResult>
            // 指定されたsubscribeメソッドの実装から、指定されたsubscribeで観測可能なシーケンス(Observable：観測対象)を作成します　

            // 引数　：Func<IObserver<TResult>,Action>　結果として得られる observable シーケンスの subscribe メソッドの実装で、IDisposable でラップされるアクションデリゲートを返します
            // 戻り値：IObservable<TResult>　subscribeメソッドに指定された実装を持つ観測可能なシーケンス

            // Funcの引数と戻り値は何を表しているのか？：結果として得られる observable シーケンスの subscribe メソッドの実装
            // ポイント：IObservable<T>を継承した Observable<T>.cs の IDisposable Subscribe(IObserver<T> observer){ ★★★★★ } の ★部分の実装をしている そのため引数の名前が[subscribe]になっている

            // 1, 2, 3, 4, 5と順番に値を発行して終了する観測対象(IObservable<int>)を生成する
            // var observable = Observable.Range(1, 5);　これと同じ
            var observable = Observable.Create<int>(observer => // 引数：IObserver<TResult>
                                                                {
                                                                    // ★IObservable<T>(観測対象)は自身の状態の変化に応じてこれら(OnXXXメソッド)を適切に呼び出すことが求められる
                                                                    // ★IObserver<T>(観測者)の実装ではそれに適切に応答することが求められます = OnXXXメソッド内で渡されたデリゲートを実行する

                                                                    observer.OnNext(1);
                                                                    observer.OnNext(3);
                                                                    observer.OnNext(4);
                                                                    observer.OnNext(2);
                                                                    observer.OnNext(5);

                                                                    //observer.OnError(Exception ex);

                                                                    observer.OnCompleted();

                                                                    // 戻り値：Action　Disposeされた時に実行される処理
                                                                    return () => Console.WriteLine("Disposable action");
                                                                });

            // 上のコードと同じ
            var observable2 = Observable.Create<int>(HandmadeSubscribe);

            #endregion

            // 今回のSubscribe：public static IDisposable Subscribe<T>(this IObservable<T> source, Action<T> onNext, Action<Exception> onError, Action onCompleted);
            // IObservable<T>のメンバー Subscribe：オブザーバーが通知を受け取ることをプロバイダーに通知します
            // 引数として渡されたobserver(観測対象)になんらかの現象が起こったことを通知する = observer(観測対象)にobservable(観測者)を登録する
            // ★IObservable<T>のメンバーは引数なしのSubscribeだけ　ここで使用している Subscribe<T> は ObservableExtensions.cs Observable<T>の拡張メソッド

            // ここでSubscribeの引数としてデリゲート(メソッドの処理内容)を渡すと、内部でObserver(観測者)を自動生成する

            /* public static IDisposable Subscribe<T>(this IObservable<T> source, Action<T> onNext, Action<Exception> onError, Action onCompleted)
             * { 
             *   return　source.Subscribe(new Observer<T>(onNext, onError, onCompleted)); 
             * }  
             */

            observable.Subscribe(
                                    // OnNextが起こった時に実行される動作 = 値が発生した Action<T> 
                                    x =>
                                    {
                                        Console.WriteLine(string.Format("OnNext 値が発生した：{0}", x));
                                        Console.ReadKey();
                                    },
                                    // OnErrorが起こった時に実行される動作 = エラーが発生した Action<Exception>
                                    ex =>
                                    {
                                        throw ex;
                                    },
                                    // OnCompletedが起こった時に実行される動作 = 正常に終了した Action
                                    () =>
                                    {
                                        Console.WriteLine("OnCompleted 正常に終了しました");
                                        Console.ReadKey();

                                    });

            

        }
    }
}