using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorgiORM
{
    class UpdateQuery : ExecuteQuery
    {
        private Dictionary<string, Object> valuesUpdate = new Dictionary<string, Object>();

        private OrCondition orCondition = new OrCondition();
        public UpdateQuery(string table, ConfigDB configDB,
        ParserDB parserDB, Dictionary<string, string> attributeList) : base(table, configDB, parserDB, attributeList) { }
        public UpdateQuery
        (string table, ConfigDB configDB, ParserDB parserDB, 
        Dictionary<string, string> attributeList, Dictionary<string, Object> valuesUpdate, Condition condition) : base(table, configDB, parserDB, attributeList)
        {
            this.valuesUpdate = valuesUpdate;
            this.orCondition.Add(condition);
        }
        public UpdateQuery Set(string attribute, Object value)
        {
            this.valuesUpdate.Add(this.attributeList[attribute], value);
            return this;
        }
        public UpdateQuery Where(Condition condition)
        {
            this.orCondition.Add(condition);
            return this;
        }
        public override int Execute()
        {
            if (valuesUpdate.Count == 0)
            {
                Console.WriteLine("No data udpate!!");
                throw new Exception("No data update!!");
            }

            Dictionary<string, string> values = new Dictionary<string, string>();
            foreach (string key in this.valuesUpdate.Keys)
            {
                Object value = this.valuesUpdate[key];
                values.Add(key, parserDB.ParseDataToTableValue(value, value.GetType()));
            }

            string conditionUpdate = orCondition.parseDataToString(attributeList, table);
            string query = parserDB.ParseDataToUpdateQuery(this.table, values, conditionUpdate);

            return configDB.Update(query);
        }
    }
}
