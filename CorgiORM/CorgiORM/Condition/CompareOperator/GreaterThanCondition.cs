using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorgiORM
{
    class GreaterThan : Compare
    {
        public GreaterThan(string a, Object b, string aggFunc = "") : base(a, b, aggFunc)
        {

        }
        public override string getCompareOperator()
        {
            return ">";
        }
    }
}
