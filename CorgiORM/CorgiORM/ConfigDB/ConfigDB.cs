using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorgiORM
{
    abstract class ConfigDB
    {
        public abstract void ConnectDB(string hostname, int port, string dbName, string username, string password);
        public abstract void Disconnect();
        public abstract List<List<string>> Select(string query);
        public abstract int Insert(string query);
        public abstract int Delete(string query);
    }
}
