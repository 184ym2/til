using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CsharpDelegateEventSample_1
{
    /// <summary>
    /// CustomEventArgs_Tを継承したクラス
    /// </summary>
    public class Succession : CustomEventArgs_T
    {
        /// <summary>
        /// CustomEventArgs_Tを継承したSuccession.csのpublicメソッドからイベントを発生させている
        /// </summary>
        public void SuccessionからOnメソッドを呼び出し()
        {
            OnEvent1(new ReturnClassEventArgs<string>
                     {
                         S1 = "Succession_OnEvent1:ReturnClass<string>_S1",
                         S2 = "Succession_OnEvent1:ReturnClass<string>_S2"
                     });

            OnEvent2(new ReturnClassEventArgs<int>
                     {
                         S1 = 10,
                         S2 = 20
                     });
        }
    }
}