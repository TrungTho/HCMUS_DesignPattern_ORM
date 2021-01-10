using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CorgiORM
{
    class GroupByQuery<T> : SelectQuery<T> where T : new()
    {
        protected SelectQuery<T> wrapeeQuery;
        protected List<string> groupByList;
        protected OrCondition havingCondition;

        public GroupByQuery(SelectQuery<T> wrapeeQuery)
        {
            this.wrapeeQuery = wrapeeQuery;
            this.groupByList = new List<string>();
            this.havingCondition = new OrCondition();
            this.ConfigDB = wrapeeQuery.ConfigDB;
            this.parser = wrapeeQuery.parser;
            this.table = wrapeeQuery.table;
        }
        public new GroupByQuery<T> Where(Condition condition)
        {
            this.wrapeeQuery.Where(condition);
            return this;
        }
        public override string ConvertAttributesToString()
        {
            return this.wrapeeQuery.ConvertAttributesToString();
        }
        public override string ConvertConditionToString()
        {
            return this.wrapeeQuery.ConvertConditionToString();
        }
        public override string ConvertOrderToString()
        {
            return this.wrapeeQuery.ConvertOrderToString();
        }
        public override string ConvertHavingToString()
        {
            return this.wrapeeQuery.ConvertHavingToString();
        }
        public override string ConvertGroupByToString()
        {
            string groupByStr = "";
            if (this.groupByList.Count == 0)
            {
                return "";
            }
            
            foreach (string groupByEle in this.groupByList)
            {
                groupByStr += groupByEle + ",";
            }
            groupByStr = groupByStr.Remove(groupByStr.Length - 1, 1);
            return groupByStr;
        }

        public GroupByQuery<T> AddProjection(string attr, string aggFunc = "", string alias = "")
        {
            if (aggFunc.Length != 0 && alias.Length == 0)
            {
                throw new Exception("Alias for Aggegate function is not specified");
            }
            string aggAttr = this.wrapeeQuery.attributeList[attr];
            if (aggFunc.Length != 0)
            {
                aggAttr = aggFunc + "(" + aggAttr + ")";
            }
            if (alias.Length == 0)
            {
                alias = attr;
            }
            this.wrapeeQuery.columnsReturn.Add(aggAttr, alias);
            this.wrapeeQuery.aliasColumnsReturn.Add(alias, attr);
            return this;
        }
        public new GroupByQuery<T> GroupBy(string attr)
        {
            Console.WriteLine(attr);
            this.groupByList.Add(this.wrapeeQuery.attributeList[attr]);
            return this;
        }
        public new GroupByQuery<T> OrderBy(string attr, string order = "ASC")
        {
            this.wrapeeQuery.OrderBy(attr, order);
            return this;
        }
        public GroupByQuery<T> Having(Condition condition)
        {
            this.havingCondition.Add(condition);
            return this;
        }
        public override List<object> ParseResult(List<List<string>> values)
        {
            if (this.wrapeeQuery.columnsReturn.Count == 0)
            {
                foreach (string key in this.wrapeeQuery.attributeList.Keys)
                {

                    this.wrapeeQuery.aliasColumnsReturn.Add(this.wrapeeQuery.attributeList[key], key);
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
                if (this.wrapeeQuery.columnsReturn.Count == 0)
                {
                    obj = new T();

                    for (int j = 0; j < values[i].Count; j++)
                    {
                        PropertyInfo propInfo = type.GetProperty(this.wrapeeQuery.aliasColumnsReturn[colIndex[j]]);
                        Object convertObj = Convert.ChangeType(values[i][j], propInfo.PropertyType);
                        propInfo.SetValue(obj, convertObj);
                    }
                }
                else
                {
                    obj = new Dictionary<string, Object>();
                    for (int j = 0; j < values[i].Count; j++)
                    {
                        string propName = this.wrapeeQuery.aliasColumnsReturn[colIndex[j]];
                        PropertyInfo propInfo = type.GetProperty(propName);
                        Object convertObj = Convert.ChangeType(values[i][j], propInfo.PropertyType);
                        ((Dictionary<string, Object>)obj).Add(colIndex[j], convertObj);
                    }
                }
                res.Add(obj);
            }
            return res;
        }
    }

}
