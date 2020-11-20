using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;

namespace DapperCollection
{
    public static partial class SqlCommandDefinition
    {
        /// <summary>
        /// SQL文
        /// </summary>
        private static string _commandtext = "SELECT * FROM Person.Person WHERE BusinessEntityID >= @ID_S AND BusinessEntityID <= @ID_E";
    }

    public static partial class SqlCommandDefinition
    {
        public static string Commandtext { get { return _commandtext; } }

        public static CommandDefinition CommandDefinition = new CommandDefinition(Commandtext, new
                                                                                               {
                                                                                                   @ID_S = 1,
                                                                                                   @ID_E = 10
                                                                                               });
    }
}