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
       
       
        public Dictionary<string, string> projections;
        public Dictionary<string, string> aliasMap;
        protected Dictionary<string, int> orderBy;
        public Dictionary<string, string> attributeList;
        protected OrCondition condition;
        public SelectQuery() { }
        public SelectQuery(string table, ConfigDB ConfigDB, ParserDB parser, Dictionary<string, string> attributeList)
        {
           
            this.table = table;
            this.ConfigDB = ConfigDB;
            this.parser = parser;
            this.projections = new Dictionary<string, string>();
            this.condition = new OrCondition();
            this.attributeList = attributeList;
            this.orderBy = new Dictionary<string, int>();
            aliasMap = new Dictionary<string, string>();
        }
        public SelectQuery<T> Where(Condition condition)
        {
            this.condition.Add(condition);
            return this;
        }

        public virtual string GetProjectionStr()
        {
            string select = "";
            if (projections.Count == 0)
            {
                // select = "*";

                foreach (string key in attributeList.Keys)
                {
                    select += table + "." + attributeList[key] + ",";
                }
                select = select.Substring(0, select.Length - 1);
            }
            else
            {
                foreach (string projection in projections.Keys)
                {
                    int index = projection.IndexOf("(");
                    string p = projection.Substring(0, index + 1);
                    p = p + table + "." + projection.Substring(index + 1);
                    select += p + " AS " + projections[projection] + ",";
                }
                select = select.Remove(select.Length - 1, 1);
            }
            return select;
        }
        public virtual string GetConditionStr()
        {
            return condition.toSQL(attributeList, table);
        }
        public virtual string GetOrderStr()
        {
            string order = "";
            if (orderBy.Count != 0)
            {
                foreach (string attr in orderBy.Keys)
                {
                    order += attr;
                    if (orderBy[attr] == DESC)
                    {
                        order += " DESC, ";
                    }
                    else
                    {
                        order += " ASC, ";
                    }
                }
                order = order.Remove(order.Length - 1, 1);
            }
            return order;
        }
        public virtual string GetGroupByStr()
        {
            return "";
        }
        public virtual string GetHavingStr()
        {
            return "";
        }

        public List<Object> ToList()
        {
            string selectStr = GetProjectionStr();
            string conditionStr = GetConditionStr();
            string groupByStr = GetGroupByStr();
            string orderStr = GetOrderStr();
            string havingStr = GetHavingStr();

            List<List<string>> res = ConfigDB.Select(parser.ParseSelectQuery(table, selectStr, conditionStr, groupByStr, havingStr, orderStr));
            return ParseResult(res);
        }

        public virtual List<Object> ParseResult(List<List<string>> values)
        {
            if (projections.Count == 0)
            {
                foreach (string key in attributeList.Keys)
                {
                    aliasMap.Add(attributeList[key], key);
                }
            }
            List<Object> res = new List<Object>();
            Dictionary<int, string> colIndex = new Dictionary<int, string>();
            Type type = typeof(T);
            for (int i = 0; i < values[0].Count; i++)
            {
                colIndex.Add(i, values[0][i]);
            }
            for (int i = 1; i < values.Count; i++)
            {
                Object obj = new object();
                if (projections.Count == 0)
                {
                    obj = new T();

                    for (int j = 0; j < values[i].Count; j++)
                    {
                        PropertyInfo propInfo = type.GetProperty(aliasMap[colIndex[j]]);
                        Object convertObj = Convert.ChangeType(values[i][j], propInfo.PropertyType);
                        propInfo.SetValue(obj, convertObj);
                    }
                }
                else
                {
                    obj = new Dictionary<string, Object>();
                    for (int j = 0; j < values[i].Count; j++)
                    {
                        string propName = aliasMap[colIndex[j]];
                        PropertyInfo propInfo = type.GetProperty(propName);
                        Object convertObj = Convert.ChangeType(values[i][j], propInfo.PropertyType);
                        ((Dictionary<string, Object>)obj).Add(colIndex[j], convertObj);
                    }
                }
                res.Add(obj);
            }
            return res;
        }

        //public Include<T> Include(Type type, string[] st = null)
        //{
        //    return new Include<T>(this, type, st);
        //}
    }
}
