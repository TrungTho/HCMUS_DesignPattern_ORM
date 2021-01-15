﻿using CorgiORM.Model;
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

            string queryStr = "SELECT * FROM [MyCompany].[dbo].[Products]";
            OleDbDataAdapter adapter = new OleDbDataAdapter(queryStr, con);

            DataSet tables = new DataSet();
            adapter.Fill(tables, "Products");

            List<Product> rows = new List<Product>();
            Product item = new Product();

            rows = Mapper.MapDataWithList<Product>(tables);
            item = Mapper.MapDataWithObject<Product>(tables.Tables[0].Rows[0]);

            foreach (var row in rows) {
                Console.WriteLine("ID:" + row.id
                + ", fullname: " + row.name
                + ", count: " + row.count
                + ", rate: " + row.rate
                + ", price: " + row.price
                + ", imported at: " + row.importAt
                + ", exported at: " + row.exportAt
                + ", checked: " + row.isChecked);
            }

            Console.WriteLine("ID:" + item.id
               + ", fullname: " + item.name
               + ", count: " + item.count
               + ", rate: " + item.rate
               + ", price: " + item.price
               + ", imported at: " + item.importAt
               + ", exported at: " + item.exportAt
               + ", checked: " + item.isChecked);

            /*foreach (var row in rows) {
                Console.WriteLine("ID:" + row.id
                + ", fullname: " + row.name
                + ", count: " + row.email
                + ", rate: " + row.tel
                + ", price: " + row.male
                + ", imported at: " + row.dob);
            }

            Console.WriteLine("ID:" + item.id
                 + ", fullname: " + item.name
                 + ", count: " + item.email
                 + ", rate: " + item.tel
                 + ", price: " + item.male
                 + ", imported at: " + item.dob);*/

            Console.ReadKey();

        }
    }
}
