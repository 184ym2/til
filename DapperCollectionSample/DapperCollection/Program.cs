using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DapperCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            var qc = new QueryCollection();
            qc.Query_command();
            qc.Query_sqlobject();
        }
    }
}
