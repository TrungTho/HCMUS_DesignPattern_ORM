using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorgiORM
{
    abstract class Connector : Condition
    {
        protected List<Condition> conditions;

        public abstract string getLogic();
        public override string toSQL(Dictionary<string, string> attributeList, string tablee)
        {
            string opt = getLogic();
            if (conditions.Count == 0)
            {
                return "";
            }
            string res = conditions[0].toSQL(attributeList, tablee);
            for (int i = 1; i < conditions.Count; i++)
            {
                res += " " + opt + " " + conditions[i].toSQL(attributeList, tablee);
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
