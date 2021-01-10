using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorgiORM
{
    abstract class ParserDB
    {
        public abstract string ParseDataToTableValue(Object obj, Type type);
        public abstract string ParseDataToInsertQuery(string table, Dictionary<string, string> values);
        public abstract string ParseDataToDeleteQuery(string table, string condition);
        public abstract string ParseDataToUpdateQuery(string table, Dictionary<string, string> valuesUpdate, string condition);
        public abstract string ParseDataToSelectQuery(string table, string projections, string condition, string groupBy = "", string having = "", string orderBy = "");
    }
}
