using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpDelegateCastSample
{
    internal class DelegateCast
    {
        public void resultに値を直接セットする()
        {
            var result = string.Format("現在時刻は：{0} です({1})", DateTime.Now.ToShortDateString(), DateTime.Now.DayOfWeek);
            Console.WriteLine(result);
            Console.ReadKey();
        }

        /// <summary>
        /// 1. ()();の実行結果をresultにセット = ((Func[string])⚠Cast⚠(ラムダ式()=>{})();
        /// </summary>
        /// <returns></returns>
        public void DelegateCast1()
        {
            var result = ((Func<string>) (() =>
                                              {
                                                  var date = DateTime.Now.ToShortDateString(); //日付
                                                  var dayOfWeek = DateTime.Now.DayOfWeek; //曜日
                                                  return string.Format("現在時刻は：{0} です({1})", date, dayOfWeek);
                                              }))();
            Console.WriteLine(result);
            Console.ReadKey();
        }

        /// <summary>
        /// 1. func = ((Func[string])⚠Cast⚠(ラムダ式()=>{});
        /// 2. func();の実行結果をresultにセット
        /// </summary>
        /// <returns></returns>
        public void DelegateCast2()
        {
            /*double型10.00123をint型に変換*/
            var i = (int) 10.00123;

            /*ラムダ式をFunc<string>に変換*/
            var func = (Func<string>) (() =>
                                           {
                                               var date = DateTime.Now.ToShortDateString(); //日付
                                               var dayOfWeek = DateTime.Now.DayOfWeek; //曜日
                                               return string.Format("現在時刻は：{0} です({1})", date, dayOfWeek);
                                           });
            var result = func();
            Console.WriteLine(result);
            Console.ReadKey();
        }

        /// <summary>
        /// 1. inFunc = ラムダ式()=>{};
        /// 2. inFunc();の実行結果をresultにセット
        /// </summary>
        /// <returns></returns>
        public void DelegateCast3()
        {
            Func<string> inFunc = () =>
                                      {
                                          var date = DateTime.Now.ToShortDateString(); //日付
                                          var dayOfWeek = DateTime.Now.DayOfWeek; //曜日
                                          return string.Format("現在時刻は：{0} です({1})", date, dayOfWeek);
                                      };
            var result = inFunc();
            Console.WriteLine(result);
            Console.ReadKey();
        }

        /// <summary>
        /// 現在日時を取得
        /// </summary>
        /// <returns></returns>
        public string currenttimeanddate()
        {
            var date = DateTime.Now.ToShortDateString(); //日付
            var dayOfWeek = DateTime.Now.DayOfWeek; //曜日
            return string.Format("現在時刻は：{0} です({1})", date, dayOfWeek);
        }

        /// <summary>
        /// 1. inFunc = 現在日時;
        /// 2. inFunc();の実行結果をresultにセット
        /// </summary>
        /// <returns></returns>
        public void DelegateCast4()
        {
            Func<string> inFunc = currenttimeanddate;
            var result = inFunc();
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}