using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorgiORM
{
    class FactoryMySQL : FactoryDB
    {
        public ConfigDB CreateConnection(string hostname, int port, string dbName, string username, string password)
        {
            return new ConfigMySQL(hostname, port, dbName, username, password);
        }

        public ParserDB CreateParser()
        {
            return new ParserMySQL();
        }
    }
}
