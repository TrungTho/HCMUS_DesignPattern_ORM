using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorgiORM
{
    class InsertQuery : ExecuteQuery
    {
        private Dictionary<string, Object> valuesInsert;
        public InsertQuery(string table, ConfigDB configDB, ParserDB parserDB, 
        Dictionary<string, string> attributeList, Dictionary<string, Object> values) : base(table, configDB, parserDB, attributeList)
        {
            this.valuesInsert = values;
        }

        public override int Execute()
        {
            Dictionary<string, string> valuesMap = new Dictionary<string, string>();
            foreach (KeyValuePair<string, Object> data in valuesInsert)
            {
                string value = parserDB.ParseDataToTableValue(data.Value, data.Value.GetType());
                valuesMap.Add(this.attributeList[data.Key], value);
            }

            return configDB.Insert(this.parserDB.ParseDataToInsertQuery(this.table, valuesMap));
        }
    }
}
