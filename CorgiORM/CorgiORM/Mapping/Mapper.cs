using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;

namespace CorgiORM.Mapping {
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
            DataTable table = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables
                , new object[] { null, null, null, "TABLE" });
            for (int i = 0; i < table.Rows.Count; i++) {
                Console.WriteLine(table.Rows[i][2].ToString());
            }

            string queryStr = "SELECT * FROM [MyCompany].[dbo].[Customer]";
            OleDbDataAdapter adapter = new OleDbDataAdapter(queryStr, con);

            DataSet customersTable = new DataSet();
            adapter.Fill(customersTable, "Customer");
            Console.WriteLine(customersTable.Tables[0].Columns[0]);

            DataNamesMapper<Customer> mapper = new DataNamesMapper<Customer>();
            List<Customer> customers = mapper.Map(customersTable.Tables[0]).ToList();

            foreach (var customer in customers) {
                Console.WriteLine("ID:" + customer.ID
                    + ", fullname: " + customer.Fullname
                    + ", telephone: " + customer.tel);
            }
        }
    }
}
