using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorgiORM
{
    abstract class ParserDB
    {
        public abstract string ParseValue(Object obj, Type type);
        public abstract string ParseInsertQuery(string table, Dictionary<string, string> values);
        public abstract string ParseDeleteQuery(string table, string condition);
        public abstract string ParseUpdateQuery(string table, Dictionary<string, string> setValues, string condtion);
        public abstract string ParseSelectQuery(string table, string projections, string condition, string groupBy = "", string having = "", string orderBy = "");
    }
}
