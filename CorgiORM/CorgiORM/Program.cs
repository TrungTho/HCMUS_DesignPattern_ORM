using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data.OleDb;

namespace CorgiORM
{
    class Program
    {
        static void Main(string[] args)
        {
            FactoryDB fatoryMySQL= new FactoryMySQL();

            ConfigDB configMySQL = fatoryMySQL.CreateConnection("localhost", 3306, "school", "root", "123456");

            Console.ReadLine();


        }
    }
}
