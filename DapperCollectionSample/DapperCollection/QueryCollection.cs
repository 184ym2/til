using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;

namespace DapperCollection
{
    public class QueryCollection
    {
        /// <summary>
        /// CommandDefinitionを使用するQuery[T]
        /// </summary>
        public void Query_command()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DB情報"].ConnectionString;
            var sqlConnection = new SqlConnection(connectionString);

            sqlConnection.Open();
            var data = sqlConnection.Query<DapperData>(SqlCommandDefinition.CommandDefinition);

            Console.WriteLine("CommandDefinitionを使用するQuery[T]\n");

            foreach (var dapperData in data)
            {
                Console.WriteLine(dapperData.FirstName);
            }
            sqlConnection.Close();
            Console.ReadKey();
        }

        /// <summary>
        /// SQL文とObjectを使用するQuery[T]
        /// </summary>
        public void Query_sqlobject()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DB情報"].ConnectionString;
            var sqlConnection = new SqlConnection(connectionString);

            sqlConnection.Open();
            var data = sqlConnection.Query<DapperData>(SqlCommandDefinition.Commandtext, new
                                                                                         {
                                                                                             @ID_S = 1,
                                                                                             @ID_E = 10
                                                                                         });
            Console.WriteLine("\nSQL文とObjectを使用するQuery[T]\n");
            foreach (var dapperData in data)
            {
                Console.WriteLine(dapperData.FirstName);
            }
            sqlConnection.Close();
            Console.ReadKey();
        }
    }
}