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

            /* string server = "localhost";
             string database = "web_caroonline";
             string uid = "root";
             string password = "";
             connectionString = "SERVER=" + server + ";" + "DATABASE=" +
             database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
             con = new OleDbConnection(connectionString);*/
            /*connectionString = "Server=localhost\\SqlExpress;" +
                            "Database=MyCompany;" +
                            "Trusted_Connection=yes;" +
                            "Provider=SQLOLEDB";*/
            connectionString = "Provider=PostgreSQL OLE DB Provider;Data Source=localhost;" +
                "location=DB_WinterShop;User ID=postgres;password=data123;timeout=1000;";
            con = new OleDbConnection(connectionString);

            con.Open();
            Console.WriteLine("Connected");

            string queryStr = "SELECT * FROM public.'User' ORDER BY id ASC";
            OleDbDataAdapter adapter = new OleDbDataAdapter(queryStr, con);

            DataSet tables = new DataSet();
            adapter.Fill(tables, "User");

            List<User> rows = new List<User>();
            User item = new User();

            rows = Mapper.MapDataWithList<User>(tables);
            item = Mapper.MapDataWithObject<User>(tables.Tables[0].Rows[0]);

            foreach (var row in rows) {
                Console.WriteLine("ID:" + row.id
                + ", fullname: " + row.name
                + ", email: " + row.email
                + ", password: " + row.password
                + ", avatar: " + row.avatar);
            }

            /*foreach (var row in rows) {
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
            foreach (var row in rows) {
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
