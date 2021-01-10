using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorgiORM
{
    class Not:Condition
    {
        protected Condition condition;
        public Not(Condition condition)
        {
            this.condition = condition;
        }
        public override string toSQL(Dictionary<string, string> attributeList, string table)
        {
            return "(NOT " + condition.toSQL(attributeList, table) + ")";
        }
    }
}
