using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorgiORM
{
    class UpdateQuery : ExecuteQuery
    {
        private Dictionary<string, Object> newValues = new Dictionary<string, Object>();

        private OrCondition condition = new OrCondition();
        public UpdateQuery
        (string table, ConfigDB configDB, ParserDB parserDB, 
        Dictionary<string, string> attributeList, Dictionary<string, Object> newValues, Condition condition)
        : base(table, configDB, parserDB, attributeList)
        {
            this.newValues = newValues;
            this.condition.Add(condition);
        }
        public UpdateQuery(string table, ConfigDB configDB, 
        ParserDB parserDB, Dictionary<string, string> attributeList) : base(table, configDB, parserDB, attributeList) { }
        public UpdateQuery Where(Condition condition)
        {
            this.condition.Add(condition);
            return this;
        }
        public UpdateQuery Set(string attribute, Object value)
        {
            this.newValues.Add(this.attributeList[attribute], value);
            return this;
        }
        public override int Execute()
        {
            if (newValues.Count == 0)
            {
                throw new Exception("There is nothing to update");
            }
            string conditionStr = condition.toSQL(attributeList, table);
            if (conditionStr.Length == 0)
            {
                throw new Exception("Update condition is not specified");
            }
            Dictionary<string, string> values = new Dictionary<string, string>();
            foreach (string key in this.newValues.Keys)
            {
                Object value = this.newValues[key];
                values.Add(key, parserDB.ParseValue(value, value.GetType()));
            }
            string query = parserDB.ParseUpdateQuery(this.table, values, conditionStr);

            return configDB.Update(query);
        }
    }
}
