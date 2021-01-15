using System;
using System.Collections.Generic;
using System.Text;

namespace CorgiORM
{
    public abstract class Condition
    {
        public abstract string parseDataToString(Dictionary<string, string> attributeList, string table);

        public static Equal Equal(string a, Object b, string aggregate = "")
        {
            return new Equal(a, b, aggregate);
        }
        public static GreaterThan GreaterThan(string a, Object b, string aggregate = "")
        {
            return new GreaterThan(a, b, aggregate);
        }
        public static GreaterThanOrEqual GreaterThanOrEqual(string a, Object b, string aggregate = "")
        {
            return new GreaterThanOrEqual(a, b, aggregate);
        }
        public static LessThan LessThan(string a, Object b, string aggregate = "")
        {
            return new LessThan(a, b, aggregate);
        }
        public static LessThanOrEqualCondition LessThanOrEqual(string a, Object b, string aggregate = "")
        {
            return new LessThanOrEqualCondition(a, b, aggregate);
        }
        public static Like Like(string a, Object b, string aggregate = "")
        {
            return new Like(a, b, aggregate);
        }
        public static AndCondition And(Condition a, Condition b)
        {
            return new AndCondition(a, b);
        }
        public static AndCondition And()
        {
            return new AndCondition();
        }
        public static OrCondition Or(Condition a, Condition b)
        {
            return new OrCondition(a, b);
        }
        public static OrCondition Or()
        {
            return new OrCondition();
        }

    }
}
