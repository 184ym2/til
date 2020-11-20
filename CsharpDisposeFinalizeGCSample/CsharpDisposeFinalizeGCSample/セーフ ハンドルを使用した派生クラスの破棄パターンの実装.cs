using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Win32.SafeHandles;

namespace CsharpDisposeFinalizeGCSample
{
    /// <summary>
    /// 次の例は、セーフ ハンドルを使用してアンマネージ リソースをカプセル化する、基底クラス DisposableStreamResource での Dispose パターンを示します。 
    /// 例では、DisposableStreamResource を使用して、開いているファイルを表す SafeFileHandle オブジェクトをラップする Stream クラスを定義しています。 
    /// このクラスには、ファイル ストリームの合計バイト数を返す Size プロパティも含まれています。
    /// </summary>
    public class セーフ_ハンドルを使用した派生クラスの破棄パターンの実装 : セーフ_ハンドルを使用した破棄パターンの実装
    {
        // 追加の定数を定義します
        protected const uint GENERIC_WRITE = 0x40000000;
        protected const uint OPEN_ALWAYS = 4; // 常に開いている

        // 追加のAPIを定義します
        /// <summary>
        /// 書き込みファイル
        /// </summary>
        [DllImport("kernel32.dll")]
        protected static extern bool WriteFile(
            SafeFileHandle safeHandle, string lpBuffer,
            int nNumberOfBytesToWrite, out int lpNumberOfBytesWritten,
            IntPtr lpOverlapped);

        // 冗長(述べ方が長たらしく、むだのあること)呼び出しを検出する
        private bool _disposed = false;
        private bool _created = false;
        private SafeFileHandle _safeHandle;
        private readonly string _fileName;

        public セーフ_ハンドルを使用した派生クラスの破棄パターンの実装(string fileName) : base(fileName)
        {
            _fileName = fileName;
        }

        /// <summary>
        /// ファイル情報の書き込み
        /// </summary>
        public void WriteFileInfo()
        {
            if (!_created)
            {
                _safeHandle = CreateFile(@".\FileInfo.txt", GENERIC_WRITE, 0, IntPtr.Zero,
                                         OPEN_ALWAYS, FILE_ATTRIBUTE_NORMAL, IntPtr.Zero);

                _created = true;
            }
            
            var output = string.Format("{0}: {1}:N0 bytes\n", _fileName, Size);

            var sss = 0;

            var boool = WriteFile(_safeHandle, output, output.Length, out sss, IntPtr.Zero);
        }

        protected override void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            // ここでマネージリソースを廃棄します
            if (disposing)
            {
                // マネージリソースを廃棄します
                _safeHandle.Dispose();
            }

            // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
            // TODO: set large fields to null.

            _disposed = true;

            // 基底クラスの実装を呼び出す
            base.Dispose(disposing);
        }
    }
}