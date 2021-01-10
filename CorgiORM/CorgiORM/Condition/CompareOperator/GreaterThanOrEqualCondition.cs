using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorgiORM
{
    class GreaterThanOrEqual : Compare
    {
        public GreaterThanOrEqual(string a, Object b, string aggFunc = "") : base(a, b, aggFunc)
        {

        }
        public override string getCompareOperator()
        {
            return ">=";
        }
    }
}
