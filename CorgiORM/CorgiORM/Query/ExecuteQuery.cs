using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorgiORM
{
    abstract class ExecuteQuery
    {
        protected string table;
        protected ConfigDB configDB;
        protected ParserDB parserDB;
        protected Dictionary<string, string> attributeList;
        public abstract int Execute();
        protected ExecuteQuery(string table, ConfigDB configDB, ParserDB parserDB, Dictionary<string, string> attributeList)
        {
            this.table = table;
            this.configDB = configDB;
            this.parserDB = parserDB;
            this.attributeList = attributeList;
        }
    }
}
