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
            private List<string> selectCondition;
            private string groupByCondition;
            private string orderByCondition;
            private string tableName;
            //private OrCondition condition = new OrCondition();
            private AndCondition condition = new AndCondition();
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
                this.selectCondition = new List<string>();
            }
            public string getValidStr(string obj)
            {
                return obj.Substring(0, obj.Length - 1);
            }
            
            private string getListColumnSelected()
            {
                string res = ""; 
                if(this.selectCondition.Count == 0)
                {
                    res += "*";
                }
                else
                {
                    foreach(string conditionEle in selectCondition)
                    {
                    res += conditionEle + ",";
                    }
                    res = getValidStr(res);
                }
                return res;
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
                return $"select {getListColumnSelected()} from {tableName}" +
                $" {whereFormat}" +
                $" {groupByFormat}" +
                $" {havingFormat} " +
                $" {orderByFormat}";
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
                    this.groupByCondition = "GROUP BY " + fieldName + " ";
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
                    this.orderByCondition = " ORDER BY " + fieldName + " " + type + " ";
                }
                else
                {
                    this.orderByCondition += "," + fieldName + " " + type + " ";
                }
                return this;
            }

        public ISelectQueryBuilder SelectCondition(string column)
        {
            this.selectCondition.Add(column);
            return this;
        }
    }
}
