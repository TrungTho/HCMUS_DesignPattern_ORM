using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorgiORM
{
    interface FactoryDB
    {
        ConfigDB CreateConnection(string hostname, int port, string dbName, string username, string password);
    }
}
