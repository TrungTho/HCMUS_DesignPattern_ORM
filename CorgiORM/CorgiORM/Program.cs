using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data.OleDb;
using System.Diagnostics;

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
                connection.Open();

                // Buoc 2 - Chuan bi cau truy van
                // Lay danh sach cac customer
                var sql = "SELECT * FROM Customer";

                // Buoc 3 - Thuc thi cau truy van
                var command = new SqlCommand(sql, connection);
                var reader = command.ExecuteReader();

                // Thuc hien anh xa
                while (reader.Read())
                {
                    var customer = new Customer();
                    customer.ID = (int)reader[0];
                    customer.Fullname = (string)reader[1];
                    customer.Tel = (string)reader[2];
                    listOfCustomer.Add(customer);
                }

                foreach (var x in listOfCustomer)
                    Console.WriteLine(x.ToString());

                Debug.WriteLine("Successful!!!");

                // Buoc 5: Dong ket noi
                connection.Close();
                Console.ReadKey();
            }
            catch (Exception e)
            {

                Debug.WriteLine(e);
            }
        }

    }
}