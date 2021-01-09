using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorgiORM
{
    class AndCondition : Connector
    {
        public AndCondition(Condition left, Condition right)
        {
            conditions = new List<Condition>();
            conditions.Add(left);
            conditions.Add(right);
        }
        public AndCondition()
        {
            conditions = new List<Condition>();
        }
        public AndCondition(List<Condition> conditions)
        {
            this.conditions = conditions;
        }
        public override string getLogic()
        {
            return "AND";
        }
    }
}
