using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorgiORM
{
    abstract class Condition
    {
        // protected bool isNot = false;
        public abstract string toSQL(Dictionary<string, string> attributeList, string table);
        /**
         USAGE
        
         * */
        public static AndCondition And(Condition a, Condition b)
        {
            return new AndCondition(a, b);
        }
        public static OrCondition Or(Condition a, Condition b)
        {
            return new OrCondition(a, b);
        }
        public static AndCondition And()
        {
            return new AndCondition();
        }
        public static OrCondition Or()
        {
            return new OrCondition();
        }
        
        public static Equal Equal(string a, Object b, string aggFunc = "")
        {
            return new Equal(a, b, aggFunc);
        }

        public static GreaterThan GreaterThan(string a, Object b, string aggFunc = "")
        {
            return new GreaterThan(a, b, aggFunc);
        }
        public static GreaterThanOrEqual GetGreaterThanOrEqual(string a, Object b, string aggFunc = "")
        {
            return new GreaterThanOrEqual(a, b, aggFunc);
        }
        public static LessThan LessThan(string a,Object b, string aggFunc = "")
        {
            return new LessThan(a, b, aggFunc);
        }
        public static LessThanOrEqualCondition LessThanOrEqual(string a, Object b,string aggFunc = "")
        {
            return new LessThanOrEqualCondition(a, b, aggFunc);
        }
        public static Like Like(string a, Object b, string aggFunc = "")
        {
            return new Like(a, b, aggFunc);
        }
    }
}
