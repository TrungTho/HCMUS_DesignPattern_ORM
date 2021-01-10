using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorgiORM
{
    class DeleteQuery : ExecuteQuery
    {
        OrCondition condition = new OrCondition();
        public DeleteQuery(string table, ConfigDB configDB, ParserDB parserDB, 
        Dictionary<string, string> attributeList, Condition condition) : base(table, configDB, parserDB, attributeList)
        {
            this.condition.Add(condition);
        }
        public DeleteQuery(string table, ConfigDB configDB, ParserDB parserDB, 
        Dictionary<string, string> attributeList) : base(table, configDB, parserDB, attributeList) { }
        public DeleteQuery Where(Condition condition)
        {
            this.condition.Add(condition);
            return this;
        }
        public override int Execute()
        {
            string conditionStr = condition.parseDataToString(attributeList, table);
            if (conditionStr.Length == 0)
            {
                return configDB.Delete(parserDB.ParseDataToDeleteQuery(table, ""));
            }
            return configDB.Delete(parserDB.ParseDataToDeleteQuery(table, conditionStr));
        }
    }
}
