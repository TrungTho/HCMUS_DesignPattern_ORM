using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
