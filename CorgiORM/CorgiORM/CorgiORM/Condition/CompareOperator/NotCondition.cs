using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorgiORM
{
     public class Not:Condition
    {
        protected Condition condition;
        public Not(Condition condition)
        {
            this.condition = condition;
        }
        public override string parseDataToString(Dictionary<string, string> attributeList, string table)
        {
            return "(NOT " + condition.parseDataToString(attributeList, table) + ")";
        }
    }
}
