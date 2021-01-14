using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorgiORM
{
        class SQLSelectBuilder : ISelectQueryBuilder
        {
            private string groupByCondition;
            private string orderByCondition;
            private string tableName;
            private OrCondition condition = new OrCondition();
            private OrCondition havingCondition = new OrCondition();
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
                string groupByFormat = "";
                string havingFormat = "";
                string whereFormat = "";
                if(condition.parseDataToString(attributeList, tableName)!="")
                {
                    whereFormat = "WHERE " + condition.parseDataToString(attributeList, tableName);
                }
                if (groupByCondition != null)
                {
                    groupByFormat = getValidStr(groupByCondition);
                    if (havingCondition.parseDataToString(attributeList, tableName) != "")
                    {
                        havingFormat = "HAVING " + havingCondition.parseDataToString(attributeList, tableName);
                    }
                }
               
                if (groupByCondition == null)
                {
                    if (havingCondition.parseDataToString(attributeList,tableName) != "")
                    {
                        throw new Exception("Having condition must belong to group by condition");
                    }
                }
                
                return $"select * from {tableName}" +
                $" {whereFormat} " +
                $" {groupByFormat} " +
                $"{havingFormat} " +
                $"{orderByCondition}";
            }

            public string getValue(Object obj)
            {
                if (obj.GetType() == typeof(string))
                    return "\"" + obj.ToString() + "\"";
                else if (obj.GetType() == typeof(DateTime))
                {
                    return "\"" + ((DateTime)obj).ToString("yyyy-MM-dd") + "\"";
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

            public ISelectQueryBuilder Having(Condition condition)
            {
                this.havingCondition.Add(condition);
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
