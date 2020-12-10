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
            var observarAndObservable = new Observar_And_Observable();
            observarAndObservable.ObservarAndObservablel();

            var observableOnly = new ObservableOnly();
            observableOnly.Observable_Only();

            var observableOnly2 = new ObservableOnly2();
            observableOnly2.Observable_Only2();
        }
    }
}