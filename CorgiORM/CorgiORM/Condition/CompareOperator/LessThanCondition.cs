using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorgiORM
{
    class LessThan : Compare
    {
        public LessThan(string a, Object b, string aggFunc = "") : base(a, b, aggFunc)
        {

        }
        public override string getCompareOperator()
        {
            return "<";
        }
    }
}
