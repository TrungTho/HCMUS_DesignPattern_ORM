using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data;

namespace CorgiORM {
    class Mapping {

        public Mapping() {
            ConnectDB();
        }

        public void ConnectDB() {
            string connectionString;
            OleDbConnection con;

            connectionString = "Server=localhost\\SqlExpress;" +
                "Database=MyCompany;" +
                "Trusted_Connection=yes;" +
                "Provider=SQLOLEDB";

            try {
                con = new OleDbConnection(connectionString);
                con.Open();
                Console.WriteLine("Connected");
                GetTableSchema(con);
            } catch (Exception err) {
                Console.WriteLine("An error occured: " + err);
            }
        }

        public void GetTableSchema(OleDbConnection con) {
            DataTable table = con.GetSchema("Tables");

            foreach (System.Data.DataRow row in table.Rows) {
                foreach (System.Data.DataColumn col in table.Columns) {
                    Console.WriteLine("{0} = {1}", col.ColumnName, row[col]);
                }
                Console.WriteLine("==============");
            }
        }
    }
}
