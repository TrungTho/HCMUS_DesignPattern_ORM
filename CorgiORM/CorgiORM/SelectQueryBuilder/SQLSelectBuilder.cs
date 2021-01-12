using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorgiORM
{
        public class SQLSelectBuilder : ISelectQueryBuilder
        {
            private string whereCondition;
            private string groupByCondition;
            private string havingCondition;
            private string orderByCondition;
            private string tableName;

            public SQLSelectBuilder(string table)
            {
                this.tableName = table;
            }
            public string getValidStr(string obj)
            {
                return obj.Substring(0, obj.Length - 1) + ")";
            }
            public string getQueryString()
            {
                return $"select * from {tableName} {whereCondition} {getValidStr(groupByCondition)} " +
                    $"{havingCondition} {getValidStr(orderByCondition)}";
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
                    this.groupByCondition = "GROUP BY(" + fieldName;
                }
                else
                {
                    this.groupByCondition += "," + fieldName;
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

            public ISelectQueryBuilder Where(string fieldName, Object value)
            {
                if (this.whereCondition == null)
                {
                    this.whereCondition = "WHERE " + fieldName + "=" + getValue(value);
                }
                else
                {
                    this.whereCondition += " AND " + fieldName + "=" + getValue(value);
                }
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
