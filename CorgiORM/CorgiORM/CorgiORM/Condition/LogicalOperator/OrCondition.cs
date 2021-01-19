using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorgiORM
{
    public class OrCondition : Connector
    {
        public OrCondition(Condition a, Condition b)
        {
            conditions = new List<Condition>();
            conditions.Add(a);
            conditions.Add(b);
        }
        public OrCondition()
        {
            conditions = new List<Condition>();
        }
        public OrCondition(List<Condition> conditions)
        {
            this.conditions = conditions;
        }
        public override string getLogicalOperator()
        {
            return "OR";
        }
    }
}
