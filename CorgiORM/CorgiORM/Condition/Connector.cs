using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorgiORM
{
    public abstract class Connector : Condition
    {
        protected List<Condition> conditions;

        public abstract string getLogicalOperator();
        public override string parseDataToString(Dictionary<string, string> attributeList, string table)
        {
            string logicalOperator = getLogicalOperator();
            if (conditions.Count == 0)
            {
                return "";
            }
            string res = conditions[0].parseDataToString(attributeList, table);
            for (int i = 1; i < conditions.Count; i++)
            {
                res += " " + logicalOperator + " " + conditions[i].parseDataToString(attributeList, table);
            }
            res = "(" + res + ")";

            return res;
        }
        public Condition Add(Condition condition)
        {
            this.conditions.Add(condition);
            return this;
        }
    }
}
