using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorgiORM
{
        class SQLSelectBuilder : ISelectQueryBuilder
        {
            private string whereCondition;
            private string groupByCondition;
            private string havingCondition;
            private string orderByCondition;
            private string tableName;
            private OrCondition condition = new OrCondition();
            private Dictionary<string, string> attributeList;
            
        public SQLSelectBuilder(string table,Dictionary<string,string> attributes)
            {
                this.tableName = table;
                this.attributeList = attributes;
            }
            public string getValidStr(string obj)
            {
                return obj.Substring(0, obj.Length - 1) + ")";
            }
            public string getQueryString()
            {
                if(groupByCondition == null)
                {
                    if (havingCondition != null)
                    {
                        throw new Exception("Having condition must belong to group by condition");
                    }
                }
                return $"select * from {tableName} where " +
                $"{condition.parseDataToString(attributeList,tableName)} {getValidStr(groupByCondition)} " +
                    $"{havingCondition} {orderByCondition}";
            }

            public string getValue(Object obj)
            {
                if (obj.GetType() == typeof(string))
                    return "\"" + obj.ToString() + "\"";
                else if (obj.GetType() == typeof(DateTime))
                {
                    return "\"" + ((DateTime)obj).ToString("yyyy-MM-dd HH:mm:ss") + "\"";
                }
                return obj.ToString();
            }

            public ISelectQueryBuilder GroupBy(string fieldName)
            {
                if (this.groupByCondition == null)
                {
                    this.groupByCondition = "GROUP BY(" + fieldName + " ";
                }
                else
                {
                    this.groupByCondition += "," + fieldName+" ";
                }
                return this;
            }

            public ISelectQueryBuilder Having(string condition)
            {
                if (this.havingCondition == null)
                {
                    this.havingCondition = "HAVING " + condition;
                }
                else
                {
                    this.havingCondition += " AND " + condition;
                }
                return this;
            }

            public ISelectQueryBuilder Where(Condition whereCondition)
            {
                this.condition.Add(whereCondition);
                return this;
            }

            public ISelectQueryBuilder OrderBy(string fieldName, string type)
            {
                if (this.orderByCondition == null)
                {
                    this.orderByCondition = " ORDER BY(" + fieldName + " " + type + " ";
                }
                else
                {
                    this.orderByCondition += "," + fieldName + " " + type + " ";
                }
                return this;
            }
        }
}
