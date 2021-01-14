using CorgiORM.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace CorgiORM {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello World!");
            string connectionString;

            OleDbConnection con;

            connectionString = "Server=localhost\\SqlExpress;" +
                            "Database=MyCompany;" +
                            "Trusted_Connection=yes;" +
                            "Provider=SQLOLEDB";
            con = new OleDbConnection(connectionString);
            con.Open();
            Console.WriteLine("Connected");

            string queryStr = "SELECT * FROM [MyCompany].[dbo].[Customer]";
            OleDbDataAdapter adapter = new OleDbDataAdapter(queryStr, con);

            DataSet customersTable = new DataSet();
            adapter.Fill(customersTable, "Customer");

            string DBName = "Customer";

            List<Customer> res = new List<Customer>();
            Customer cus = new Customer();

            Mapper map = new Mapper();
            res = map.MapDataWithList<Customer>(customersTable, DBName);

            cus = map.MapDataWithObject<Customer>(customersTable.Tables[0].Rows[0]);
            foreach (var customer in res) {
                Console.WriteLine("ID:" + customer.ID
                + ", fullname: " + customer.Fullname
                + ", telephone: " + customer.tel);
            }

            Console.WriteLine("ID:" + cus.ID
                + ", fullname: " + cus.Fullname
                + ", telephone: " + cus.tel);




            Console.ReadKey();

        }
    }
}
