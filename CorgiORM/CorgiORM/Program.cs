using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Reflection;

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

        [STAThread]
        static void Main(string[] args)
        {

            // Ket qua cua viec doc du lieu
            var listOfCustomer = new List<Customer>();

            // Buoc 1: Mo ket noi
            var connectionString = "Server=localhost\\SqlExpress;Database=MyCompany; Trusted_connection=yes";
            var connection = new SqlConnection(connectionString);
            while (false)
            {
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

            var test = new Customer(1,"OK","0.10.10.1");
            getAllValueInObject(test);
            Console.ReadKey();
        }

        static void getAllValueInObject<T>(T myObj)
        {
            Console.WriteLine(myObj.GetType());
            Console.WriteLine("Parsing...");
            foreach (PropertyInfo attri in myObj.GetType().GetProperties())
            {
                //var value = attri.GetValue() as 
                Console.WriteLine(attri.GetValue(myObj,null));
            }
        }
    }
}