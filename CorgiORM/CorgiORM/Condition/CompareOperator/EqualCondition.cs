using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorgiORM
{
    class Equal : Compare
    {
        public Equal(string a, Object b, string aggregateType = "") : base(a, b, aggregateType)
        {

        }
        public override string getCompareOperator()
        {
            return "=";
        }
    }
}
