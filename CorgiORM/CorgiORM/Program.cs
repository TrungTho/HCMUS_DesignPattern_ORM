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

            public Customer(string name, string tel)
            {
                this.Fullname = name;
                this.Tel = tel;
            }
        }

        static public string connectionString = "Server=localhost\\SqlExpress;Database=MyCompany; Trusted_connection=yes";
        static void Main(string[] args)
        {

            // Ket qua cua viec doc du lieu
            var listOfCustomer = new List<Customer>();
            string tableName = null;

            // Buoc 1: Mo ket noi
            var connection = new SqlConnection(connectionString);
            bool kt = true;
            while (kt)
            {
                try
                {
                    tableName = "customer";
                    string queryStr = $"select * from {tableName}";

                    var adapter = new SqlDataAdapter(queryStr, connection);
                    var builder = new SqlCommandBuilder(adapter);

                    var data = new DataSet();

                    kt = false;

                    adapter.Fill(data, tableName);
                    DataTable dataTable = data.Tables[tableName];

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
                    var fieldName = dataTable.Columns;
                    Console.WriteLine($"{fieldName[0]}--{fieldName[1]}--{fieldName[2]}");
                    foreach (var datum in listCustomer)
                        Console.WriteLine(datum.ToString());

                    ///////////////////////////////////////////////////
                    //queryStr = $"update {tableName} set tel='0' where id =10";
                    //adapter = new SqlDataAdapter(queryStr, connection);
                    //builder = new SqlCommandBuilder(adapter);

                    //data = new DataSet();

                    //kt = false;

                    //adapter.Fill(data, tableName);

                    //listCustomer = new List<Customer>();

                    //for (var i = 0; i < data.Tables[tableName].Rows.Count; i++)
                    //{
                    //    var row = data.Tables[tableName].Rows[i];

                    //    //mapping
                    //    Customer customer = new Customer(
                    //        (int)row[0],
                    //        (string)row[1],
                    //        (string)row[2]);

                    //    listCustomer.Add(customer);
                    //}

                    //Console.WriteLine("------------------------");
                    //foreach (var datum in listCustomer)
                    //    Console.WriteLine(datum.ToString());

                    Console.ReadKey();

                    //var obj = new Customer(12, "OK", "0.10.10.1");
                    //foreach (PropertyInfo attri in obj.GetType().GetProperties())
                    //{

                    //}

                }
                catch (Exception e)
                {

                    Debug.WriteLine(e);
                }
            }

            //var newobj = new Customer(12, "OK","0.10.10.1");
            //CorgiInsert(newobj,tableName);
            //Console.ReadKey();
        }

        static void CorgiInsert<T>(T myObj,string tableName)
        {
            Console.WriteLine(myObj.GetType());
            Console.WriteLine("Parsing...");
            foreach (PropertyInfo attri in myObj.GetType().GetProperties())
            {
                var value = attri.GetValue(myObj, null);
                bool checkString = false;
                if (value.GetType() == typeof(string)) checkString = true;
                Console.WriteLine($"{value} ------- {value.GetType()} ---- {checkString}");
            }
        }

        


    }
}