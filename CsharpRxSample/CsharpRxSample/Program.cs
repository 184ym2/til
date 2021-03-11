using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CsharpRxSample
{
    internal static class Program
    {
        private static void Main()
        {
            //var observarAndObservable = new Observar_And_Observable();
            //observarAndObservable.ObservarAndObservablel();

            //var observableOnly = new ObservableOnly();
            //observableOnly.Observable_Only();

            //var observableOnly2 = new ObservableOnly2();
            //observableOnly2.Observable_Only2();

            var s = new List<string>()
                    {
                        "A",
                        "B",
                        "C"
                    };

            var copy = s;

            s.Remove("A");

            var i = new List<int>()
                    {
                        1,
                        2,
                        3
                    };

            var copy2 = i;

            i.Remove(1);

            
        }
    }
}