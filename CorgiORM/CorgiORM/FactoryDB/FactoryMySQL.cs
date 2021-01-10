using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorgiORM
{
    class FactoryMySQL : FactoryDB
    {
        public ConfigDB CreateConnection(string hostname, int port, string database, string username, string password)
        {
            return new ConfigMySQL(hostname, port, database, username, password);
        }

        public ParserDB CreateParser()
        {
            return new ParserMySQL();
        }
    }
}
