using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpDelegateCastSample
{
    internal class DelegateSampleEx
    {
        public void DelegateSample1()
        {
            var result = ((Func<int, int, int, string>) ((stock, quantity, costprice) =>
                                                             {
                                                                 var sales = stock*quantity; //売上高
                                                                 var costofsales = costprice*quantity; //売上原価
                                                                 return string.Format("粗利は ({0}-{1}) で求めることができます：{2}", sales, costofsales, sales - costofsales);
                                                             }))(1500, 5, 1000);
            Console.WriteLine(result);
            Console.ReadKey();
        }

        public void DelegateSample2()
        {
            var result = ((Func<decimal, decimal, int, string>) ((stock, quantity, costprice) =>
                                                                     {
                                                                         var sales = stock*quantity; //売上高
                                                                         var costofsales = costprice*quantity; //売上原価
                                                                         var grossprofitmargin = (sales - costofsales)/sales*100; //粗利率
                                                                         return string.Format("粗利率は ({0}-{1})/{0}*100 で求めることができます：{2}", sales, costofsales, grossprofitmargin);
                                                                     }))(1500, 5, 1000);
            Console.WriteLine(result);
            Console.ReadKey();
        }

        public void DelegateSample3()
        {
            var result = ((Func<DateTime, string>) (today =>
                                                        {
                                                            var lastweek = today.AddDays(-7);
                                                            return string.Format("{0}から一週間前の日時は{1}です", today.ToShortDateString(), lastweek.ToShortDateString());
                                                        }))(DateTime.Today);
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}