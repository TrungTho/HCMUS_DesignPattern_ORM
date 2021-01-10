using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data.OleDb;
using System.Diagnostics;
using System.Data;

namespace CorgiORM
{
    class Program
    {
        /// <summary>
        /// Entity class - Contains data only
        /// 
        /// </summary>
        class Customer
        {
            public int ID { get; set; }
            public string Fullname { get; set; }
            public string Tel { get; set; }

            public override string ToString()
            {
                return $"{ID} - {Fullname} - {Tel}";
            }

            public Customer(int id, string name, string tel)
            {
                this.ID = id;
                this.Fullname= name;
                this.Tel = tel;
            }
        }

        static void Main(string[] args)
        {

            // Ket qua cua viec doc du lieu
            var listOfCustomer = new List<Customer>();

            // Buoc 1: Mo ket noi
            var connectionString = "Server=localhost\\SqlExpress;Database=MyCompany; Trusted_connection=yes";
            var connection = new SqlConnection(connectionString);
            try
            {
                var tableName = "customer";
                string queryStr = $"select * from {tableName}";

                var adapter = new SqlDataAdapter(queryStr, connection);
                var builder = new SqlCommandBuilder(adapter);

                var data = new DataSet();

                adapter.Fill(data, tableName);

                //Console.WriteLine(data.Tables.);

                List<Customer> listCustomer = new List<Customer>();

                for (var i = 0; i < data.Tables[tableName].Rows.Count; i++) 
                {
                    var row = data.Tables[tableName].Rows[i];

                    //mapping
                    Customer customer = new Customer(
                        (int)row[0],
                        (string)row[1],
                        (string)row[2]);

                    listCustomer.Add(customer);
                }

                Console.WriteLine("------------------------");
                foreach (var datum in listCustomer)
                    Console.WriteLine(datum.ToString());

                Console.ReadKey();

            }
            catch (Exception e)
            {

                Debug.WriteLine(e);
            }
        }

        void doSomething<T>(T hehe)
        {
            Console.WriteLine(hehe);
        }
    }
}