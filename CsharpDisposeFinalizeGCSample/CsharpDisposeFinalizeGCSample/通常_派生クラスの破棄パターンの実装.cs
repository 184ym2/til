using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Win32.SafeHandles;

namespace CsharpDisposeFinalizeGCSample
{

    #region 破棄パターンの実装について

    /*
       IDisposable インターフェイスを実装するクラスから派生したクラスは、IDisposable の基底クラスでの実装が派生クラスに継承されるため、
       IDisposable.Dispose を実装しないでください。 代わりに、派生クラスをクリーンアップするには、以下を用意します。
       ・★基底クラスのメソッドをオーバーライドして、派生クラスの実際のクリーンアップを実行する protected override void Dispose(bool) メソッド。
      　　 このメソッドは、基底クラスの ☆base.Dispose(bool) メソッドも呼び出して、引数の破棄状態を渡す必要があります
       ・アンマネージ リソースをラップする SafeHandle から派生したクラス (推奨)、または、Object.Finalize メソッドのオーバーライド。SafeHandle クラスにはファイナライザーが用意されているので、自分で作成する必要はありません。
       　ファイナライザーを用意する場合は、disposing 引数を false として Dispose(bool) オーバーロードを呼び出す必要があります。
    */

    #endregion

    /// <summary>
    /// セーフ ハンドルを使用して派生クラスで Dispose パターンを実装する一般的なパターン
    /// </summary>
    internal class 通常_派生クラスの破棄パターンの実装 : 通常_破棄パターンの実装
    {
        // フラグ: Disposeはすでに呼ばれていますか？
        private bool _disposed = false;

        // Instantiate a SafeHandle instance.
        private SafeHandle _safeHandle = new SafeFileHandle(IntPtr.Zero, true);

        // ★Disposeパターンの保護された実装
        protected override void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                // 管理された状態（マネージリソース）を破棄します
                _safeHandle.Dispose();
            }

            _disposed = true;

            // 基底クラスの ★Dispose(bool) を呼び出す
            base.Dispose(disposing);
        }
    }

    internal class 派生クラスの破棄パターンの実装_Finalize : 通常_破棄パターンの実装
    {
        // フラグ: Disposeはすでに呼ばれていますか？
        private bool _disposed = false;

        ~派生クラスの破棄パターンの実装_Finalize()
        {
            Dispose(false);
        }

        // ★Disposeパターンの保護された実装
        protected override void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }
            if (disposing)

            {
                // TODO:  管理された状態（マネージリソース）を破棄します
            }

            // TODO: アンマネージリソースを解放し、以下のファイナライザをオーバーライドします
            // TODO: ラージフィールドをNULLに設定する (set large fields to null.)
            _disposed = true;

            // 基底クラスの ★Dispose(bool) を呼び出す
            base.Dispose(disposing);
        }
    }
}