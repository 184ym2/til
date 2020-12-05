using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CsharpRxSample
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            var so = new SimpleObservable();
            so.ObservableRange();
            so.ObservableRange_Simple();
            so.ObservableCreate();        }
    }
}
