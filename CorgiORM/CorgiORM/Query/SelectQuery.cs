using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CorgiORM
{
    class SelectQuery<T> where T : new()
    {
        public ConfigDB ConfigDB;
        public ParserDB parser;
        public string table;

        public int ASC = 0;
        public int DESC = 1;

        public Dictionary<string, string> attributeList;
        public Dictionary<string, string> columnsReturn;
        public Dictionary<string, string> aliasColumnsReturn;
        protected Dictionary<string, int> orderBy;

        protected OrCondition condition;
        public SelectQuery() { }
        public SelectQuery(string table, ConfigDB ConfigDB, ParserDB parser, Dictionary<string, string> attributeList)
        {
            this.table = table;
            this.ConfigDB = ConfigDB;
            this.parser = parser;
            this.columnsReturn = new Dictionary<string, string>();
            this.condition = new OrCondition();
            this.attributeList = attributeList;
            this.orderBy = new Dictionary<string, int>();
            this.aliasColumnsReturn = new Dictionary<string, string>();
        }
        public SelectQuery<T> Where(Condition condition)
        {
            this.condition.Add(condition);
            return this;
        }
        public GroupByQuery<T> GroupBy(string attr)
        {
            return new GroupByQuery<T>(this).GroupBy(attr);
        }
        public SelectQuery<T> OrderBy(string attr, string order = "ASC")
        {
            if (order.Equals("ASC"))
            {
                this.orderBy.Add(attributeList[attr], ASC);
            }
            else
            {
                this.orderBy.Add(attributeList[attr], DESC);
            }
            return this;
        }
        public virtual string ConvertAttributesToString()
        {
            string attributesString = "";
            if (columnsReturn.Count == 0)
            {
                foreach (string key in attributeList.Keys)
                {
                    attributesString += table + "." + attributeList[key] + ",";
                }
                attributesString = attributesString.Substring(0, attributesString.Length - 1);
            }
            else
            {
                foreach (string projection in columnsReturn.Keys)
                {
                    int index = projection.IndexOf("(");
                    string p = projection.Substring(0, index + 1);
                    p = p + table + "." + projection.Substring(index + 1);
                    attributesString += p + " AS " + columnsReturn[projection] + ",";
                }
                attributesString = attributesString.Remove(attributesString.Length - 1, 1);
            }
            return attributesString;
        }
        public virtual string ConvertConditionToString()
        {
            return condition.parseDataToString(attributeList, table);
        }
        public virtual string ConvertOrderToString()
        {
            string orderString = "";
            if (orderBy.Count != 0)
            {
                foreach (string attr in orderBy.Keys)
                {
                    orderString += attr;
                    if (orderBy[attr] == DESC)
                    {
                        orderString += " DESC, ";
                    }
                    else
                    {
                        orderString += " ASC, ";
                    }
                }
                orderString = orderString.Remove(orderString.Length - 1, 1);
            }
            return orderString;
        }
       
        public List<Object> ConvertResultToList()
        {
            string attributeString = ConvertAttributesToString();
            string conditionString = ConvertConditionToString();
            string groupByString = ConvertGroupByToString();
            string orderString = ConvertOrderToString();
            string havingString = ConvertHavingToString();

            List<List<string>> selectResult = ConfigDB.Select(parser.ParseDataToSelectQuery(table, attributeString, conditionString, groupByString, havingString, orderString));
            
            return ParseResultToList(selectResult);
        }

        public virtual List<Object> ParseResultToList(List<List<string>> data)
        {
            List<Object> result = new List<Object>();
            Type type = typeof(T);
            if (columnsReturn.Count == 0)
            {
                foreach (string key in attributeList.Keys)
                {
                    aliasColumnsReturn.Add(attributeList[key], key);
                }
            }
           
            Dictionary<int, string> columnsList = new Dictionary<int, string>();
            
            for (int i = 0; i < data[0].Count; i++)
            {
                columnsList.Add(i, data[0][i]);
            }

            for (int i = 1; i < data.Count; i++)
            {
                Object element = new object();
                if (columnsReturn.Count == 0)
                {
                    element = new T();
                    for (int j = 0; j < data[i].Count; j++)
                    {
                        PropertyInfo propInfo = type.GetProperty(aliasColumnsReturn[columnsList[j]]);
                        Object convertObj = Convert.ChangeType(data[i][j], propInfo.PropertyType);
                        propInfo.SetValue(element, convertObj);
                    }
                }
                else
                {
                    element = new Dictionary<string, Object>();
                    for (int j = 0; j < data[i].Count; j++)
                    {
                        string propName = aliasColumnsReturn[columnsList[j]];
                        PropertyInfo propInfo = type.GetProperty(propName);
                        Object convertObj = Convert.ChangeType(data[i][j], propInfo.PropertyType);
                        ((Dictionary<string, Object>)element).Add(columnsList[j], convertObj);
                    }
                }
                result.Add(element);
            }
            return result;
        }

        public SelectQuery<T> AddColumnsReturn(string attr, string alias = "")
        {
            if (alias.Length == 0)
            {
                alias = attr;
            }
            this.columnsReturn.Add(attributeList[attr], alias);
            
            this.aliasColumnsReturn.Add(alias, attr);
            return this;
        }

        public virtual string ConvertGroupByToString()
        {
            return "";
        }
        public virtual string ConvertHavingToString()
        {
            return "";
        }
    }
}
