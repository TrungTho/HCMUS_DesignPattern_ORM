using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorgiORM
{
    class OrCondition : Connector
    {
        public OrCondition(Condition left, Condition right)
        {
            conditions = new List<Condition>();
            conditions.Add(left);
            conditions.Add(right);
        }
        public OrCondition()
        {
            conditions = new List<Condition>();
        }
        public OrCondition(List<Condition> conditions)
        {
            this.conditions = conditions;
        }
        public override string getLogic()
        {
            return "OR";
        }
    }
}
