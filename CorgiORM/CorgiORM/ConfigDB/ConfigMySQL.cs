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
        public ConfigMySQL(string hostname, int port, string database, string username, string password)
        {
            try
            {
                ConnectDB(hostname, port, database, username, password);
                Console.WriteLine("Connect Successfully");
            }
            catch
            {
                Console.WriteLine("Connect Failed");
            }
        }
        public override void ConnectDB(string hostname, int port, string database, string username, string password)
        {
            String connectionString = GetConnectionStringMySQL(hostname,port,database,username,password);
            Console.WriteLine(connectionString);
            connection = new MySqlConnection(connectionString);
            connection.Open();
        }

        public override void Disconnect()
        {
            connection.Close();
        }

        public String GetConnectionStringMySQL(string hostname, int port, string database, string username, string password)
        {
            String connection = "Server=" + hostname+ ";port=" + port + ";Database=" + database + ";User Id=" + username + ";password=" + password;
            return connection;
        }
        private int ExcecuteQuery(string query)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = query;
            command.Connection = connection;
            int effectRow = command.ExecuteNonQuery();
            return effectRow;
        }

        public override List<List<string>> Select(string query)
        {
            MySqlCommand command = new MySqlCommand();
            command.Connection = connection;
            command.CommandText = query;
            using (DbDataReader dataReader = command.ExecuteReader())
            {
                List<List<string>> result = new List<List<string>>();

                List<string> firstRow = new List<string>();

                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    firstRow.Add(dataReader.GetName(i).ToLower());
                }

                result.Add(firstRow);

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        List<string> row = new List<string>();
                        for (int i = 0; i < dataReader.FieldCount; i++)
                        {
                            row.Add(dataReader.GetString(i));
                        }
                        result.Add(row);
                    }
                }
                return result;
            }
        }

        public override int Insert(string query)
        {
            return ExcecuteQuery(query);
        }

        public override int Delete(string query)
        {
            return ExcecuteQuery(query);
        }

        public override int Update(string query)
        {
            return ExcecuteQuery(query);
        }
    }
}
