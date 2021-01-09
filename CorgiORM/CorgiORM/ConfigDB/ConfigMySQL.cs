using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorgiORM
{
    class ConfigMySQL : ConfigDB
    {
        private MySqlConnection connection;
        public override void ConnectDB(string hostname, int port, string dbName, string username, string password)
        {
            String connectionString = GetStrConnectionMySQL(hostname,port,dbName,username,password);
            Console.WriteLine(connectionString);
            connection = new MySqlConnection(connectionString);
            connection.Open();
        }

        public override void Disconnect()
        {
            connection.Close();
        }

        public String GetStrConnectionMySQL(string hostname, int port, string dbName, string username, string password)
        {
            String connection = "Server=" + hostname+ ";port=" + port + ";Database=" + dbName + ";User Id=" + username + ";password=" + password;
            return connection;
        }

        public override List<List<string>> Select(string query)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = query;
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                int numCol = reader.FieldCount;
                List<List<string>> res = new List<List<string>>();
                List<string> firstRow = new List<string>();
                for (int j = 0; j < numCol; j++)
                {
                    firstRow.Add(reader.GetName(j).ToLower());
                }
                res.Add(firstRow);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        List<string> row = new List<string>();
                        for (int j = 0; j < numCol; j++)
                        {
                            row.Add(reader.GetString(j));
                        }
                        res.Add(row);
                    }
                }
                return res;
            }
        }

        private int ExcecuteQuery(string query)
        {
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = query;
            cmd.Connection = connection;
            int rowCount = cmd.ExecuteNonQuery();
            return rowCount;
        }

        public override int Insert(string query)
        {
            return ExcecuteQuery(query);
        }

        public ConfigMySQL(string hostname, int port, string dbName, string username, string password)
        {
            try
            {
                ConnectDB(hostname, port, dbName, username, password);
                Console.WriteLine("Connect Successfully");
            }
            catch
            {
                Console.WriteLine("Connect Failed");
            }
        }
    }
}
