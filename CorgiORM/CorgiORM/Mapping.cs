using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data.OleDb;

namespace CorgiORM {
    class Mapping {

        public Mapping() {
            ConnectDB();
        }

        public void ConnectDB() {
            string connectionString;
            OleDbConnection cnn;

            connectionString = "Server=localhost\\SqlExpress;" +
                "Database=MyCompany;" +
                "Trusted_Connection=yes;" +
                "Provider=SQLOLEDB";
            cnn = new OleDbConnection(connectionString);
            Console.WriteLine(connectionString);
            cnn.Open();
            Console.WriteLine("Connected");
        }

    }
}
