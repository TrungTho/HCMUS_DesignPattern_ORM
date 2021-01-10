using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace CorgiORM.Model {
    public class Mapper {

        public Mapper() {
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
            }
            catch (Exception err) {
                Console.WriteLine("An error occured: " + err);
            }
        }

        public void GetTableSchema(OleDbConnection con) {
            string queryStr = "SELECT * FROM [MyCompany].[dbo].[Customer]";
            OleDbDataAdapter adapter = new OleDbDataAdapter(queryStr, con);

            DataSet customersTable = new DataSet();
            adapter.Fill(customersTable, "Customer");

            string DBName = "Customer";
            IEnumerable<Customer> customers = new List<Customer>();

            DataNamesMapper<Customer> mapper = new DataNamesMapper<Customer>();
            foreach (DataTable table in customersTable.Tables) {
                if (table.TableName == DBName) {
                    customers = mapper.Map(table);
                }
            }

            foreach (var customer in customers) {
                Console.WriteLine("ID:" + customer.ID
                    + ", fullname: " + customer.Fullname
                    + ", telephone: " + customer.tel);
            }
        }
    }
}
