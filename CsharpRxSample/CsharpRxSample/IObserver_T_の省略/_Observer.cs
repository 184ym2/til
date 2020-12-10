using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpRxSample
{
    /// <summary>
    /// 汎用Obsever(観測者)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class _Observer<T> : IObserver<T>
    {
        private readonly Action onCompleted = null;
        private readonly Action<Exception> onError = null;
        private readonly Action<T> onNext = null;

        /// <summary>
        /// コンストラクタ：Obseverを生成する際に、それぞれのメソッドに対応したデリゲートを受け取る
        /// </summary>
        /// <param name="onNext">OnNextのときに呼び出されるデリゲート</param>
        /// <param name="onError">OnErrorのときに呼び出されるデリゲート</param>
        /// <param name="onCompleted">OnCompletedのときに呼び出されるデリゲート</param>
        public _Observer(Action<T> onNext, Action<Exception> onError, Action onCompleted)
        {
            this.onNext = onNext;
            this.onError = onError;
            this.onCompleted = onCompleted;
        }

        /// <summary>
        /// プロバイダーがプッシュベースの通知の送信を完了したことをオブザーバーに通知します。
        /// </summary>
        public void OnCompleted()
        {
            if (this.onCompleted != null)
                this.onCompleted(); // OnCompletedが呼ばれたら、受け取ったデリゲートを実行　例）observer.OnCompleted();
        }

        /// <summary>
        /// プロバイダーでエラー状態が発生したことをオブザーバーに通知します。
        /// </summary>
        /// <param name="error">エラーに関する追加情報を提供するオブジェクト</param>
        public void OnError(Exception error)
        {
            if (this.onError != null)
                this.onError(error); // OnErrorが呼ばれたら、受け取ったデリゲートを実行　例）observer.OnError(Exception);
        }

        /// <summary>
        /// オブザーバーに新しいデータを提供します。
        /// </summary>
        /// <param name="value">現在の通知情報</param>
        public void OnNext(T value)
        {
            if (this.onNext != null)
                this.onNext(value); // OnNextが呼ばれたら、受け取ったデリゲートを実行　例）observer.OnNext(1);
        }
    }

    internal static class ObservableHelper
    {
        /// <summary>
        /// オブザーバー(観測者)が通知を受け取ることをプロバイダー(観測対象)に通知します。
        /// </summary>
        /// <typeparam name="T">データの型</typeparam>
        /// <param name="source">対象プロバイダー</param>
        /// <param name="onNext">OnNextのときに呼び出されるデリゲート</param>
        /// <param name="onError">OnErrorのときに呼び出されるデリゲート</param>
        /// <param name="onCompleted">OnCompletedのときに呼び出されるデリゲート</param>
        /// <returns>プロバイダーが通知の送信を完了する前に、オブザーバーが通知の受信を停止できるインターフェイスへの参照</returns>
        public static IDisposable _Subscribe<T>(this IObservable<T> source, Action<T> onNext, Action<Exception> onError, Action onCompleted)
        {
            // ObservableExtensions.cs のIObservable<T>拡張メソッドも このような実装がされている
            // 1. 拡張メソッドで受け取ったデリゲートを引数として、Observer<T>(観測者)を生成 
            // 2. 生成したObserver<T>(観測者)を引数として、IObservable<T>(観測対象)の IDisposable Subscribe(IObserver<T> observer); を実行する
            return source.Subscribe(new _Observer<T>(onNext, onError, onCompleted));
        }
    }
}