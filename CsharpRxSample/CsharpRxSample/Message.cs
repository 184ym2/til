using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpRxSample
{
    static class Message
    {
        public static string OnNextMessage = "OnNext(T)が呼ばれた※値が発生した：";
        public static string OnCompletedMessage = "OnCompleted()が呼ばれた※正常に終了した";
        public static string DisposeMessage = "Disposable action";

    }
}
