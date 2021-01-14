using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace CorgiORM.Model {
    public class Mapper {

        Mapper() {
            run();
        }

        public void run() {
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

            res = transform<Customer>




        }

        public List<T> transform<T>(DataSet data, string DBName) where T : new() {


            DataNamesMapper<T> mapper = new DataNamesMapper<T>();

            mapper.GetTableSchema(data, DBName);
        }

        /*public Mapper() {
            ConnectDB();
        }

        public void ConnectDB(List<T> res) {
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

                string queryStr = "SELECT * FROM [MyCompany].[dbo].[Customer]";
                OleDbDataAdapter adapter = new OleDbDataAdapter(queryStr, con);

                DataSet customersTable = new DataSet();
                adapter.Fill(customersTable, "Customer");

                string DBName = "Customer";

                List<TEntity> a = new List<TEntity>();

                List<TEntity> res = DataNamesMapper<TEntity>.GetTableSchema(customersTable, "Customer");
            }
            catch (Exception err) {
                Console.WriteLine("An error occured: " + err);
            }
        }

        public void GetTableSchema<TEntity>(DataSet data, string DBName) {
            *//*string queryStr = "SELECT * FROM [MyCompany].[dbo].[Customer]";
            OleDbDataAdapter adapter = new OleDbDataAdapter(queryStr, con);

            DataSet customersTable = new DataSet();
            adapter.Fill(customersTable, "Customer");

            string DBName = "Customer";*/

        /*IEnumerable<TEntity> customers = null;

        DataNamesMapper<TEntity> mapper = new DataNamesMapper<TEntity>();
        foreach (DataTable table in data.Tables) {
            if (table.TableName == DBName) {
                customers = (List<TEntity>)mapper.Map(table);
            }
        }

        return customers;*/

        /*foreach (var customer in customers) {
            Console.WriteLine("ID:" + customer.ID
                + ", fullname: " + customer.Fullname
                + ", telephone: " + customer.tel);
        }*//*
    }*/
    }
}
