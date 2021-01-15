using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorgiORM
{
    public abstract class Compare : Condition
    {
        protected string column { get; set; }
        protected Object value { get; set; }
        protected string aggregate { get; set; }
        public abstract string getCompareOperator();
        public Compare(string column, Object value, string aggregateType)
        {
            this.column = column;
            this.value = value;
            this.aggregate = aggregateType;
        }
        public string parseValue(Object data)
        {
            if (data.GetType() == typeof(string))
            {
                return "\"" + data.ToString() + "\"";
            }
            else if (data.GetType() == typeof(DateTime))
            {
                return "\"" + ((DateTime)data).ToString("yyyy-MM-dd HH:mm:ss") + "\"";
            }
            return data.ToString();
        }
        public override string parseDataToString(Dictionary<string, string> attributeList, string table)
        {
            if (!attributeList.ContainsKey(column))
            {
                throw new Exception("No \"" + column + "\" attribute");
            }
            string attribute = attributeList[column];
            attribute = table + "." + attribute;
            if (aggregate.Length != 0)
            {
                attribute = aggregate + "(" + attribute + ")";
            }
            return attribute + getCompareOperator() + parseValue(value);
        }
    }
}
