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
       非シールド クラス(sealed 修飾子をクラスに適用すると、それ以外のクラスが、そのクラスから継承できなくなります)は、継承される可能性があるため、潜在的な基底クラスと見なす必要があります。 
       潜在的な基底クラスの破棄パターンを実装する場合、以下を用意する必要があります。
       ・★Dispose メソッドを呼び出す Dispose(bool) の実装。
       ・☆実際のクリーンアップを実行する Dispose(bool) メソッド。
       ・アンマネージ リソースをラップする SafeHandle から派生したクラス (推奨)、または、Object.Finalize メソッドのオーバーライド。
       　SafeHandle クラスにはファイナライザーが用意されているので、自分で作成する必要はありません。
    */

    #endregion

    /// <summary>
    /// セーフ ハンドルを使用して基底クラスで Dispose パターンを実装する一般的なパターン
    /// </summary>
    internal class 通常_破棄パターンの実装 : IDisposable
    {
        // フラグ: Disposeはすでに呼ばれていますか？
        private bool _disposed = false;

        // SafeHandle インスタンスをインスタンス化します
        private SafeHandle _safeHandle = new SafeFileHandle(IntPtr.Zero, true);

        // 消費者から呼び出し可能な Dispose パターンのパブリック実装
        public void Dispose()
        {
            Dispose(true); //☆
        }

        // ★Disposeパターンの保護された実装
        protected virtual void Dispose(bool disposing)
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
        }
    }

    /// <summary>
    /// Object.Finalize をオーバーライドして基底クラスで Dispose パターンを実装する一般的なパターン
    /// </summary>
    internal class 破棄パターンの実装_Finalize : IDisposable
    {
        // フラグ: Disposeはすでに呼ばれていますか？
        private bool _disposed = false;

        ~破棄パターンの実装_Finalize()
        {
            Dispose(false);
        }

        // 消費者から呼び出し可能な Dispose パターンのパブリック実装
        public void Dispose()
        {
            Dispose(true); //☆
            GC.SuppressFinalize(this); // Disposeメソッドが呼ばれた場合、ファイナライザーは不要のためここで抑制する      
        }

        // Disposeパターンの保護された実装
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                // TODO: 管理された状態（マネージリソース）を破棄します
            }

            // TODO: アンマネージリソースを解放し、以下のファイナライザをオーバーライドします
            // TODO: ラージフィールドをNULLに設定する (set large fields to null.)

            _disposed = true;
        }
    }
}