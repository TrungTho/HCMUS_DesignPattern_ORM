using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorgiORM
{
    class InsertQuery : ExecuteQuery
    {
        private Dictionary<string, Object> values;
        public InsertQuery(string tableName, ConfigDB configDB, ParserDB parserDB, 
        Dictionary<string, string> attributeList, Dictionary<string, Object> values) 
        : base(tableName, configDB, parserDB, attributeList)
        {
            this.values = values;
        }

        public override int Execute()
        {
            Dictionary<string, string> valuesMap = new Dictionary<string, string>();
            foreach (KeyValuePair<string, Object> keyValuePair in values)
            {
                string parsed = parserDB.ParseValue(keyValuePair.Value, keyValuePair.Value.GetType());
                valuesMap.Add(this.attributeList[keyValuePair.Key], parsed);
            }

            return configDB.Insert(this.parserDB.ParseInsertQuery(this.table, valuesMap));
        }
    }
}
