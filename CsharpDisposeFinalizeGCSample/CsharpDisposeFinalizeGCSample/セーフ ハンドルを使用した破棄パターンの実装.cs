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
    public class セーフ_ハンドルを使用した破棄パターンの実装 : IDisposable
    {
        // 定数を定義します
        protected const uint GENERIC_READ = 0x80000000;
        protected const uint FILE_SHARE_READ = 0x00000001;
        protected const uint OPEN_EXISTING = 3;
        protected const uint FILE_ATTRIBUTE_NORMAL = 0x80;
        private const int INVALID_FILE_SIZE = unchecked((int) 0xFFFFFFFF);

        // Windows API を定義します
        /// <summary>
        /// ファイルの作成
        /// </summary>
        [DllImport("kernel32.dll", EntryPoint = "CreateFileW", CharSet = CharSet.Unicode)]
        protected static extern SafeFileHandle CreateFile(
            string lpFileName, uint dwDesiredAccess,
            uint dwShareMode, IntPtr lpSecurityAttributes,
            uint dwCreationDisposition, uint dwFlagsAndAttributes,
            IntPtr hTemplateFile);

        /// <summary>
        /// ファイルサイズを取得します
        /// </summary>
        [DllImport("kernel32.dll")]
        private static extern int GetFileSize(
            SafeFileHandle hFile, out int lpFileSizeHigh);

        // ローカル変数を定義します
        private bool _disposed = false;
        private readonly SafeFileHandle _safeHandle;
        private readonly int _upperWord;

        public セーフ_ハンドルを使用した破棄パターンの実装(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentException("The fileName cannot be null or an empty string");
            }

            _safeHandle = CreateFile(fileName, GENERIC_READ, FILE_SHARE_READ, IntPtr.Zero,
                                     OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, IntPtr.Zero);

            // ファイルサイズの取得
            Size = GetFileSize(_safeHandle, out _upperWord);

            if (Size == INVALID_FILE_SIZE)
            {
                Size = -1;
            }
            else if (_upperWord > 0)
            {
                Size = (((long) _upperWord) << 32) + Size;
            }
        }

        public long Size { get; set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            // ここでマネージリソースを廃棄します
            if (disposing)
            {
                _safeHandle.Dispose();
            }

            // セーフハンドルにラップされていないアンマネージリソースはすべて廃棄します

            _disposed = true;
        }
    }
}