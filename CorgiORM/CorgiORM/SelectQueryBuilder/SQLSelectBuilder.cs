using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CorgiORM.Model;

namespace CorgiORM
{
        class SQLSelectBuilder<T> : ISelectQueryBuilder where T : class, new()
        {
            private string groupByCondition;
            private string orderByCondition;
            private string tableName;
            private OrCondition condition = new OrCondition();
            private OrCondition havingCondition = new OrCondition();
            private Dictionary<string, string> attributeList;
            
            private Dictionary<string,string> getAttributeList()
            {
            
            Dictionary<string, string> attributeList = new Dictionary<string, string>();

                PropertyInfo[] propertyInfo = typeof(T).GetProperties();

                foreach (PropertyInfo pInfo in propertyInfo)
                {
                    object[] customAttr = pInfo.GetCustomAttributes(typeof(DataNamesAttribute), true);
                
                    if (customAttr.Length > 0)
                    {
                        //Console.WriteLine(pInfo.GetCustomAttribute<DataNamesAttribute>().ValueNames);
                       attributeList.Add(pInfo.Name, pInfo.GetCustomAttribute<DataNamesAttribute>().ValueNames);
                    }
                //attributeList.Add(pInfo.Name, pInfo.GetCustomAttribute<Column>().columnName);
                }
                return attributeList;
            }
            
            public SQLSelectBuilder()
            {
                this.tableName = AttributeHelper.GetTableName<T>();
            this.attributeList = getAttributeList();
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
                string orderByFormat = "";
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
                
                if(orderByCondition != null)
                {
                    orderByFormat = getValidStr(orderByCondition);
                }
                return $"select * from {tableName}" +
                $" {whereFormat} " +
                $" {groupByFormat} " +
                $"{havingFormat} " +
                $"{orderByFormat}";
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
