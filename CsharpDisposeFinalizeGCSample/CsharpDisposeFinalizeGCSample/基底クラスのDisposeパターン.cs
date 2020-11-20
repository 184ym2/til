using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Win32.SafeHandles;

namespace CsharpDisposeFinalizeGCSample
{

    #region IDisposable および継承階層：基底クラス

    /*
       破棄可能にすべきサブクラスを持つ基底クラスは、以下のようにIDisposableを実装しなければなりません。
       封印されていない型(Visual BasicではNotInheritable)にIDisposableを実装する場合は、必ずこのパターンを使用する必要があります。

       ・★1つのパブリックな非仮想 Dispose() メソッドと☆保護された仮想 Dispose(Boolean disposing) メソッドを提供する必要があります。
       ・★Dispose() メソッドは ☆Dispose(true) を呼び出す必要があり、パフォーマンスのために終了処理を抑制する必要があります。
       ・基本型(BaseClass)はファイナライザーを含めることはできません。
     */

    #endregion

    internal class 基底クラスのDisposeパターン : IDisposable
    {
        // フラグ: Disposeはすでに呼ばれているか?
        private bool disposed = false;

        // SafeHandle インスタンスをインスタンス化します
        private SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        // ★消費者から呼び出し可能な Dispose パターンのパブリック実装
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // ☆Disposeパターンの保護された実装です
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();

                // 他のマネージリソースをここで解放します
                //
            }

            disposed = true;
        }
    }

    #region Object.Finalize メソッドをオーバーライドする場合、クラスは以下のパターンを実装する必要があります

    internal class 基底クラスのDisposeパターン2 : IDisposable
    {
        // フラグ: Disposeはすでに呼ばれていますか？
        private bool disposed = false;

        ~基底クラスのDisposeパターン2()
        {
            Dispose(false);
        }

        // ★消費者から呼び出し可能な Dispose パターンのパブリックな実装
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this); // Disposeメソッドが呼ばれた場合、ファイナライザーは不要のためここで抑制する 
        }

        // ☆Disposeパターンの保護された実装です
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // 他の管理されたオブジェクトをここで解放します
                //
            }

            // ここで管理されていないオブジェクトを解放します
            //

            disposed = true;
        }
    }

    #endregion

    #region IDisposable および継承階層：派生クラス

    /*
     　・Dispose(Boolean) をオーバーライドし、基底クラスの Dispose(Boolean) 実装を呼び出す必要があります。
     　・必要に応じてファイナライザーを提供することができます。ファイナライザーは Dispose(false) を呼び出す必要があります。
     
       派生クラスはそれ自体が IDisposable インターフェースを実装しておらず、パラメータなしの Dispose メソッドを含んでいないことに注意してください。
       派生クラスは基底クラスの Dispose(Boolean) メソッドをオーバーライドするだけです。
     */

    #endregion

    internal class DerivedClass : 基底クラスのDisposeパターン
    {
        // フラグ: Disposeはすでに呼ばれているか？
        private bool disposed = false;

        // SafeHandle インスタンスをインスタンス化します
        private SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        // Dispose パターンの保護された実装：基底クラスの Dispose(bool disposing) をオーバーライドしている
        protected override void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // 他のマネージリソースをここで解放します
                //
            }

            // ここでアンマネージリソースを解放します
            //

            disposed = true;

            // ベースクラスの Dispose(bool disposing) 実装を呼び出します
            base.Dispose(disposing);
        }
    }
}