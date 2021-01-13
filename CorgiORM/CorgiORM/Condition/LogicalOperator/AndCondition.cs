using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorgiORM
{
    public class AndCondition : Connector
    {
        public AndCondition(Condition a, Condition b)
        {
            conditions = new List<Condition>();
            conditions.Add(a);
            conditions.Add(b);
        }
        public AndCondition()
        {
            conditions = new List<Condition>();
        }
        public AndCondition(List<Condition> conditions)
        {
            this.conditions = conditions;
        }
        public override string getLogicalOperator()
        {
            return "AND";
        }
    }
}
